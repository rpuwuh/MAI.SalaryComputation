using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mai.SalaryComputation.Domain.Entities;

namespace Mai.SalaryComputation.Domain.Abstractions
{
    public interface IApplicationDbContext
    {
        IQueryable<ProcessedFile> ProcessedFiles { get; }

        Task AddEntityAsync<T>(T value);

        Task AddEntitiesAsync<T>(IEnumerable<T> values);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}