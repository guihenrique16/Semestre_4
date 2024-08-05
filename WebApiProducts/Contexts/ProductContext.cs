using Microsoft.EntityFrameworkCore;
using WebApiProducts.Domains;

namespace WebApiProducts.Contexts
{
    public class ProductContext : DbContext
    {
        public DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=NOTE02-SALA21\\SQLEXPRESS; Database=ProductsApi_Tarde; User Id = sa; pwd = Senai@134; TrustServerCertificate = true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
