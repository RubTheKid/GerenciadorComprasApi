using GerenciadorComprasApi.Models.Domain;
using GerenciadorComprasApi.Models.ViewModels.Usuarios;
using GerenciadorComprasApi.Repositories.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorComprasApi.Controllers;

[Authorize(Roles = "Admin")]
[Route("api/[controller]")]
[ApiController]
public class AdminUsersController : ControllerBase
{
    private IUserRepository userRepository;
    private readonly UserManager<IdentityUser> userManager;

    public AdminUsersController(IUserRepository userRepository, UserManager<IdentityUser> userManager)
    {
        this.userRepository = userRepository;
        this.userManager = userManager;
    }

    [HttpGet("List")]
    public async Task<IActionResult> List()
    {
        var users = await userRepository.GetAll();

        var usersViewModel = new UsersViewModel();
        usersViewModel.Users = new List<User>();
        foreach (var user in users)
        {
            usersViewModel.Users.Add(new Models.Domain.User
            {
                Id = Guid.Parse(user.Id),
                Username = user.UserName,
                Email = user.Email
            });
        }

        return Ok(usersViewModel);
    }

    [HttpPost("List")]
    public async Task<IActionResult> List(UsersViewModel request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var identityUser = new IdentityUser
        {
            UserName = request.Username,
            Email = request.Email
        };

        var identityResult = await userManager.CreateAsync(identityUser, request.Password);

        if (identityResult is not null)
        {
            if (identityResult.Succeeded)
            {
                var roles = new List<string> { "User" };

                if (request.AdminRoleCheckbox)
                {
                    roles.Add("Admin");
                }

                identityResult = await userManager.AddToRolesAsync(identityUser, roles);

                if (identityResult is not null && identityResult.Succeeded)
                {
                    return Ok("Usuário criado com sucesso");
                }
            }
        }

        return BadRequest("Falha ao criar usuário");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var user = await userManager.FindByIdAsync(id.ToString());

        if (user is not null)
        {
            var identityResult = await userManager.DeleteAsync(user);

            if (identityResult is not null && identityResult.Succeeded)
            {
                return Ok("Usuário excluído com sucesso");
            }
        }

        return NotFound("Usuário não encontrado");
    }
}
