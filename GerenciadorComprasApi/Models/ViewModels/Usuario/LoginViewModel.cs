using System.ComponentModel.DataAnnotations;

namespace GerenciadorComprasApi.Models.ViewModels.Usuarios;

public class LoginViewModel
{
    [Required]
    public string Username { get; set; }

    [Required]
    [MinLength(6, ErrorMessage = "A senha deve conter pelo menos 6 caracteres.")]
    public string Password { get; set; }

}
