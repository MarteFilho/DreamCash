using DreamCash.Models;
using DreamCash.Models.Admin;
using Microsoft.EntityFrameworkCore;

namespace DreamCash
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :
            base(options)
        { }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<Investiment> Investiment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasOne(a => a.Account)
            .WithOne(a => a.User)
            .HasForeignKey<Account>(c => c.UserId);
        }
    }
}
