using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystemApp.DAL.DAO;
using VotingSystemApp.DAL.GateWay;

namespace VotingSystemApp.BLL
{
   public class CandidateBLL
    {
        private CandidateGateWay aCandidateGateWay;

        public CandidateBLL()
        {
            aCandidateGateWay = new CandidateGateWay();
        }


     public string Save(Candidate aCandidate)
       {
           if (aCandidate.CandidateName == string.Empty || aCandidate.CandidateSymbol == string.Empty)
           {
               return "Please fill up the Candidate fields.";
           }
           else
           {
               return aCandidateGateWay.Save(aCandidate);

           }
       }


     public List<Candidate> GetSymbol()
     {
         List<Candidate> candidates = new List<Candidate>();
         candidates = aCandidateGateWay.GetSymbol();
         return candidates;
     }
    }
}
