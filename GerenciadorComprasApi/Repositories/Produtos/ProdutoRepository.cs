using GerenciadorComprasApi.Data;
using GerenciadorComprasApi.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorComprasApi.Repositories.Produtos;

public class ProdutoRepository : IProdutoRepository
{
    private readonly GerenciadorDbContext dbContext;
    public ProdutoRepository(GerenciadorDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<Produto>> GetAllAsync()
    {
        return await dbContext.Produtos.ToListAsync();
    }

    public async Task<Produto?> GetAsync(string gtin)
    {
        return await dbContext.Produtos.FirstOrDefaultAsync(x => x.Gtin == gtin);
    }

    public async Task<Produto> AddAsync(Produto produto)
    {
        await dbContext.Produtos.AddAsync(produto);
        await dbContext.SaveChangesAsync();

        return produto;
    }
    public async Task<Produto?> UpdateAsync(Produto produto)
    {
        var produtoCadastrado = await dbContext.Produtos.FindAsync(produto.Gtin);

        if (produtoCadastrado == null)
        {
            throw new KeyNotFoundException("Produto não encontrado");
        }
        produtoCadastrado.Gtin = produto.Gtin;
        produtoCadastrado.Nome = produto.Nome;
            produtoCadastrado.Preco = produto.Preco;
            produtoCadastrado.EstoqueDisponivel = produto.EstoqueDisponivel;
            produtoCadastrado.CotaMinima = produto.CotaMinima;

            await dbContext.SaveChangesAsync();

            return produtoCadastrado;
    }


    public async Task<Produto?> DeleteAsync(string gtin)
    {
        var produtoCadastrado = await dbContext.Produtos.FindAsync(gtin);

        if (produtoCadastrado == null)
        {
            throw new Exception("Produto não encontrado");
        }

        dbContext.Produtos.Remove(produtoCadastrado);
        await dbContext.SaveChangesAsync();

        return produtoCadastrado;

    }

}
