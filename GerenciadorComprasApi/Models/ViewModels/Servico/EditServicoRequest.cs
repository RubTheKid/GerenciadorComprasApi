namespace GerenciadorComprasApi.Models.ViewModels.Servico;

public class EditServicoRequest
{
    public string CodigoServico { get; set; }
    public string Nome { get; set; }
    public string? Descricao { get; set; }
    public int? PrazoEntrega { get; set; }
}
