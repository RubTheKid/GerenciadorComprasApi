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
    private readonly IProdutoRepository produtoRepository;

    public ProdutosController(IProdutoRepository produtoRepository)
    {
        this.produtoRepository = produtoRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] AddProdutoRequest addProdutoRequest)
    {
        var produto = new Produto
        {
            Nome = addProdutoRequest.Nome,
            Gtin = addProdutoRequest.Gtin,
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

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var produto = await produtoRepository.GetAsync(id);

        if (produto != null)
        {
            return Ok(produto);
        }

        return NotFound();
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Edit(Guid id, [FromBody] EditProdutoRequest getProduto)
    {
        try { 
            var produto = new Produto
            {
                Id = getProduto.Id,
                Nome = getProduto.Nome,
                Gtin = getProduto.Gtin,
                Preco = getProduto.Preco,
                EstoqueDisponivel = getProduto.EstoqueDisponivel,
                CotaMinima = getProduto.CotaMinima
            };
            var req = await produtoRepository.GetAsync(id);

            var updateProduto = await produtoRepository.UpdateAsync(produto);

            if (updateProduto == null)
            {
                return BadRequest();
            }

                return Ok(updateProduto);

            }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleteProduto = await produtoRepository.DeleteAsync(id);

        if (deleteProduto == null)
        {
            return NotFound();
        }

        return Ok();
    }
}