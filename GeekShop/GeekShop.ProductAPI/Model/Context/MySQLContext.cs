using Microsoft.EntityFrameworkCore;

namespace GeekShop.ProductAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                Name = "Name",
                Price = 12,
                Description = "Description",
                ImageURL = "teste",
                CategoryName = "Category"
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
