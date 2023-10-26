using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GerenciadorComprasApi.Models.Domain;

public class Empresa
{
    [Key]
    public string Cnpj { get; set; }
    public string Nome { get; set; }
    public string? Email { get; set; }
    public string InscricaoEstadual { get; set; }
    public string InscricaoMunicipal { get; set; }

}
