using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystemApp.DAL.DAO
{
  public  class Cast
    {  
        public string Symbol { get; set; }
        public int MaxNoOfWinners { get; set; }
        public string VotarEmail { get; set; }
      public int Num { get; set; }
    
        public Cast(string symbol,string email):this()
        {
            Symbol = symbol;                 
            VotarEmail = email;
        }
      
      public Cast(int maxNumOfWinners)
      {
          MaxNoOfWinners = maxNumOfWinners;
      }

      public Cast()
      {

      }
    }
}
