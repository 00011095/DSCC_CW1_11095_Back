using DSCC_CW1_11095_Back.Models;
using Microsoft.EntityFrameworkCore;

namespace DSCC_CW1_11095_Back.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
        }

        public DbSet<Producer> Producers { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Producer)
                .WithMany(pr => pr.Products)
                .HasForeignKey(p => p.ProducerId);
        }
    }
}
