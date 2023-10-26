namespace GerenciadorComprasApi.Models.ViewModels.Produto;

public class EditProdutoRequest
{
    public string Gtin { get; set; }
    public string Nome { get; set; }
    public decimal? Preco { get; set; }
    public int? EstoqueDisponivel { get; set; }
    public int? CotaMinima { get; set; }
}