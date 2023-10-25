using GerenciadorComprasApi.Models.Domain;
using Microsoft.AspNetCore.Identity;

namespace GerenciadorComprasApi.Repositories.Usuarios;

public interface IUserRepository
{
    Task<IEnumerable<IdentityUser>> GetAll();
}
