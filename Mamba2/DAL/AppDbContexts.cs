using Mamba2.Models;
using Microsoft.EntityFrameworkCore;

namespace Mamba2.DAL;

public class AppDbContexts : DbContext
{
    public AppDbContexts(DbContextOptions options):base(options)
    {
        
    }
    public DbSet<Category> Categories {  get; set; }
    public DbSet<Portfolio> Portfolios {  get; set; }

}
