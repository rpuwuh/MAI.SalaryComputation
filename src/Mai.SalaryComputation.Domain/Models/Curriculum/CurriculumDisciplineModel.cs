namespace Mai.SalaryComputation.Domain.Models.Curriculum
{
    public class CurriculumDisciplineModel
    {
        /// <summary>
        /// Номер дисциплины.
        /// </summary>
        public string? Number { get; set; }

        /// <summary>
        /// Наименование дисциплины.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Обеспечивающая кафедра.
        /// </summary>
        public string? SupportingDepartment { get; set; }

        /// <summary>
        /// Поток.
        /// </summary>
        public int? Flow { get; set; }

        /// <summary>
        /// Признак потока.
        /// </summary>
        public string? FlowAttribute { get; set; }
    }
}