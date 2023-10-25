using GerenciadorComprasApi.Models.ViewModels.Usuarios;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorComprasApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<IdentityUser> userManager;
    private readonly SignInManager<IdentityUser> signInManager;

    public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var identityUser = new IdentityUser()
        {
            UserName = registerViewModel.Username,
            Email = registerViewModel.Email
        };

        var identityResult = await userManager.CreateAsync(identityUser, registerViewModel.Password);

        if (identityResult.Succeeded)
        {
            var roleIdentityResult = await userManager.AddToRoleAsync(identityUser, "User");

            if (roleIdentityResult.Succeeded)
            {
                return Ok("Registro bem-sucedido");
            }
        }

        return BadRequest("Registro falhou");
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var signInResult = await signInManager.PasswordSignInAsync(
            loginViewModel.Username,
            loginViewModel.Password,
            false, false);

        if (signInResult.Succeeded)
        {
            return Ok("Login bem-sucedido");
        }

        return Unauthorized();
    }

    [HttpPost("Logout")]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();

        return Ok("Logout bem-sucedido");
    }
}