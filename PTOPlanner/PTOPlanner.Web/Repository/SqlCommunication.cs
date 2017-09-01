using System.Data.SqlClient;


namespace PTOPlanner.Web.Repository
{
    public class SqlCommunication
    {
        public void OpenConnection(SqlConnection connection)
        {
            connection.Open();
        }
    }
}
