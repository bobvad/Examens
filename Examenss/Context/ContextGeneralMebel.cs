using Microsoft.EntityFrameworkCore;

namespace Examenss.Context
{
    public class ContextGeneralMebel: DbContext
    {
        public DbSet<Models.Users> Users { get; set; }
        public DbSet<Models.Mebel> Mebels { get; set; }
        public DbSet<Models.Material> Materials { get; set; }
        public ContextGeneralMebel()
        {
            Database.EnsureCreated();
            Users.Load();
            Mebels.Load();
            Materials.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=127.0.0.1;port=3306;uid=root;pwd=;database=Mebel", new MySqlServerVersion(new System.Version(8,11,0)));
        }
    }
}
