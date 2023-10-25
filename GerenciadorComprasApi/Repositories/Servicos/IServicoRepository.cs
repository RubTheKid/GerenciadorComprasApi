using GerenciadorComprasApi.Models.Domain;

namespace GerenciadorComprasApi.Repositories.Servicos
{
    public interface IServicoRepository
    {
        Task<IEnumerable<Servico>> GetAllAsync();
        Task<Servico> GetAsync(Guid id);
        Task<Servico> AddAsync(Servico servico);
        Task<Servico> UpdateAsync(Servico servico);
        Task<Servico> DeleteAsync(Guid id);
    }
}
