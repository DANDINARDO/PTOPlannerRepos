using System;
using System.Data.SqlClient;

namespace PTOPlanner.Web.Repository
{
    /// <summary>
    /// Simple class to encapsulate SQL connections and commands to ensure when disposed resources are released.
    /// </summary>
    public class DataRequestObject : IDisposable
    {
        private SqlConnection _sqlConn;

        /// <summary>
        /// Gets or sets the SQL connection.
        /// </summary>
        /// <value>
        /// The SQL connection.
        /// </value>
        public SqlConnection SqlConn
        {
            get { return _sqlConn ?? (_sqlConn = new SqlConnection()); }
            set { _sqlConn = value; }
        }

        private SqlCommand _sqlComm;

        /// <summary>
        /// Gets or sets the SQL Command object.
        /// </summary>
        /// <value>
        /// The SQL Command object.
        /// </value>
        public SqlCommand SqlComm
        {
            get { return _sqlComm ?? (_sqlComm = new SqlCommand()); }
            set { _sqlComm = value; }
        }

        /// <summary>
        /// Disposes of the connection and command object, also sets them to null so resources
        /// are freed faster by garbage collection.
        /// </summary>
        public void Dispose()
        {
            if (_sqlComm != null)
            {
                _sqlComm.Dispose(); 
                _sqlComm = null;
            }
            if (_sqlConn != null)
            {
                _sqlConn.Dispose(); 
                _sqlConn = null;
            }
        }
    }
}
