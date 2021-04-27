using Mai.SalaryComputation.Domain.Models;
using Mai.SalaryComputation.Domain.Models.Curriculum;

namespace Mai.SalaryComputation.Domain.Abstractions
{
    public interface ICurriculumParser
    {
        CurriculumModel Execute(string html);
    }
}