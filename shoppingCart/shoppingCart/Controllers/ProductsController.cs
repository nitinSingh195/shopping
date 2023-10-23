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
        public IActionResult AddToCart([FromBody] Product product)
        {
            try
            {
                productsRepository.AddToCart(product);
                return Ok(new { Message = "Product added successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Product add failed", Error = ex.Message });
            }
        }
    }
}
