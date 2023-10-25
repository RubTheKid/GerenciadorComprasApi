using GerenciadorComprasApp.Models;

namespace GerenciadorComprasApp.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> GetProdutosAsync();
        //Task<Produto> AddAsync(Produto produto);

        Task<HttpResponseMessage> PostAsync(string url, HttpContent content);
    }
}
