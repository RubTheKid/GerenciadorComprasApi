using GerenciadorComprasApi.Models.Domain;

namespace GerenciadorComprasApi.Repositories.Empresas;

public interface IEmpresaRepository
{
    Task<IEnumerable<Empresa>> GetAllAsync();
    Task<Empresa> GetAsync(Guid id);
    Task<Empresa> AddAsync(Empresa empresa);
    Task<Empresa> UpdateAsync(Empresa empresa);
    Task<Empresa> DeleteAsync(Guid id);
}
