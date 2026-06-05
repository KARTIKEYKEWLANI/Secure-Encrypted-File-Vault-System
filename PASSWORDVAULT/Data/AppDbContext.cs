using Microsoft.EntityFrameworkCore;
using PasswordVault.Models;

namespace PasswordVault.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Credential> Credentials { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost;port=3306;database=vault_db;user=root;password=Kartik@05";
            optionsBuilder.UseMySQL(connectionString);
        }
    }
}
