using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options ) : base( options )
    {           
    }

    public DbSet<Pedido>? Pedidos { get; set; }
    public DbSet<Produto>? Produtos { get; set; }
}
