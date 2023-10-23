using Microsoft.AspNetCore.Mvc;
using shoppingCart.Common;
using shoppingCart.Model;
using shoppingCart.Repository;
namespace shoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
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
            //SetUserData(tokens.UserId);
            HttpContext.Session.SetInt32("UserId", tokens.UserId);
            return Ok(tokens);
        }
    }
}

