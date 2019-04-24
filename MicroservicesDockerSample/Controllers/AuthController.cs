using MicroservicesDockerSample.Managers;
using MicroservicesDockerSample.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MicroservicesDockerSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService userService;

        public AuthController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        [Route ("CreateUser")]
        public IActionResult CreateUser([FromForm] User user)
        {
            if (ModelState.IsValid)
            {
                user.UserId = Guid.NewGuid().ToString();
                user.Roles = new string[] { "user" };
                userService.CreateUser(user);
                return new OkObjectResult($"User {user.UserId} successfuly created");
            }
            else
                return new BadRequestResult();
        }

        [HttpPost]
        public Response GetToken([FromForm]string userName, [FromForm]string password)
        {
            var user = userService.Authenticate(userName, password);
            if (user == null)
            {
                return new Response
                {
                    StatusCode = 401,
                    Message = "Unauthorize"
                };
            }

            IAuthContainerModel authContainerModel = new JWTContainerModel(user)
            {
                
            };
            IAuthService authService = new JWTService(authContainerModel.Secretkey);

            return new Response
            {
                StatusCode = 200,
                Message = "OK",
                AccessToken = authService.GenerateToken(authContainerModel)
            };
        }

        // GET: api/Auth/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
