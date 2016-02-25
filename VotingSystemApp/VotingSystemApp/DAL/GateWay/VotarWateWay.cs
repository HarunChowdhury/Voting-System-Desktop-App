using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystemApp.DAL.DAO;

namespace VotingSystemApp.DAL.GateWay
{
  public class VotarWateWay:InitializeConstructor
  {

        public string Save(Votar aVotar)
       {

            connection.Open();
          string query = string.Format("INSERT INTO t_Votar VALUES('{0}')", aVotar.VotarEmail);
           command = new SqlCommand(query, connection);
           int affectedRows = command.ExecuteNonQuery();
            connection.Close();
            if (affectedRows > 0)
                return "Insret Success";
            return "Some Problem";
        }


        public bool IsValidEmail(string email)
        {
            connection.Open();
            string query = string.Format("SELECT * FROM t_Votar WHERE Email='{0}'", email);
            command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            bool hasRows = aReader.HasRows;
            connection.Close();
            return hasRows;
        }
     
    }
}
