using System.ComponentModel.DataAnnotations;

namespace GerenciadorComprasApi.Models.Domain;

public class Produto
{
    [Key]
    public string Gtin { get; set; }
    public string Nome { get; set; }
    public decimal? Preco { get; set; }
    public int? EstoqueDisponivel { get; set; }
    public int? CotaMinima { get; set; }
    
}
