using System.ComponentModel.DataAnnotations;

namespace GerenciadorComprasApi.Models.Domain;

public class User
{
    [Key]
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }

}
