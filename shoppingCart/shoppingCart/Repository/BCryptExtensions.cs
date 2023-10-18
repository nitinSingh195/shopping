using shoppingCart.Model;
using BCrypt.Net;

namespace shoppingCart.Repository
{
    

    public static class BCryptExtensions
    {
        public static string HashPassword(this string password)
        {
            // Generate a random salt and hash the password
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            return BCrypt.Net.BCrypt.HashPassword(password, salt);
        }

        public static bool VerifyPassword(this string password, string hashedPassword)
        {
            // Verify the entered password against the stored hash
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }

}
