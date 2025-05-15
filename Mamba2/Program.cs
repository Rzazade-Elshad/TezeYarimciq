using Mamba2.DAL;
using Microsoft.EntityFrameworkCore;

namespace Mamba2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContexts>(opt =>opt.UseSqlServer(@"Server=DESKTOP-0HH3DC0\SQLEXPRESS;Database=PrtfolioDb;Trusted_Connection=True;TrustServerCertificate=true"));
            var app = builder.Build();
            app.UseStaticFiles();

            app.MapControllerRoute(
            name: "area",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
          );

            app.MapControllerRoute(
                name:"Default",
                pattern:"{controller=home}/{action=index}"
                );
            app.Run();
        }
    }
}
