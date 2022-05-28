using Microsoft.EntityFrameworkCore;

namespace Microservices.Services.Product
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Entities.Product>().HasData(new Entities.Product
            {
                ProductId = 1,
                ProductName = "Demo",
                Price = 15,
                Description = "Demo Data Desc",
                CategoryName = "Apprtizer",
                ImageUrl = ""
            });

        }

        public DbSet<Entities.Product> Products { get; set; }
    }
}
