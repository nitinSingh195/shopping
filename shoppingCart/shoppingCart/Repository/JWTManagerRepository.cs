using shoppingCart.Model;
using System.Data.SqlClient;
using System.Data;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using shoppingCart.Common;
#nullable disable

namespace shoppingCart.Repository
{
    public class JWTManagerRepository : IProductRepository
    {
        private readonly string connectionString;
        private readonly IConfiguration iconfiguration;

        public JWTManagerRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
            iconfiguration = configuration;
        }

        public Tokens Authenticate(User12 users12)
        {
            int _userId;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("loginsp", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Username", users12.Username);
                    command.Parameters.AddWithValue("@PasswordHash", users12.PasswordHash);
                    _userId = Convert.ToInt32(command.ExecuteScalar());
                    if (_userId == 0) 
                    {
                        return null;
                    }
                }

                string role = GetRoleFromDatabase(users12.Username);
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
                var accessTokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Surname, users12.Username),
                        new Claim(ClaimTypes.Role, role),
                    }),
                    Expires = DateTime.Now.AddMinutes(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var accessToken = tokenHandler.CreateToken(accessTokenDescriptor);
                var refreshTokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, users12.Username),
                        new Claim(ClaimTypes.Role, role)

                    }),
                    Expires = DateTime.UtcNow.AddMonths(7).ToUniversalTime(),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var refreshToken = tokenHandler.CreateToken(refreshTokenDescriptor);
                var tokens = new Tokens
                {
                    AccessToken = tokenHandler.WriteToken(accessToken),
                    RefreshToken = tokenHandler.WriteToken(refreshToken),
                    Role = role,
                    AccessTokenExpiresIn = accessTokenDescriptor.Expires.Value,
                    RefreshTokenExpiresIn = refreshTokenDescriptor.Expires.Value,
                    UserId = _userId,
                };
                return tokens;
            }

        }
        public string GetRoleFromDatabase(string Username)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand("usersrole", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Username", Username);
                    var roleParameter = new SqlParameter("@Role", SqlDbType.VarChar, 20);
                    roleParameter.Direction = ParameterDirection.Output;
                    command.Parameters.Add(roleParameter);
                    command.ExecuteNonQuery();
                    return command.Parameters["@Role"].Value.ToString();
                }
            }
        }
    }
}
