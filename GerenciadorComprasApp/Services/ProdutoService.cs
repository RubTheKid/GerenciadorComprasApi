using GerenciadorComprasApp.Models;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace GerenciadorComprasApp.Services;

public class ProdutoService : IProdutoService
{
    private readonly HttpClient _client;

    public ProdutoService(HttpClient client)
    {
        
        
        _client = client;
    }

    public async Task<IEnumerable<Produto>> GetProdutosAsync()
    {
       var response = await _client.GetAsync("api/produtos/");


        if (response.IsSuccessStatusCode)
        {
            var produtosJson = await response.Content.ReadAsStringAsync();
            var produtos = JsonSerializer.Deserialize<IEnumerable<Produto>>(produtosJson);
            return produtos;
        }

        return null;
    }

    public async Task<Produto> AddAsync(Produto produto)
    {
        var response = await _client.PostAsJsonAsync("api/produtos", produto);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Produto>();
        }

        throw new Exception("Falha ao adicionar o produto.");
    }



}
