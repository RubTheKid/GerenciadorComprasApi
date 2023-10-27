using GerenciadorComprasApp.Models;

namespace GerenciadorComprasApp.Services;

public interface IEmpresaService
{
    Task<IEnumerable<Empresa>> GetEmpresasAsync();
    Task<HttpResponseMessage> AddEmpresaAsync(Empresa novaEmpresa);
    Task<HttpResponseMessage> DeleteAsync(string cnpj);
}
