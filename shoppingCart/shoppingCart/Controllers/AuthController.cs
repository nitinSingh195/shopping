using Microsoft.AspNetCore.Mvc;
using shoppingCart.Common;
using shoppingCart.Model;
using shoppingCart.Repository;
namespace shoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IProductRepository _jwtManagerRepository;

        public AuthController(IProductRepository jwtManagerRepository)
        {
            _jwtManagerRepository = jwtManagerRepository;
        }


        [HttpPost("login")]
        public IActionResult Login(User12 users12)
        {
            users12.PasswordHash= users12.PasswordHash.HashPassword();
            var tokens = _jwtManagerRepository.Authenticate(users12);
            if (tokens == null)
            {
                return Unauthorized("Invalid credentials");
            }
            return Ok(tokens);
        }
    }
}

