using AbstractShipyardDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;


namespace AbstractShipyardDatabaseImplement
{
    public class AbstractShipyardDatabase : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Data Source=is-431-13\SQLEXPRESS;Initial Catalog=AbstractShipyardDatabase1;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Component> Components { set; get; }
        public virtual DbSet<Product> Products { set; get; }
        public virtual DbSet<ProductComponent> ProductComponents { set; get; }
        public virtual DbSet<Order> Orders { set; get; }
    }

}
