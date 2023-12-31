﻿namespace shoppingCart.Model
{
    public class Users
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set;}
        public string LastName { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }    
        public DateTime RegistrationDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public bool IsActive { get; set; }
    }
}
