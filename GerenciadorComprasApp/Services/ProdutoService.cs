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
    public async Task<HttpResponseMessage> AddProdutoAsync(Produto novoProduto)
    {
        string apiUrl = "https://localhost:7119/api/produtos/";
        
        var produtoJson = JsonSerializer.Serialize(novoProduto);
        var content = new StringContent(produtoJson, Encoding.UTF8, "application/json");

        var response = await _client.PostAsync(apiUrl, content);
        return response;
    }


    public async Task<HttpResponseMessage> DeleteAsync(string gtin)
    {
        string apiUrl = $"https://localhost:7119/api/produtos/{gtin}";
        var response = await _client.DeleteAsync(apiUrl);
        return response;
    }

}
