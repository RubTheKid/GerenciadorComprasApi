namespace GerenciadorComprasApp.Models;

public class Empresa
{
    public string cnpj { get; set; }
    public string nome { get; set; }
    public string? email { get; set; }
    public string inscricaoEstadual { get; set; }
    public string inscricaoMunicipal { get; set; }
}
