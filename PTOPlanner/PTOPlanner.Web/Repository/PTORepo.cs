using System;
using System.Collections.Generic;
using PTOPlanner.Web.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace PTOPlanner.Web.Repository
{
    public class PTORepo
    {
        private SqlCommunication _sqlCommunication;

        public PTORepo()
        {
            _sqlCommunication = new SqlCommunication();

        }

        public IList<PTOData> LoadYear(int empId, int year)
        {
            var parameters = new Dictionary<string, object>
            {
                {"EmployeeID", empId },
                {"Year", year}
            };
            List<PTOData> results = new List<PTOData>();

            var _sqlExecution = new SqlExecution();
            using (var dro = SetupDataRequestObject("EmpPTOBalanceByYear_Get", parameters))
            {
                using (var reader = _sqlExecution.ExecuteReader(dro.SqlComm))
                {
                    while (reader.Read())
                    {
                        var ptoRow = new PTOData()
                        {
                            Comments = reader["Comments"].ToString(),
                            WeekEnding = Convert.ToDateTime(reader["WeekEnding"]).ToShortDateString(),
                            RequestedHours = (decimal)reader["RequestedHours"],
                            EmployeePTOBalanceID = Convert.ToInt32(reader["EmployeePTOBalanceID"]),
                            EmployeeID = Convert.ToInt32(reader["EmployeeID"]),
                            PTOBalance = (decimal)reader["PTOBalance"]
                        };
                        results.Add(ptoRow);
                    }
                }
            }
            return results;
        }

        private DataRequestObject SetupDataRequestObject(string sqlText, Dictionary<string, object> parameters = null, Dictionary<string, object> outputParameters = null, int varcharSize = 500, CommandType commandType = CommandType.StoredProcedure)
        {
            var dro = new DataRequestObject();

            if (ConfigurationManager.ConnectionStrings["PTO"] == null)
                throw new ConfigurationErrorsException("Connection string not present for PTO");

            dro.SqlConn.ConnectionString = ConfigurationManager.ConnectionStrings["PTO"].ConnectionString;
            dro.SqlComm.Connection = dro.SqlConn;
            dro.SqlComm.CommandType = commandType;
            dro.SqlComm.CommandText = sqlText;

            if (parameters != null && parameters.Count > 0)
            {
                foreach (var parameter in parameters)
                {
                    dro.SqlComm.Parameters.Add(new SqlParameter(parameter.Key, parameter.Value));
                }
            }

            if (outputParameters != null && outputParameters.Count > 0)
            {
                foreach (var outputParameter in outputParameters)
                {
                    if (outputParameter.Value is int)
                    {
                        dro.SqlComm.Parameters.Add(new SqlParameter(outputParameter.Key, SqlDbType.Int, varcharSize) { Direction = ParameterDirection.Output });
                    }
                    else
                    {
                        dro.SqlComm.Parameters.Add(new SqlParameter(outputParameter.Key, SqlDbType.VarChar, varcharSize) { Direction = ParameterDirection.Output });
                    }
                }
            }

            _sqlCommunication.OpenConnection(dro.SqlConn);

            return dro;
        }
    }
}