using System;
using System.Collections.Generic;
using PTOPlanner.Web.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using PTOPlanner.Models;

namespace PTOPlanner.Web.Repository
{
    public class PTORepo
    {
        private SqlCommunication _sqlCommunication;

        public PTORepo()
        {
            _sqlCommunication = new SqlCommunication();

        }

        public IList<Employee> LoadEmployees()
        {
            List<Employee> results = new List<Employee>();

            var _sqlExecution = new SqlExecution();
            using (var dro = SetupDataRequestObject("EmployeeInfo_GET"))
            {
                using (var reader = _sqlExecution.ExecuteReader(dro.SqlComm))
                {
                    while (reader.Read())
                    {
                        var e = new Employee();

                        e.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                        e.FirstName = reader["FirstName"].ToString();
                        e.LastName = reader["LastName"].ToString();

                        results.Add(e);
                    }
                }
            }
            return results;
        }

        public void SaveEmployee(Employee employee)
        {
            var parameters = new Dictionary<string, object>
            {
                {"FirstName", employee.FirstName ?? "" },
                {"LastName", employee.LastName ?? ""},
                {"Email",employee.Email ?? "" },
                {"LoginID", employee.FirstName + "." + employee.LastName },
                {"Password", "password" },
                {"StartDate",employee.StartDate },
                {"AnnualPTODays", employee.AnnualPTODays },
                {"CurrentPTOHrsBalance", employee.CurrentPTOHrsBalance },
                {"PTOHrsAccrualRate", employee.PTOHrsAccrualRate },
                {"MaxHrsCarryOver", employee.MaxHrsCarryOver }
            };

            var _sqlExecution = new SqlExecution();
            using (var dro = SetupDataRequestObject("EmpPTODetails_Create", parameters))
            {
                _sqlExecution.ExecuteNonQuery(dro.SqlComm);
            }
        }

        public IList<PTOData> Save(PTOEntry entry)
        {
            List<PTOData> updatedResults = new List<PTOData>();

            var parameters = new Dictionary<string, object>
            {
                {"EmployeePTOBalanceID", entry.Id },
                {"HrsTaken", entry.Hours},
                {"Comments", entry.Comments ?? "" }
            };

            var _sqlExecution = new SqlExecution();
            using (var dro = SetupDataRequestObject("EmpPTOBalance_Update", parameters))
            {
                using (var reader = _sqlExecution.ExecuteReader(dro.SqlComm))
                {
                    LoadFromReader(reader, updatedResults);
                }
            }

            return updatedResults;
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
                    LoadFromReader(reader, results);
                }
            }
            return results;
        }

        private void LoadFromReader(IDataReader reader, IList<PTOData> results)
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