using GerenciadorComprasApp.Models;
using GerenciadorComprasApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
//using Newtonsoft.Json;
using System.Net.Http;

namespace GerenciadorComprasApp.Controllers;

public class ProdutosController : Controller
{
    private readonly IProdutoService _produtoService;

    public ProdutosController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    public async Task<IActionResult> List()
    {
        IEnumerable<Produto> produtos = await _produtoService.GetProdutosAsync();
        return View(produtos);
    }

    public async Task<IActionResult> Add()
    {
        return View();
    }

    public async Task<IActionResult> AddProduto(Produto novoProduto)
    {
        var response = await _produtoService.AddProdutoAsync(novoProduto);
        if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            return View("Add", novoProduto);
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _produtoService.DeleteAsync(id);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction("List");
        }
        else
        {
            var error = await response.Content.ReadAsStringAsync();
            return View("Edit", id);
        }
    }


    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        // Recupere o produto existente da API usando seu ID
        string apiUrl = $"https://localhost:7119/api/produtos/{id}";

        using (var client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var produtoJson = await response.Content.ReadAsStringAsync();
                var produtoExistente = JsonSerializer.Deserialize<Produto>(produtoJson);

                
                return View("Edit",produtoExistente);
            }
            else
            {
                
                return RedirectToAction("List"); // Redirecione para a lista de produtos ou uma página de erro
            }
        }
    }

    [HttpPut]
    public async Task<IActionResult> Edit(Produto produto)
    {
        string apiUrl = $"https://localhost:7119/api/produtos/{produto.id}";

        // Serializa o produto atualizado para JSON
        var produtoJson = JsonSerializer.Serialize(produto);
        var content = new StringContent(produtoJson, Encoding.UTF8, "application/json");

        using (var client = new HttpClient())
        {
            // Faz a solicitação HTTP PUT para atualizar o produto
            var response = await client.PutAsync(apiUrl, content);
            var error = await response.Content.ReadAsStringAsync();
            Console.WriteLine(error);

            if (response.IsSuccessStatusCode)
            {
                // Se a atualização for bem-sucedida, redirecione para a lista de produtos
                return RedirectToAction("List");
            }
            else
            {
                // Trate o erro, talvez redirecionando para uma página de erro
                
                Console.WriteLine(error);
                return View("Edit", produto); // Volte para a view de edição com o modelo
            }
        }
    }

    

}