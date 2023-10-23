namespace shoppingCart.Model
{
   
        public class Tokens
        {
           
            public string  RefreshToken { get; set;}
            public string Role { get; set;}    
            public string AccessToken { get; set;}
            public DateTime AccessTokenExpiresIn { get; set;}
            public DateTime RefreshTokenExpiresIn { get; set;}
            public int UserId { get; set; }
    }

    }

