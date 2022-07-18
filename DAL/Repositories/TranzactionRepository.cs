using DAL.DataTransferObjects;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TranzactionRepository
    {

        public void AddNewTranzaction(TranzactionDTO tranz)
        {
            using (SqlConnection connection = new SqlConnection(Queries.ConnectionString))
            {
                connection.Query<UserDTO>(Queries.AddTranzaction, 
                    new { tranz.Declaration, tranz.Date, tranz.Value, seller_id = tranz.SellerId, buyer_id =  tranz.BuyerId}
                , commandType: CommandType.StoredProcedure);
            }
        }

        public TranzactionDTO GetTranzactionByDeclaration(string declaration)
        {
            TranzactionDTO user;
            using (SqlConnection connection = new SqlConnection(Queries.ConnectionString))
            {
                user = connection.QueryFirstOrDefault<TranzactionDTO>(Queries.GetTranzactionByDeclaration, new { declaration }
               , commandType: CommandType.StoredProcedure);
                
            }
            return user;
        }
    }
}
//0001003325007967003702125327
//0001003325007967003702125327
