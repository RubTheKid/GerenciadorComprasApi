using GerenciadorComprasApp.Models;
using GerenciadorComprasApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using Newtonsoft.Json;

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

    public async Task<IActionResult> Add(Produto produto)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _produtoService.AddAsync(produto);
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Falha ao adicionar o produto: " + ex.Message);
            }
        }

}
