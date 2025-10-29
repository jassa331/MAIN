using collageproject.Models;
using Microsoft.EntityFrameworkCore;
using MyApi.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace collageproject.DAL
{
    public class stutentdbcontext : DbContext
    {
       

        public stutentdbcontext(DbContextOptions<stutentdbcontext> options) : base(options)
        {
        }

     //   public DbSet<Product> Products { get; set; }
        public DbSet<ORDERS> Orders { get; set; }
        public DbSet<cartitem> cartitem { get; set; }
        public DbSet<LOGIN> MAIN { get; set; }
        public virtual DbSet<ActionLog> ActionLogs { get; set; }


        //  public DbSet<ProductImage> ProductImages { get; set; }

        // [NotMapped] // optional if you still need it
        // public IEnumerable<object> UserImages { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          //  modelBuilder.Entity<cartitem>().Ignore(c => c.Images);

            // ProductImage should have a key unless it’s a view or non-table data
       //     modelBuilder.Entity<ProductImage>().HasNoKey();

            modelBuilder.Entity<ORDERS>()
                .HasKey(o => o.ORDERID);

            modelBuilder.Entity<ORDERS>()
                .HasOne(o => o.CartItem)
                .WithMany()
                .HasForeignKey(o => o.CARTITEMID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
