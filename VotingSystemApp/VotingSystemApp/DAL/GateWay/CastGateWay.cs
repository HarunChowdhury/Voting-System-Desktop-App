using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VotingSystemApp.DAL.DAO;

namespace VotingSystemApp.DAL.GateWay
{

   public  class CastGateWay :InitializeConstructor
    {
        private SqlCommand command;
        private string query;
        private string databaseSymbol = "";
        private Cast aCast;

       public CastGateWay()
       {
           aCast = new Cast();
       }

       public string Save(int maxCastNo, string currentSymbol)
       {
        

            connection.Open();
            query = string.Format("SELECT * FROM t_Cast");
            command = new SqlCommand(query, connection);
            SqlDataReader aReader = command.ExecuteReader();
        
            if (aReader.HasRows)
            {
                while (aReader.Read())
                {               
                    aCast.Symbol = aReader[1].ToString();

                    if (currentSymbol == aCast.Symbol)
                    {
                        aReader.Close();
                        databaseSymbol = aCast.Symbol;
                       
                        query = string.Format("UPDATE t_Cast SET NoOfCastVote=NoOfCastVote+{0} WHERE Symbol='{1}' ", 1, aCast.Symbol);
                    
                        command = new SqlCommand(query, connection);
                        int affectedRows = command.ExecuteNonQuery();
                       
                        if (affectedRows >= 0)
                        {
                           // aCast.MaxNoOfWinners--;
                            return "Vote Cast update success";
                        }
                            
                     else
                        {
                            return "Something problem in System"; 
                        }
                       
                  
                    }
                    
                }

               
            }

            connection.Close();

            if (databaseSymbol!=currentSymbol)
            {

                connection.Open();
                query = string.Format("INSERT INTO t_Cast  VALUES('{0}',{1})", currentSymbol, 1);
              
                command = new SqlCommand(query, connection);
                
                int affectedRows = command.ExecuteNonQuery();
                connection.Close();
                if (affectedRows >= 0)
                    return " Casted success";
                return "Something problem in System"; 
            }

            return "Something problem in System";
        }

      
    }
}
