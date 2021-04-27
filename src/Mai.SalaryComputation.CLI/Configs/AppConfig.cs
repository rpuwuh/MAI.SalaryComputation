using System;

namespace Mai.SalaryComputation.CLI.Configs
{
    public class AppConfig
    {
        public string InputPath { get; set; } = default!;

        public string OutputPath { get; set; } = default!;

        public bool ProcessSchedule { get; set; }

        public bool ProcessCurriculum { get; set; }

        public TimeSpan Delay { get; set; }
    }
}