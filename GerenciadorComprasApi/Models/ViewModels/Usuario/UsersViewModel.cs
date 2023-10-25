using GerenciadorComprasApi.Models.Domain;

namespace GerenciadorComprasApi.Models.ViewModels.Usuarios;

public class UsersViewModel
{
    public List<User> Users { get; set; }

    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool AdminRoleCheckbox { get; set; }
}
