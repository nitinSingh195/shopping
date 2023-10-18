using shoppingCart.Model;
using System.Data;
using System.Data.SqlClient;

namespace shoppingCart.Repository
{
  
        public class UserRepository : IUserRepository
        {
            private readonly string _connectionString;

            public UserRepository(IConfiguration configuration)
            {
                _connectionString = configuration.GetConnectionString("DefaultConnection");
            }

            public  int CreateUser(Users user)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand("CreateUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserName", user.Username);
                        command.Parameters.AddWithValue("@FirstName", user.FirstName);
                        command.Parameters.AddWithValue("@LastName", user.LastName);
                        command.Parameters.AddWithValue("@Email", user.Email);
                        command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
                        var userIdParameter = new SqlParameter("@UserId", SqlDbType.Int);
                        userIdParameter.Direction = ParameterDirection.Output;
                        command.Parameters.Add(userIdParameter);
                        command.ExecuteNonQuery();
                        return (int)userIdParameter.Value;
                    }
                }
            }
        }
    }


