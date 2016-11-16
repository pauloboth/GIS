using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;


namespace Entity
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
            : base("name=PostgresConnection")
        {
            //Database.SetInitializer<MyDbContext>(null);
        }

        public DbSet<Position> Positions { get; set; }
        public DbSet<Area> Areas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }

    }
}