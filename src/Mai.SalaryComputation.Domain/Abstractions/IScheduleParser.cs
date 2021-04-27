using System.Collections.Generic;
using System.IO;
using Mai.SalaryComputation.Domain.Models;
using Mai.SalaryComputation.Domain.Models.Schedule;

namespace Mai.SalaryComputation.Domain.Abstractions
{
    public interface IScheduleParser
    {
        ICollection<ScheduleModel> Execute(FileStream source);
    }
}