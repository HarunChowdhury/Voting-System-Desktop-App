using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystemApp
{
    public class InitializeConstructor
    {
        public SqlCommand command;
        public SqlConnection connection;
        public InitializeConstructor()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["con"];
            string connectionString = "";
            if (settings != null)
                connectionString = settings.ConnectionString;
            connection = new SqlConnection();
            connection.ConnectionString = connectionString;         
        }

      
    }
}
