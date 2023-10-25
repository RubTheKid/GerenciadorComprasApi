using GerenciadorComprasApi.Models.Domain;

namespace GerenciadorComprasApi.Repositories.Produtos;

public interface IProdutoRepository
{
    Task<IEnumerable<Produto>> GetAllAsync();
    Task<Produto> GetAsync(Guid id);
    Task<Produto> AddAsync(Produto produto);
    Task<Produto> UpdateAsync(Produto produto);
    Task<Produto> DeleteAsync(Guid id);
}
