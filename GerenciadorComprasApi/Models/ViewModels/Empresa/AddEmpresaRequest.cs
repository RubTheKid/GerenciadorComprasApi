namespace GerenciadorComprasApi.Models.ViewModels.Empresa;

public class AddEmpresaRequest
{
    public string Nome { get; set; }
    public string Cnpj { get; set; }
    public string? Email { get; set; }
    public string InscricaoEstadual { get; set; }
    public string InscricaoMunicipal { get; set; }
}
