using GerenciadorComprasApp.Models;

namespace GerenciadorComprasApp.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> GetProdutosAsync();
    }
}
