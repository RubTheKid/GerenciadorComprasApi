namespace GerenciadorComprasApi.Models.Domain;

public class Pedidos
{
    public Guid Id { get; set; }
    public string Codigo { get; set; }  
    public DateTime? Data { get; set; }
    public ICollection<Empresa> Empresa { get; set; } = new List<Empresa>();
    public ICollection<Produto> Produto { get; set; } = new List<Produto>();
}
