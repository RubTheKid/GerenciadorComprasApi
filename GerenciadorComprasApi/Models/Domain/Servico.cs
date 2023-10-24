namespace GerenciadorComprasApi.Models.Domain;

public class Servico
{
    public Guid ServicoId { get; set; }
    public string Nome { get; set; }
    public string? Descricao { get; set; }
    public int? PrazoEntrega { get; set; }

    public ICollection<Empresa> Empresas { get; set; }
}
