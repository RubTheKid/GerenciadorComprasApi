using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GerenciadorComprasApi.Models.Domain;

public class Produto
{
    [Key]
    [JsonPropertyName("gtin")]
    public string Gtin { get; set; }
    [JsonPropertyName("nome")]
    public string Nome { get; set; }
    [JsonPropertyName("preco")]
    public decimal? Preco { get; set; }
    [JsonPropertyName("estoqueDisponivel")]
    public int? EstoqueDisponivel { get; set; }

    [JsonPropertyName("cotaMinima")]
    public int? CotaMinima { get; set; }
    
}
