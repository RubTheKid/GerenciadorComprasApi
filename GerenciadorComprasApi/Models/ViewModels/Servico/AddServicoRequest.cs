namespace GerenciadorComprasApi.Models.ViewModels.Servico;

public class AddServicoRequest
{
    public string CodigoServico { get; set; }
    public string Nome { get; set; }
    public string? Descricao { get; set; }
    public int? PrazoEntrega { get; set; }
}
