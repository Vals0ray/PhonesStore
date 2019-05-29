using System.Data.Entity;

namespace SQLiteApp
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DbConnection") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Phone> Phones { get; set; }
    }
}