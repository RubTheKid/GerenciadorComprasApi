﻿using GerenciadorComprasApi.Data;
using GerenciadorComprasApi.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorComprasApi.Repositories.Empresas;

public class EmpresaRepository : IEmpresaRepository
{
    private readonly GerenciadorDbContext dbContext;

    public EmpresaRepository(GerenciadorDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<Empresa>> GetAllAsync()
    {
        return await dbContext.Empresas.ToListAsync();
    }

    public async Task<Empresa?> GetAsync(string cnpj)
    {
        return await dbContext.Empresas.FirstOrDefaultAsync(x => x.Cnpj == cnpj);
    }

    public async Task<Empresa> AddAsync(Empresa empresa)
    {
        await dbContext.Empresas.AddAsync(empresa);
        await dbContext.SaveChangesAsync();

        return empresa;
    }
    public async Task<Empresa?> UpdateAsync(Empresa empresa)
    {
        var empresaCadastrada = await dbContext.Empresas.FindAsync(empresa.Cnpj);

        if (empresaCadastrada != null)
        {
            empresaCadastrada.Cnpj = empresa.Cnpj;
            empresaCadastrada.Email = empresa.Email;
            empresaCadastrada.InscricaoEstadual = empresa.InscricaoEstadual;
            empresaCadastrada.InscricaoMunicipal = empresa.InscricaoMunicipal;

            await dbContext.SaveChangesAsync();

            return empresaCadastrada;
        }
        return null;
    }

    public async Task<Empresa?> DeleteAsync(string cnpj)
    {
        var empresaCadastrada = await dbContext.Empresas.FindAsync(cnpj);

        if (empresaCadastrada != null)
        {
            dbContext.Empresas.Remove(empresaCadastrada);
            await dbContext.SaveChangesAsync();

            return empresaCadastrada;
        }
        return null;
    }

    public async Task<Empresa> GetByCnpjAsync(string cnpj)
    {
        return await dbContext.Empresas.FirstOrDefaultAsync(e => e.Cnpj == cnpj);
    }


}
