using GerenciadorComprasApi.Data;
using GerenciadorComprasApi.Models.Domain;
using GerenciadorComprasApi.Models.ViewModels.Produto;
using GerenciadorComprasApi.Repositories.Produtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorComprasApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly GerenciadorDbContext context;
    private readonly IProdutoRepository produtoRepository;

    public ProdutosController(IProdutoRepository produtoRepository, GerenciadorDbContext context)
    {
        this.produtoRepository = produtoRepository;
        this.context = context; //verificar depois
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddProdutoRequest addProdutoRequest)
    {
        var produto = new Produto
        {
            Gtin = addProdutoRequest.Gtin,
            Nome = addProdutoRequest.Nome,
            Preco = addProdutoRequest.Preco,
            EstoqueDisponivel = addProdutoRequest.EstoqueDisponivel,
            CotaMinima = addProdutoRequest.CotaMinima
        };
        await produtoRepository.AddAsync(produto);

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> List()
    {
        var produtos = await produtoRepository.GetAllAsync();

        return Ok(produtos);
    }

    [HttpGet("{gtin}")]
    public async Task<IActionResult> Get(string gtin)
    {
        var produto = await produtoRepository.GetAsync(gtin);

        if (produto != null)
        {
            return Ok(produto);
        }

        return NotFound();
    }


    //[HttpPut("{gtin}")]
    //public async Task<IActionResult> Edit(string gtin, [FromBody] EditProdutoRequest getProduto)
    //{
    //    try { 
    //        var produto = new Produto
    //        {
    //            Gtin = getProduto.Gtin,
    //            Nome = getProduto.Nome,

    //            Preco = getProduto.Preco,
    //            EstoqueDisponivel = getProduto.EstoqueDisponivel,
    //            CotaMinima = getProduto.CotaMinima
    //        };
    //        var req = await produtoRepository.GetAsync(gtin);

    //        var updateProduto = await produtoRepository.UpdateAsync(produto);

    //        if (updateProduto == null)
    //        {
    //            return BadRequest();
    //        }

    //            return Ok(updateProduto);

    //        }
    //    catch (KeyNotFoundException)
    //    {
    //        return NotFound();
    //    }
    //}

    [HttpPut("{gtin}")]
    [ActionName("Edit")]
    public ActionResult Put(string gtin, [FromBody] Produto produto)
    {
        if (gtin != produto.Gtin)
        {
            return BadRequest();
        }

        context.Entry(produto).State = EntityState.Modified;
        context.SaveChanges();
        return Ok();
    }

    [HttpDelete("{gtin}")]
    public async Task<IActionResult> Delete(string gtin)
    {
        var deleteProduto = await produtoRepository.DeleteAsync(gtin);

        if (deleteProduto == null)
        {
            return NotFound();
        }

        return Ok();
    }
}