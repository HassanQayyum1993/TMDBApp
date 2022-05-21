using tmdbapi.Auth;
using Microsoft.AspNetCore.Mvc;
using tmdbapi.Services.IServices;

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
            //var user = await _userManager.FindByNameAsync(model.Username);
            //if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            //{
            //    var userRoles = await _userManager.GetRolesAsync(user);

            //    var authClaims = new List<Claim>
            //    {
            //        new Claim(ClaimTypes.Name, user.UserName),
            //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            //    };

            //    foreach (var userRole in userRoles)
            //    {
            //        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            //    }

            //    var token = GetToken(authClaims);

            //    return Ok(new
            //    {
            //        token = new JwtSecurityTokenHandler().WriteToken(token),
            //        expiration = token.ValidTo
            //    });
            //}
            //return Unauthorized();
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

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            //var userExists = await _userManager.FindByNameAsync(model.Username);
            //if (userExists != null)
            //    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            //IdentityUser user = new()
            //{
            //    Email = model.Email,
            //    SecurityStamp = Guid.NewGuid().ToString(),
            //    UserName = model.Username
            //};
            //var result = await _userManager.CreateAsync(user, model.Password);
            //if (!result.Succeeded)
            //    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            //return Ok(new IResponse { Status = "Success", Message = "User created successfully!" });

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

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            //var userExists = await _userManager.FindByNameAsync(model.Username);
            //if (userExists != null)
            //    return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            //IdentityUser user = new()
            //{
            //    Email = model.Email,
            //    SecurityStamp = Guid.NewGuid().ToString(),
            //    UserName = model.Username
            //};
            //var result = await _userManager.CreateAsync(user, model.Password);
            //if (!result.Succeeded)
            //    return StatusCode(StatusCodes.Status500InternalServerError, new IResponse { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            //if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
            //    await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            //if (!await _roleManager.RoleExistsAsync(UserRoles.User))
            //    await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            //if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            //{
            //    await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            //}
            //if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
            //{
            //    await _userManager.AddToRoleAsync(user, UserRoles.User);
            //}
            //return Ok(new IResponse { Status = "Success", Message = "User created successfully!" });

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

       
    }
}