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

    public async Task<Produto?> GetAsync(Guid id)
    {
        return await dbContext.Produtos.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Produto> AddAsync(Produto produto)
    {
        await dbContext.Produtos.AddAsync(produto);
        await dbContext.SaveChangesAsync();

        return produto;
    }
    public async Task<Produto?> UpdateAsync(Produto produto)
    {
        var produtoCadastrado = await dbContext.Produtos.FindAsync(produto.Id);

        if (produtoCadastrado == null)
        {
            throw new KeyNotFoundException("Produto não encontrado");
        }
            produtoCadastrado.Nome = produto.Nome;
            produtoCadastrado.Gtin = produto.Gtin;
            produtoCadastrado.Preco = produto.Preco;
            produtoCadastrado.EstoqueDisponivel = produto.EstoqueDisponivel;
            produtoCadastrado.CotaMinima = produto.CotaMinima;

            await dbContext.SaveChangesAsync();

            return produtoCadastrado;
    }


    public async Task<Produto?> DeleteAsync(Guid id)
    {
        var produtoCadastrado = await dbContext.Produtos.FindAsync(id);

        if (produtoCadastrado == null)
        {
            throw new Exception("Produto não encontrado");
        }

        dbContext.Produtos.Remove(produtoCadastrado);
        await dbContext.SaveChangesAsync();

        return produtoCadastrado;

    }

}
