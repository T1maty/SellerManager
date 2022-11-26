using Microsoft.EntityFrameworkCore;
using SellerManager.Models;

namespace SellerManager.Data
{
    public class DataClass : DbContext
    {
        public DataClass(DbContextOptions<DataClass> options) :
            base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<SellerDtO> SellersDtO { get; set; }    
    }
}
