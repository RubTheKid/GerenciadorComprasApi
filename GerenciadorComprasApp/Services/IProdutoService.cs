using GerenciadorComprasApp.Models;

namespace GerenciadorComprasApp.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> GetProdutosAsync();
        Task<HttpResponseMessage> AddProdutoAsync(Produto novoProduto);
        Task<HttpResponseMessage> DeleteAsync(Guid id);
    }
}
