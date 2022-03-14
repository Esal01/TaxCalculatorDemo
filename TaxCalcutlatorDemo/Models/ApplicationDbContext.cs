using Microsoft.EntityFrameworkCore;

namespace TaxCalculatorDemo.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
            Database.EnsureCreated();   
        }

        public DbSet<Municipality> Municipalities { get; set;}
        public DbSet<TaxCalculationRule> TaxCalculationRules { get; set; }
        public DbSet<TaxPeriod> TaxPeriods { get; set; }
    }
}
