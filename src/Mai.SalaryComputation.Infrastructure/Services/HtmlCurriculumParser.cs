using System;
using System.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using Mai.SalaryComputation.Domain.Abstractions;
using Mai.SalaryComputation.Domain.Models.Curriculum;
using Mai.SalaryComputation.Infrastructure.Extensions;

namespace Mai.SalaryComputation.Infrastructure.Services
{
    public class HtmlCurriculumParser : ICurriculumParser
    {
        private readonly Regex _numberRegex = new Regex("[^0-9]+", RegexOptions.Compiled);

        public CurriculumModel Execute(string html)
        {
            var document = new HtmlDocument();

            document.LoadHtml(html);

            var result = new CurriculumModel();

            result.GraduatingDepartment = document.GetStringOfDefault("/html/body/table[1]/tbody/tr[2]/td[3]/p/span");
            result.Department = document.GetStringOfDefault("/html/body/table[3]/tbody/tr[2]/td[4]/p/span");
            result.Faculty = document.GetNumberOrDefault("/html/body/table[3]/tbody/tr[2]/td[5]/p/span");
            result.Course = document.GetNumberOrDefault("/html/body/table[3]/tbody/tr[2]/td[6]/p/span");
            result.Semester = document.GetNumberOrDefault("/html/body/table[3]/tbody/tr[2]/td[7]/p/span");
            result.Direction = document.GetStringOfDefault("/html/body/table[3]/tbody/tr[2]/td[8]/p/span");
            result.Profile = document.GetStringOfDefault("/html/body/table[3]/tbody/tr[2]/td[9]/p/span");
            result.GroupsCount = document.GetNumberOrDefault("/html/body/table[3]/tbody/tr[2]/td[10]/p/span");
            result.StudentsCount = document.GetNumberOrDefault("/html/body/table[3]/tbody/tr[2]/td[11]/p/span");
            result.GroupNumbers = document.GetCollectionOfChildElements("/html/body/table[3]/tbody/tr[2]/td[12]");
            result.WeekCount = document.GetNumberOrDefault("/html/body/table[3]/tbody/tr[2]/td[14]/p/span");
            result.CurriculumNumber = _numberRegex.Replace(document.GetStringOfDefault("/html/body/table[1]/tbody/tr[3]/td[3]/p/span"), string.Empty);

            var disciplineTableRows = document.DocumentNode.SelectSingleNode("/html/body/table[5]/tbody").ChildNodes;

            foreach (var tableRow in disciplineTableRows)
            {
                var number = tableRow.GetNumberOrDefault("./td[2]/p/span");

                if (!number.HasValue)
                {
                    continue;
                }

                var curriculumDiscipline = new CurriculumDisciplineModel();

                curriculumDiscipline.Number = tableRow.GetStringOfDefault("./td[2]/p/span");
                curriculumDiscipline.Name = tableRow.GetStringOfDefault("./td[3]/p/span");
                curriculumDiscipline.SupportingDepartment= tableRow.GetStringOfDefault("./td[4]/p/span");
                curriculumDiscipline.Flow = tableRow.GetNumberOrDefault("./td[5]/p/span");
                curriculumDiscipline.FlowAttribute = tableRow.GetStringOfDefault("./td[6]/p/span");

                result.Disciplines.Add(curriculumDiscipline);
            }

            var flowTableRows = document.DocumentNode.SelectSingleNode("/html/body/table[6]/tbody").ChildNodes;

            foreach (var tableRow in flowTableRows)
            {
                var number = tableRow.GetNumberOrDefault("./td[2]/p/span");

                if (!number.HasValue)
                {
                    continue;
                }

                var curriculumFlow = new CurriculumFlowModel();

                var flowGroups = tableRow.GetStringOfDefault("./td[3]/p/span")
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x=>x.Trim())
                    .ToList();

                curriculumFlow.FlowNumber = number.Value;
                curriculumFlow.GroupNumbers = flowGroups;

                result.Flows.Add(curriculumFlow);
            }

            return result;
        }
    }
}