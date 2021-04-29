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

        private readonly IProcessedFileService _processedFileService;

        private readonly AppConfig _appConfig;

        private readonly JsonSerializerSettings _serializerSettings;

        public Application(ILogger<Application> logger,
            IScheduleParser scheduleParser,
            ICurriculumParser curriculumParser,
            IProcessedFileService processedFileService,
            IOptions<AppConfig> appConfig)
        {
            _logger = logger;
            _scheduleParser = scheduleParser;
            _curriculumParser = curriculumParser;
            _processedFileService = processedFileService;
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

            var excelFiles = GetFilesWithExt(_appConfig.InputPath, ".xlsx", ".xls").ToList();

            _logger.LogInformation($"Count of schedules files is {excelFiles.Count}");

            foreach (var excelFile in excelFiles)
            {
                try
                {
                    _logger.LogInformation($"Parsing {excelFile} file");

                    await using var fs = new FileStream(excelFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                    var isContains = await _processedFileService.Contains(fs);

                    if (isContains)
                    {
                        _logger.LogInformation("Skipped..");

                        continue;
                    }

                    if (fs.CanSeek)
                    {
                        fs.Seek(0, SeekOrigin.Begin);
                    }
                    
                    var parserResult = _scheduleParser.Execute(fs);

                    var json = JsonConvert.SerializeObject(parserResult, Formatting.None, _serializerSettings);

                    _logger.LogInformation(json);

                    await SaveJsonFile(_appConfig.OutputPath, "Schedule", excelFile, json);
                    
                    if (fs.CanSeek)
                    {
                        fs.Seek(0, SeekOrigin.Begin);
                    }

                    await _processedFileService.Add(fs, json);
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

            var htmlFiles = GetFilesWithExt(_appConfig.InputPath, ".htm").ToList();

            _logger.LogInformation($"Count of curriculums files is {htmlFiles.Count}");

            foreach (var htmlFile in htmlFiles)
            {
                _logger.LogInformation($"Parsing {htmlFile} file");

                try
                {
                    await using var fs = new FileStream(htmlFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    
                    var isContains = await _processedFileService.Contains(fs);
                    
                    if (isContains)
                    {
                        _logger.LogInformation("Skipped..");
                    
                        continue;
                    }
                    
                    if (fs.CanSeek)
                    {
                        fs.Seek(0, SeekOrigin.Begin);
                    }

                    var html = await fs.ReadAsStringAsync();

                    var parserResult = _curriculumParser.Execute(html);

                    var json = JsonConvert.SerializeObject(parserResult, Formatting.None, _serializerSettings);

                    _logger.LogInformation(json);

                    await SaveJsonFile(_appConfig.OutputPath, "Curriculum", htmlFile, json);

                     if (fs.CanSeek)
                     {
                         fs.Seek(0, SeekOrigin.Begin);
                     }

                    await _processedFileService.Add(fs, json);
                }
                catch (Exception e)
                {
                    _logger.LogCritical($"Error when parsing curriculum file {htmlFile}", e);
                }
            }
        }

        public static IEnumerable<string> GetFilesWithExt(string path, params string[] ext)
        {
            return Directory.GetFiles(path, "*.*", SearchOption.AllDirectories)
                .Where(s => !ext.Any() || ext.Any(s.EndsWith))
                .ToArray();
        }

        public static Task SaveJsonFile(string path, string prefix, string fileName, string json)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var name = $"{prefix}_[{DateTime.Now:dd-MM-yyyy_hh-mm-ss-tt}]_[{Path.GetFileNameWithoutExtension(fileName)}].json";

            return File.WriteAllTextAsync(Path.Combine(path, name), json, Encoding.UTF8);
        }
    }
}