using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystemApp.DAL.DAO;
using VotingSystemApp.DAL.GateWay;

namespace VotingSystemApp.BLL
{
    class MixedCandidateCastBLL
    {
        private MixedCandidateCastGateWay aMixedCandidateCastGateWay;
        public MixedCandidateCastBLL()
        {
            aMixedCandidateCastGateWay = new MixedCandidateCastGateWay();
        }


        public List<MixedCandidateCast> ResultOfVoting()
        {
            List<MixedCandidateCast> votingResult = new List<MixedCandidateCast>();
            votingResult = aMixedCandidateCastGateWay.ResultOfVoting();

            return votingResult;
        }
    }
}
