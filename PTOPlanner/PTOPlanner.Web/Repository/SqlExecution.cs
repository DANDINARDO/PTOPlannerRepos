using System.Data;
using System.Data.SqlClient;

namespace PTOPlanner.Web.Repository
{
    public class SqlExecution
    {
        public int ExecuteNonQuery(SqlCommand command)
        {
            return command.ExecuteNonQuery();
        }

        public IDataReader ExecuteReader(SqlCommand command)
        {
            return command.ExecuteReader();
        }

        public object ExecuteScalar(SqlCommand command)
        {
            return command.ExecuteScalar();
        }
    }
}
