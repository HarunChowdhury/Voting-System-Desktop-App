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
    public class CandidateGateWay : InitializeConstructor
    {

       public string Save(Candidate aCandidate)
       {
          connection.Open();
           string query = string.Format("INSERT INTO t_Candidate  VALUES('{0}','{1}')",aCandidate.CandidateName,aCandidate.CandidateSymbol);
           command = new SqlCommand(query, connection);         
           int affectedRows = command.ExecuteNonQuery();

           if (affectedRows > 0)
           {
               connection.Close();
               return "Insret Success";
           }
              
           else
           {
               connection.Close();
               return "Some Problem";
           }
            


       }

       public List<Candidate> GetSymbol()
       {
           connection.Open();
           string query = string.Format("SELECT * FROM t_Candidate");
           command = new SqlCommand(query, connection);
           SqlDataReader aReader = command.ExecuteReader();
           List<Candidate> candidates = new List<Candidate>();
           if (aReader.HasRows)
           {
               while (aReader.Read())
               {
                   Candidate aCandidate = new Candidate();
                   aCandidate.CandidateSymbol = aReader[2].ToString();
                   candidates.Add(aCandidate);
               }

           }

           connection.Close();
           return candidates;
       }

    
    }
}
