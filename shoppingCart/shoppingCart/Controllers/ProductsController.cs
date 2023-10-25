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
        //public IActionResult AddToCart(int userId, int productId)
        //{

        //    productsRepository.AddToCart(userId, productId);

        //    return Ok();

        //}


        [HttpPost]
        public IActionResult AddToCart([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Invalid request data");
            }
            int userId = product.ProductId;
            int productId = product.ProductId;
            productsRepository.AddToCart(userId, productId);
            return Ok();
            }








    }
}
