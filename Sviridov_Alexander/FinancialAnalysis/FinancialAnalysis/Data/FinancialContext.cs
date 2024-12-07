using FinancialAnalysis.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinancialAnalysis.Data
{
    public class FinancialContext : IdentityDbContext<User>
    {
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryType> CategoryTypes { get; set; }


        public FinancialContext(DbContextOptions<FinancialContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 

            modelBuilder.Entity<User>()
                .HasMany(u => u.Incomes)
                .WithOne(i => i.User)
                .HasForeignKey(i => i.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Expenses)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Incomes)
                .WithOne(i => i.Category)
                .HasForeignKey(i => i.CategoryId);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Expenses)
                .WithOne(e => e.Category)
                .HasForeignKey(e => e.CategoryId);
        }
    }
}