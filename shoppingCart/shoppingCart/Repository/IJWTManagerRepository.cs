using shoppingCart.Model;

namespace shoppingCart.Repository
{
    public interface IProductRepository
    {
        public Tokens Authenticate(User12 users12);
        public string GetRoleFromDatabase(string Username);
    }
}
