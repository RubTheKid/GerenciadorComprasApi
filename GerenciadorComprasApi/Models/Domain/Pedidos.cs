using System.ComponentModel.DataAnnotations;

namespace GerenciadorComprasApi.Models.Domain;

public class Pedidos
{
    [Key]
    public string CodigoPedido { get; set; }
    public DateTime? Data { get; set; }
    public ICollection<Empresa> Empresa { get; set; } = new List<Empresa>();
    public ICollection<Produto> Produto { get; set; } = new List<Produto>();
}
