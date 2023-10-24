namespace GerenciadorComprasApi.Models.ViewModels.Empresa;

public class EditEmpresaRequest
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Cnpj { get; set; }
    public string? Email { get; set; }
    public string InscricaoEstadual { get; set; }
    public string InscricaoMunicipal { get; set; }
}
