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
                    // Set additional fields before creating the user
                    newUser.RegistrationDate = DateTime.Now;
                    newUser.IsActive = true;

                    // Call the repository method to create the user
                    int userId =  _userRepository.CreateUser(newUser);

                    // Optionally, you can return the newly created user's ID
                    return Ok(new { UserId = userId, Message = "User created successfully" });
                }
                catch (Exception ex)
                {
                    // Handle any exceptions that might occur during the signup process
                    return BadRequest(new { Message = "User creation failed", Error = ex.Message });
                }
            }

        }
    }

