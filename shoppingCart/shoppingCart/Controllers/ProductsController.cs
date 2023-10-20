using Microsoft.AspNetCore.Mvc;
using shoppingCart.Model;
using shoppingCart.Repository;

namespace shoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository productsRepository;
        public ProductsController(IProductsRepository repository)
        {
            productsRepository = repository;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = productsRepository.GetProducts();
            return Ok(products);
        }
    }
}
