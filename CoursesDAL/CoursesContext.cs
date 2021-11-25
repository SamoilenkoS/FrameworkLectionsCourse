using CoursesDAL.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CoursesDAL
{
    public class CoursesContext : DbContext
    {
        public DbSet<Good> Goods { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<GoodsWarehouse> GoodsWarehouses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<GoodsWarehouse>()
                .HasKey(x => new { x.GoodId, x.WarehouseId });
        }
    }
}
