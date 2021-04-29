using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Mai.SalaryComputation.Domain.Abstractions;
using Mai.SalaryComputation.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mai.SalaryComputation.Infrastructure.Services
{
    public class ProcessedFileService : IProcessedFileService
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public ProcessedFileService(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Task<bool> Contains(FileStream fileStream)
        {
            using var sha = SHA512.Create();

            var hash = sha.ComputeHash(fileStream);

            var strHash = BitConverter.ToString(hash).Replace("-", "");

            return _applicationDbContext.ProcessedFiles.AnyAsync(x => x.Sha512Hash.Equals(strHash));
        }

        public async Task<Guid> Add(FileStream fileStream, string payload)
        {
            using var sha = SHA512.Create();

            var hash = sha.ComputeHash(fileStream);

            var strHash = BitConverter.ToString(hash).Replace("-", "");
            
            var processedFile = new ProcessedFile(fileStream.Name, payload, strHash);

            await _applicationDbContext.AddEntityAsync(processedFile);

            await _applicationDbContext.SaveChangesAsync();

            return processedFile.Id;
        }
    }
}