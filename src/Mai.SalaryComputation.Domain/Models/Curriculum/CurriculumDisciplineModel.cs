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
        
        /// <summary>
        /// Количество лекций.
        /// </summary>
        public int? CountOfLecture { get; set; }
        
        /// <summary>
        /// Количество лабораторных работ.
        /// </summary>
        public int? CountOfLaboratoryLessons { get; set; }
        
        /// <summary>
        /// Количество практических занятий.
        /// </summary>
        public int? CountOfPracticalLessons { get; set; }
        
        /// <summary>
        /// Количество курсовых проектов.
        /// </summary>
        public int? CountOfCourseProjects { get; set; }
        
        /// <summary>
        /// Количество курсовых работ.
        /// </summary>
        public int? CountOfCourseWorks { get; set; }
        
        /// <summary>
        /// Количество РГР.
        /// </summary>
        public int? CountOfCalculationAndGraphicWorks { get; set; }
        
        /// <summary>
        /// Количество домашних заданий.
        /// </summary>
        public int? CountOfHomeWorks { get; set; }
        
        /// <summary>
        /// Вид контроля.
        /// </summary>
        public string? ControlType { get; set; }
    }
}