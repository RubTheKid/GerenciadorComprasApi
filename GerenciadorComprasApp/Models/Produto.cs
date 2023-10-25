namespace GerenciadorComprasApp.Models;

public class Produto
{
    public Guid id { get; set; }
    public string nome { get; set; }
    public int gtin { get; set; }
    public decimal? preco { get; set; }
    public int? estoqueDisponivel { get; set; }
    public int? cotaMinima { get; set; }
}
