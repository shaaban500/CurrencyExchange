using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Dtos;

namespace CurrencyExchange.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UsersController : ControllerBase
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly SignInManager<IdentityUser> _signInManager;

		public UsersController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[HttpPost("Reigster")]
		public async Task<IActionResult> Register(RegisterDto registerDto)
		{
			var user = new IdentityUser() { Email = registerDto.Email, UserName = registerDto.Email };
			var result = await _userManager.CreateAsync(user, registerDto.Password);
			if (!result.Succeeded)
			{
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
				return BadRequest(new ValidationProblemDetails(ModelState));
			}
			return Ok();
		}


		[HttpPost("Login")]
		public async Task<ActionResult> Login(LoginDto loginDto)
		{
			var result = await _signInManager.PasswordSignInAsync(loginDto.Email, loginDto.Password, false, false);
			if (!result.Succeeded)
			{
				ModelState.AddModelError(string.Empty, "Invalid Login");
				return BadRequest(new ValidationProblemDetails(ModelState));
			}
			return Ok("Login successfully");
		}
	}
}
