using GerenciadorComprasApi.Data;
using GerenciadorComprasApi.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorComprasApi.Repositories.Servicos;

public class ServicoRepository : IServicoRepository
{
    private readonly GerenciadorDbContext dbContext;

    public ServicoRepository(GerenciadorDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Servico> AddAsync(Servico servico)
    {
        await dbContext.Servicos.AddAsync(servico);
        await dbContext.SaveChangesAsync();

        return servico;
    }

    public async Task<Servico> DeleteAsync(Guid id)
    {
        var servicoCadastrado = await dbContext.Servicos.FindAsync(id);

        if (servicoCadastrado == null) 
        {
            throw new Exception("Serviço não encontrado");
        }
        dbContext.Servicos.Remove(servicoCadastrado);
        await dbContext.SaveChangesAsync();

        return servicoCadastrado;
        
    }

    public async Task<IEnumerable<Servico>> GetAllAsync()
    {
        return await dbContext.Servicos.ToListAsync();
    }

    public async Task<Servico> GetAsync(Guid id)
    {
        var servico = await dbContext.Servicos.FirstOrDefaultAsync(x => x.Id == id);

        if (servico == null)
        {
            throw new Exception("Serviço não encontrado com o ID especificado.");
        }

        return servico;
    }

    public async Task<Servico> UpdateAsync(Servico servico)
    {
        var servicoCadastrado = await dbContext.Servicos.FindAsync(servico.Id);

        if (servicoCadastrado == null)
        {
            throw new Exception("Serviço não encontrado");
        }
       
            servicoCadastrado.Nome = servico.Nome;
            servicoCadastrado.Descricao = servico.Descricao;
            servicoCadastrado.PrazoEntrega = servico.PrazoEntrega;

            await dbContext.SaveChangesAsync();

            return servicoCadastrado;
   
    }
}
