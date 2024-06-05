using ManagerBook.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ManagerBook.Infrastructure
{
    public class ManagerBookDbContext : DbContext
    {
        public ManagerBookDbContext(DbContextOptions<ManagerBookDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
