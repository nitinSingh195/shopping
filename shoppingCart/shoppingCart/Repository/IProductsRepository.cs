using Microsoft.AspNetCore.Mvc;
using shoppingCart.Model;

namespace shoppingCart.Repository
{
    public interface IProductsRepository
    {

        public List<Product> GetProducts();
        public void AddToCart(int userId, int productId);
    }
}
