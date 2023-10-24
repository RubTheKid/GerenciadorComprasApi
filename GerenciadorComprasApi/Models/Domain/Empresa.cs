namespace GerenciadorComprasApi.Models.Domain;

public class Empresa
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Cnpj { get; set; }
    public string? Email { get; set; }
    public string InscricaoEstadual { get; set; }
    public string InscricaoMunicipal { get; set; }

    public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
    public ICollection<Servico> Servicos { get; set; } = new List<Servico>();
}
