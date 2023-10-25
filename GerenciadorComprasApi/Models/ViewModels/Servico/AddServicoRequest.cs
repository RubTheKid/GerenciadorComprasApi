namespace GerenciadorComprasApi.Models.ViewModels.Servico;

public class AddServicoRequest
{
    public string Nome { get; set; }
    public string? Descricao { get; set; }
    public int? PrazoEntrega { get; set; }
}
