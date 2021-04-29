using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CodeJam.IO;
using Mai.SalaryComputation.CLI.Configs;
using Mai.SalaryComputation.Domain.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Mai.SalaryComputation.CLI
{
    public class Application
    {
        private readonly ILogger<Application> _logger;

        private readonly IScheduleParser _scheduleParser;

        private readonly ICurriculumParser _curriculumParser;

        private readonly AppConfig _appConfig;

        private readonly JsonSerializerSettings _serializerSettings;

        public Application(ILogger<Application> logger,
            IScheduleParser scheduleParser,
            ICurriculumParser curriculumParser,
            IOptions<AppConfig> appConfig)
        {
            _logger = logger;
            _scheduleParser = scheduleParser;
            _curriculumParser = curriculumParser;
            _appConfig = appConfig.Value;
            _serializerSettings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>
                {
                    new StringEnumConverter()
                },
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        public async Task Run(CancellationToken cancellationToken = default)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                if (_appConfig.ProcessSchedule)
                {
                    await ProcessSchedule();
                }

                if (_appConfig.ProcessCurriculum)
                {
                    await ProcessCurriculum();
                }

                await Task.Delay(_appConfig.Delay);
            }
        }

        public async Task ProcessSchedule()
        {
            _logger.LogInformation("Start parsing schedules");

            var excelFiles = Directory
                .GetFiles(_appConfig.InputPath, "*.*", SearchOption.AllDirectories)
                .Where(s => s.EndsWith(".xlsx") || s.EndsWith(".xls"))
                .ToList();

            _logger.LogInformation($"Count of schedules files is {excelFiles.Count}");

            foreach (var excelFile in excelFiles)
            {
                try
                {
                    _logger.LogInformation($"Parsing {excelFile} file");

                    await using var fs = new FileStream(excelFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                    var parserResult = _scheduleParser.Execute(fs);

                    var json = JsonConvert.SerializeObject(parserResult, Formatting.Indented, _serializerSettings);

                    _logger.LogInformation(json);

                    var fileMame = "schedule-" + Path.GetFileNameWithoutExtension(excelFile) +
                                   DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss-tt") + ".json";

                    await SaveFile(_appConfig.OutputPath, fileMame, json);
                }
                catch (Exception e)
                {
                    _logger.LogCritical($"Error when parsing curriculum schedule {excelFile}", e);
                }
            }
        }

        public async Task ProcessCurriculum()
        {
            _logger.LogInformation("Start parsing curriculums");

            var htmlFiles = Directory
                .GetFiles(_appConfig.InputPath, "*.*", SearchOption.AllDirectories)
                .Where(s => s.EndsWith(".htm"))
                .ToList();

            _logger.LogInformation($"Count of curriculums files is {htmlFiles.Count}");

            foreach (var htmlFile in htmlFiles)
            {
                _logger.LogInformation($"Parsing {htmlFile} file");

                try
                {
                    await using var fs = new FileStream(htmlFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                    var html = await fs.ReadAsStringAsync();

                    var parserResult = _curriculumParser.Execute(html);

                    var json = JsonConvert.SerializeObject(parserResult, Formatting.Indented, _serializerSettings);

                    _logger.LogInformation(json);
                    
                    var fileMame = "curriculum-" + Path.GetFileNameWithoutExtension(htmlFile) +
                                   DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss-tt") + ".json";

                    await SaveFile(_appConfig.OutputPath, fileMame, json);
                }
                catch (Exception e)
                {
                    _logger.LogCritical($"Error when parsing curriculum file {htmlFile}", e);
                }
            }
        }

        public static Task SaveFile(string path, string fileName, string json)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return File.WriteAllTextAsync(Path.Combine(path, fileName), json, Encoding.UTF8);
        }
    }
}