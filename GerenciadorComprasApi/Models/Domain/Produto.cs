namespace GerenciadorComprasApi.Models.Domain;

public class Produto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public int Gtin { get; set; }
    public decimal? Preco { get; set; }
    public int? EstoqueDisponivel { get; set; }
    public int? CotaMinima { get; set; }
    public ICollection<Empresa> Empresas { get; set; }
}
