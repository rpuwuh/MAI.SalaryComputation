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

            var result = new CurriculumModel
            {
                CurriculumNumber = _numberRegex.Replace(document.GetStringOfDefault("/html[1]/body[1]/table[1]/tr[3]/td[3]"), string.Empty),
                GraduatingDepartment = document.GetStringOfDefault("/html[1]/body[1]/table[1]/tr[2]/td[3]"),
                Department = document.GetStringOfDefault("/html[1]/body[1]/table[3]/tr[2]/td[4]"),
                Faculty = document.GetNumberOrDefault("/html[1]/body[1]/table[3]/tr[2]/td[5]"),
                Course = document.GetNumberOrDefault("/html[1]/body[1]/table[3]/tr[2]/td[6]"),
                Semester = document.GetNumberOrDefault("/html[1]/body[1]/table[3]/tr[2]/td[7]"),
                Direction = document.GetStringOfDefault("/html[1]/body[1]/table[3]/tr[2]/td[8]"),
                Profile = document.GetStringOfDefault("/html[1]/body[1]/table[3]/tr[2]/td[9]"),
                GroupsCount = document.GetNumberOrDefault("/html[1]/body[1]/table[3]/tr[2]/td[10]"),
                StudentsCount = document.GetNumberOrDefault("/html[1]/body[1]/table[3]/tr[2]/td[11]"),
                GroupNumbers = document.GetCollectionOfChildElements("/html[1]/body[1]/table[3]/tr[2]/td[12]"),
                WeekCount = document.GetNumberOrDefault("/html[1]/body[1]/table[3]/tr[2]/td[14]")
            };

            var disciplineTableRows = document.DocumentNode.SelectSingleNode("/html[1]/body[1]/table[5]")?.ChildNodes;

            if (disciplineTableRows != null)
            {
                foreach (var tableRow in disciplineTableRows)
                {
                    var number = tableRow.GetNumberOrDefault("./td[2]");

                    if (!number.HasValue)
                    {
                        continue;
                    }

                    var curriculumDiscipline = new CurriculumDisciplineModel
                    {
                        Number = tableRow.GetStringOfDefault("./td[2]"),
                        Name = tableRow.GetStringOfDefault("./td[3]"),
                        SupportingDepartment = tableRow.GetStringOfDefault("./td[4]"),
                        Flow = tableRow.GetNumberOrDefault("./td[5]"),
                        FlowAttribute = tableRow.GetStringOfDefault("./td[6]"),
                        CountOfLecture = tableRow.GetNumberOrDefault("./td[10]") ?? 0,
                        CountOfLaboratoryLessons = tableRow.GetNumberOrDefault("./td[11]") ?? 0,
                        CountOfPracticalLessons = tableRow.GetNumberOrDefault("./td[12]") ?? 0,
                        CountOfCourseProjects = tableRow.GetNumberOrDefault("./td[14]") ?? 0,
                        CountOfCourseWorks = tableRow.GetNumberOrDefault("./td[15]") ?? 0,
                        CountOfCalculationAndGraphicWorks = tableRow.GetNumberOrDefault("./td[16]") ?? 0,
                        CountOfHomeWorks = tableRow.GetNumberOrDefault("./td[17]") ?? 0,
                        ControlType = tableRow.GetStringOfDefault("./td[24]"),
                    };

                    result.Disciplines.Add(curriculumDiscipline);
                }
            }

            var flowTableRows = document.DocumentNode.SelectSingleNode("/html[1]/body[1]/table[6]")?.ChildNodes;

            if (flowTableRows != null)
            {
                foreach (var tableRow in flowTableRows)
                {
                    var number = tableRow.GetNumberOrDefault("./td[2]");

                    if (!number.HasValue)
                    {
                        continue;
                    }

                    var curriculumFlow = new CurriculumFlowModel();

                    var flowGroups = tableRow.GetStringOfDefault("./td[3]")
                        .Split(',', StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => x.Trim())
                        .ToList();

                    curriculumFlow.FlowNumber = number.Value;
                    curriculumFlow.GroupNumbers = flowGroups;

                    result.Flows.Add(curriculumFlow);
                }
            }

            return result;
        }
    }
}