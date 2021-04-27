using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml.Packaging;
using Mai.SalaryComputation.Domain.Abstractions;
using Mai.SalaryComputation.Domain.Models;
using Mai.SalaryComputation.Domain.Models.Schedule;
using Mai.SalaryComputation.Domain.Types;
using Tokens;

namespace Mai.SalaryComputation.Infrastructure.Services
{
    public class ExcelScheduleParser : IScheduleParser
    {
        #region Regexes

        private readonly Regex _scheduleItemRegex = new Regex(@"(?:^|\n)(([А-ЯЁа-яё,]|(\s))*),(\s{0,1})(((л[А-ЯЁа-яё]*)|(р[А-ЯЁа-яё]*)|(п[А-ЯЁа-яё]*)|(з[А-ЯЁа-яё]*)|(к[А-ЯЁа-яё]*)|(\s))*)(\r\n|\r|\n|\s)([А-ЯЁа-яёa-zA-Z]*)(\s{0,1})([А-ЯЁа-яёa-zA-Z]{0,1})(\.{0,1})([А-ЯЁа-яёa-zA-Z]{0,1})(\.{0,1})", RegexOptions.Compiled);

        private readonly Regex _spaceRegex = new Regex(@"\s+", RegexOptions.Compiled);

        private readonly Regex _groupNameRegex = new Regex(@"(М|М).*(-)([А-ЯЁа-яёa-zA-Z0-9-]*)", RegexOptions.Compiled);

        private readonly Regex _fullNameRegex = new Regex(@"([А-ЯЁа-яёa-zA-Z]*)(\s{0,1})([А-ЯЁа-яёa-zA-Z]{0,1})(\.)([А-ЯЁа-яёa-zA-Z]{0,1})(\.{0,1})", RegexOptions.Compiled);

        #endregion

        private readonly Tokenizer _tokenizer;

        private readonly string _scheduleModelPatternWithGroup = "{GroupName:Trim()}\n{DisciplineName:Trim()}\n{DisciplineTypeName:Trim()}\n{FullName:Trim()}";

        private readonly string _scheduleModelPatternWithoutGroup = "\n{DisciplineName:Trim()}\n{DisciplineTypeName:Trim()}\n{FullName:Trim()}";

        private readonly List<string> _badWords = new List<string> { "ONLINE", "LMS", "MS", "TEAMS" };

        public ExcelScheduleParser()
        {
            _tokenizer = new Tokenizer();
        }

        public ICollection<ScheduleModel> Execute(FileStream fileStream)
        {
            using var document = SpreadsheetDocument.Open(fileStream, false);

            var table = document.WorkbookPart?.GetPartsOfType<SharedStringTablePart>()
                .FirstOrDefault()
                ?.SharedStringTable;

            var group = table?.Select(x => _groupNameRegex.Match(x.InnerText)).FirstOrDefault(x => x.Success)?.Value ??
                        string.Empty;

            var rows = table?.Select(x => x.InnerText).ToList() ?? new List<string>();

            var tableRows = rows.Select(x =>
                {
                    x = _badWords.Aggregate(x,
                        (current, badWord) => current.Replace(badWord, string.Empty,
                            StringComparison.InvariantCultureIgnoreCase));

                    return x;
                })
                .ToList();

            var matches = tableRows?
                .SelectMany(x => _scheduleItemRegex.Matches(x))
                .Where(x => !string.IsNullOrWhiteSpace(x?.Value))
                .Select(x => x.Value.Trim())
                .Select(x => x.Replace('\n', ' '))
                .Select(x => _spaceRegex.Replace(x, " "))
                .Select(x => _fullNameRegex.Replace(x, "\n" + _fullNameRegex.Match(x).Value))
                .Where(x => x.LastIndexOf(",", StringComparison.Ordinal) > 0)
                .Select(x => x.Insert(x.LastIndexOf(",", StringComparison.Ordinal), "\n"))
                .Select(x => x.Remove(x.LastIndexOf(",", StringComparison.Ordinal), 1))
                .Select(x => $"{group}\n" + x)
                .ToList();

            var pattern = string.IsNullOrWhiteSpace(group)
                ? _scheduleModelPatternWithoutGroup
                : _scheduleModelPatternWithGroup;

            var scheduleModels = matches?
                .Select(x => _tokenizer.Tokenize<ScheduleModel>(pattern, x)?.Value)
                .ToList() ?? new List<ScheduleModel>()!;

            foreach (var scheduleModel in scheduleModels)
            {
                var disciplineTypeName = scheduleModel!.DisciplineTypeName?.ToLower() ?? string.Empty;

                if (disciplineTypeName.Equals("лекция", StringComparison.InvariantCultureIgnoreCase) ||
                    disciplineTypeName.Contains("лек", StringComparison.InvariantCultureIgnoreCase))
                {
                    scheduleModel.DisciplineType = DisciplineType.Lecture;
                }
                else if (disciplineTypeName.Contains("лаборатор", StringComparison.InvariantCultureIgnoreCase) ||
                         disciplineTypeName.Contains("лр", StringComparison.InvariantCultureIgnoreCase))
                {
                    scheduleModel.DisciplineType = DisciplineType.LaboratoryWork;
                }
                else if (disciplineTypeName.Contains("практическое", StringComparison.InvariantCultureIgnoreCase) ||
                         disciplineTypeName.Contains("пр", StringComparison.InvariantCultureIgnoreCase))
                {
                    scheduleModel.DisciplineType = DisciplineType.PracticalLesson;
                }
                else if (disciplineTypeName.Contains("консультация", StringComparison.InvariantCultureIgnoreCase))
                {
                    scheduleModel.DisciplineType = DisciplineType.Consultation;
                }
                else
                {
                    scheduleModel.DisciplineType = DisciplineType.Unknown;
                }
            }

            return scheduleModels!;
        }
    }
}