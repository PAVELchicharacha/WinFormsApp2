using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace WinFormsApp1
{
    public class DataBaseContext : DbContext
    {
        public DbSet<DataBaseModel> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=database0;Trusted_Connection=True;TrustServerCertificate=True;").LogTo(message => Debug.WriteLine(message));
        }
    }
}