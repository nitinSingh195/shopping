using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using shoppingCart.Model;
using shoppingCart.Repository;

namespace shoppingCart.Controllers
{

    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("signup")]
        public IActionResult Signup([FromBody] Users newUser)
        {
            try
            {
                newUser.RegistrationDate = DateTime.Now;
                newUser.IsActive = true;

                int userId = _userRepository.CreateUser(newUser);
                if (userId == -1)
                {
                    return Ok(new { UserId = userId, Message = "User already exist" });

                }

                return Ok(new { UserId = userId, Message = "User created successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "User creation failed", Error = ex.Message });
            }
        }

    }
}

