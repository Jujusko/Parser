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
    public class UserRepository
    {
        public UserDTO GetUserByINN(string inn)
        {
            UserDTO user;
            using (SqlConnection connection = new SqlConnection(Queries.ConnectionString)) 
            {
                user = connection.QuerySingleOrDefault<UserDTO>(Queries.GetUserByINN, new { inn }
               , commandType: CommandType.StoredProcedure);
            }
            return user;
        }

        public UserDTO GetUserByName(string name)
        {
            UserDTO user;
            using (SqlConnection connection = new SqlConnection(Queries.ConnectionString))
            {
                user = connection.QuerySingleOrDefault<UserDTO>(Queries.GetUserByName, new { name = name }
               , commandType: CommandType.StoredProcedure);
            }
            return user;
        }

        public int AddNewUser(UserDTO user)
        {
            using (SqlConnection connection = new SqlConnection(Queries.ConnectionString))
            {
                var a = connection.ExecuteScalar<int>(Queries.AddNewUser, new { user.Name, user.INN, seller_or_buyer =  user.SellerOrBuyer}
                , commandType: CommandType.StoredProcedure);
                return a;
            }
        }
    }
}
