using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystemApp.DAL.DAO
{
    class MixedCandidateCast
    {
        public string  Symbol { get; set; }
        public  string Name { get; set; }
        public string Status{ get; set; }
        public int  NoOfCastVote { get; set; }

        public MixedCandidateCast(string symbol,string name,string status,int noOfCast)
        {
            Symbol = symbol;
            Name = name;
            Status = status;
            NoOfCastVote = noOfCast;

        }

        public MixedCandidateCast()
        {

        }

    }
}
