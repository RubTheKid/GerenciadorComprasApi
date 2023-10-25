using System.ComponentModel.DataAnnotations;

namespace GerenciadorComprasApi.Models.ViewModels.Usuarios;

public class RegisterViewModel
{
    [Required]
    public string Username { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(6, ErrorMessage = "A senha deve conter pelo menos 6 caracteres.")]
    public string Password { get; set; }
}
