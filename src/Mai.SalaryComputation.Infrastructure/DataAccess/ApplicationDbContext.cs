using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Mai.SalaryComputation.Domain.Abstractions;
using Mai.SalaryComputation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mai.SalaryComputation.Infrastructure.DataAccess
{
    /// <example>
    /// Create Migration :
    /// dotnet ef migrations add 'MIGRATION_NAME' -v -p Mai.SalaryComputation.Infrastructure -s Mai.SalaryComputation.CLI -o DataAccess/Migrations
    /// Update Database :
    /// dotnet ef database update -v -p Mai.SalaryComputation.Infrastructure -s Mai.SalaryComputation.CLI
    /// </example>
    public sealed class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        #region Entities Sets

        public DbSet<ProcessedFile> ProcessedFilesSet { get; set; } = default!;

        #endregion

        public IQueryable<ProcessedFile> ProcessedFiles => ProcessedFilesSet.AsQueryable();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.Migrate();
            Database.EnsureCreated();
        }

        #region Overridden Methods

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        #endregion
        
        public async Task AddEntityAsync<T>(T value)
        {
            await AddAsync(value!);
        }

        public async Task AddEntitiesAsync<T>(IEnumerable<T> values)
        {
            await AddRangeAsync(values);
        }
    }
}