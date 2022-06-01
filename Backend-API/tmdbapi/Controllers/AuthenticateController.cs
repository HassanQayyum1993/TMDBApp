using tmdbapi.Auth;
using Microsoft.AspNetCore.Mvc;
using tmdbapi.Services.IServices;
using tmdbapi.ViewModels;

namespace tmdbapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;

        public AuthenticateController(
            IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            try
            {
                var result = await _authenticateService.LoginAsync(model);
                if (result.Status == "Success")
                {
                    return Ok(result);
                }
                else if (result.Status == "Unauthorize")
                {
                    return Unauthorized(result);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, result);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Login failed!" });
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            try
            {
                var result = await _authenticateService.RegisterAsync(model);
                if (result.Status == "Success")
                {
                    return Ok(result);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, result);
                }
            }
            catch 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Unable to create this user!" });
            }
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            try
            {
                var result = await _authenticateService.RegisterAdminAsync(model);
                if (result.Status == "Success")
                {
                    return Ok(result);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, result);
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Unable to create this user!" });
            }
        }
    }
}