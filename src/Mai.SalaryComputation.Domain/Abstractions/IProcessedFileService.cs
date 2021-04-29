using System;
using System.IO;
using System.Threading.Tasks;

namespace Mai.SalaryComputation.Domain.Abstractions
{
    public interface IProcessedFileService
    {
        Task<bool> Contains(FileStream fileStream);

        Task<Guid> Add(FileStream fileStream, string payload);
    }
}