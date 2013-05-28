using System.Data.Entity;

namespace POS.DAL
{
    class MyContext : DbContext
    {
        public MyContext()
            :base("MyConnectionString")
        {
        }

        public DbSet<Product> Products { get; set; } 
    }
}