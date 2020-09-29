using System.Threading.Tasks;
using BasicAuthentication.API.Interface;
using BasicAuthentication.API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BasicAuthtication.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]/[action]")]
    public class AuthenticationController : ControllerBase
    {
        private IUserService _userService;

        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }
        //initial request for the authenticate
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] LoginModel model)
        {
            var user = await _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }
    }
}