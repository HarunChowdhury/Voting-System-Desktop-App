using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystemApp.DAL.DAO;

namespace VotingSystemApp.DAL.GateWay
{
    class MixedCandidateCastGateWay:InitializeConstructor
    {
        public List<MixedCandidateCast> ResultOfVoting()
        {
           
            connection.Open();
            string query = string.Format("select t_Cast.Symbol,t_Cast.NoOfCastVote,t_Candidate.Name from t_Cast join t_Candidate on t_Cast.Symbol=t_Candidate.Symbol");
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
            List<MixedCandidateCast> votingInfo = new List<MixedCandidateCast>();
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {

                    MixedCandidateCast aMixedCandidateCast = new MixedCandidateCast();
                    aMixedCandidateCast.Symbol = aReader[0].ToString();
                    aMixedCandidateCast.Name = aReader[2].ToString();
                    aMixedCandidateCast.NoOfCastVote = (int)aReader[1];
                    aMixedCandidateCast.Status = "Winner";
                    votingInfo.Add(aMixedCandidateCast);
                }
            }
            connection.Close();
            return votingInfo;
        }
    }
}
