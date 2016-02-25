using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingSystemApp.DAL.DAO
{
   public  class Votar
    {
         public int VotarId{ get; set; }
         public string  VotarEmail{ get; set; }
        
         public Votar(string email)
         {
             VotarEmail = email;
     
         }
         public Votar()
         {
         

         }
    }
}
