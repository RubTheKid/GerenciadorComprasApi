using System.ComponentModel.DataAnnotations;

namespace GerenciadorComprasApi.Models.Domain;

public class Servico
{
    [Key]
    public string CodigoServico { get; set; }
    public string Nome { get; set; }
    public string? Descricao { get; set; }
    public int? PrazoEntrega { get; set; }
}
