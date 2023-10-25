using GerenciadorComprasApp.Models;
using System.Text.Json;

namespace GerenciadorComprasApp.Services;

public class ProdutoService : IProdutoService
{
    private readonly HttpClient _httpClient;

    public ProdutoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Produto>> GetProdutosAsync()
    {
        var response = await _httpClient.GetAsync("/api/produtos");

        if (response.IsSuccessStatusCode)
        {
            var produtosJson = await response.Content.ReadAsStringAsync();
            var produtos = JsonSerializer.Deserialize<IEnumerable<Produto>>(produtosJson);
            return produtos;
        }

        return null;
    }
}
