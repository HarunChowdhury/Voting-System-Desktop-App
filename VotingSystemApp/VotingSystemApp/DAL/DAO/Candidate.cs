using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystemApp.DAL.DAO
{
   public class Candidate
    {
       public int CandidateId { get; set; }
       public string  CandidateName { get; set; }
       public string  CandidateSymbol { get; set; }

       public Candidate(string name,string symbol)
       {

           CandidateName = name;
           CandidateSymbol = symbol;

       }

       public Candidate()
       {

       }
    }
}
