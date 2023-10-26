namespace GerenciadorComprasApp.Models;

public class Empresa
{
    public string Cnpj { get; set; }
    public string Nome { get; set; }
    public string? Email { get; set; }
    public string InscricaoEstadual { get; set; }
    public string InscricaoMunicipal { get; set; }
}
