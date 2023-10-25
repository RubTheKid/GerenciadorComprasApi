using GerenciadorComprasApp.Models;
using GerenciadorComprasApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorComprasApp.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoService produtoService;

        public ProdutosController(IProdutoService produtoService)
        {
            this.produtoService = produtoService;
        }

        public async Task<IActionResult> List()
        {
            IEnumerable<Produto> produtos = await produtoService.GetProdutosAsync();
            return View(produtos);
        }
    }
}
