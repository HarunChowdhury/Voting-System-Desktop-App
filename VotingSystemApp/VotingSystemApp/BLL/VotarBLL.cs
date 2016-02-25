using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystemApp.DAL.DAO;
using VotingSystemApp.DAL.GateWay;

namespace VotingSystemApp.BLL
{
  public class VotarBLL
    {
        private CandidateGateWay aCandidateGateWay;
        private VotarWateWay aVotarWateWay;
        public VotarBLL()
        {
            aVotarWateWay = new VotarWateWay();
            aCandidateGateWay = new CandidateGateWay();
        }
               
      //public List<Votar> CollectEmail(string votarEmail, int winnersNumber)
      //{
        
      //}
    }
}
