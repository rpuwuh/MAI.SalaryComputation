using Mai.SalaryComputation.Domain.Types;

namespace Mai.SalaryComputation.Domain.Models.Schedule
{
    public class ScheduleModel
    {
        /// <summary>
        /// ФИО преподователя.
        /// </summary>
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Название дисциплины.
        /// </summary>
        public string DisciplineName { get; set; } = string.Empty;
        
        /// <summary>
        /// Название типа дисциплины.
        /// </summary>
        public string DisciplineTypeName { get; set; } = string.Empty;

        /// <summary>
        /// Тип дисциплины.
        /// </summary>
        public DisciplineType DisciplineType { get; set; }

        /// <summary>
        /// Название группы.
        /// </summary>
        public string GroupName { get; set; } = string.Empty;
    }
}