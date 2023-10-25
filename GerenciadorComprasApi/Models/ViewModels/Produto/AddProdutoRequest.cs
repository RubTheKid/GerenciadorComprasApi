namespace GerenciadorComprasApi.Models.ViewModels.Produto;

public class AddProdutoRequest
{
    public string Nome { get; set; }
    public int Gtin { get; set; }
    public decimal? Preco { get; set; }
    public int? EstoqueDisponivel { get; set; }
    public int? CotaMinima { get; set; }
}