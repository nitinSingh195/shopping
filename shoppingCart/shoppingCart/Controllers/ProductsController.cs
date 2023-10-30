using Microsoft.AspNetCore.Mvc;
using shoppingCart.Model;
using shoppingCart.Repository;

namespace shoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        private readonly IProductsRepository productsRepository;
        public ProductsController(IProductsRepository repository)
        {
           productsRepository = repository;
        }

        [HttpGet]
        public IActionResult GetProducts(int userId)
        {
            var products = productsRepository.GetProducts();
            return Ok(products);
        }

        [HttpPost]
        [Route("addToCart/{userId}/{productId}")]
        public IActionResult AddToCart(int userId,int productId)
        {
            if (userId == 0 || productId == 0)
            {
                return BadRequest("Invalid request data");
            }
            productsRepository.AddToCart(userId, productId);
            return Ok();
        }








    }
}
