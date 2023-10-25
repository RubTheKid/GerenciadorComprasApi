using GerenciadorComprasApi.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorComprasApi.Data;

public class GerenciadorDbContext : DbContext
{
    public GerenciadorDbContext(DbContextOptions<GerenciadorDbContext> options) : base(options) { }

    public GerenciadorDbContext() { }

    public DbSet<Empresa> Empresas { get; set; }
    //public DbSet<Estoque> Estoques { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Servico> Servicos { get; set; }
    public DbSet<User> Users { get; set; }
}
