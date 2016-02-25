using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystemApp.DAL.DAO;
using VotingSystemApp.DAL.GateWay;

namespace VotingSystemApp.BLL
{
    class CastBLL:CandidateBLL
    {
        private CastGateWay aCastGateWay;
        private VotarWateWay aVotarWateWay;
        private Cast aCast;
        public CastBLL()
        {
            aCastGateWay = new CastGateWay();
            aCast = new Cast();
            aVotarWateWay = new VotarWateWay();
        }


        public string Save(int maxCastNo, string currentSymbol, string email)
        {
          
            if (IsValidEmail(email))
            {

                if (maxCastNo <= 0)
                {                                     
                    return "Your vote is Casted over";                                 
                }
                else
                {                                    
                   
                    return aCastGateWay.Save(maxCastNo, currentSymbol);
                }
            }

            else
            {
                return "This votar doesn't exixts in the system";
            }

        }

        private bool IsValidEmail(string email)
        {
            return aVotarWateWay.IsValidEmail(email);
        }

       
    }
}
