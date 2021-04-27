using System.Collections.Generic;

namespace Mai.SalaryComputation.Domain.Models.Curriculum
{
    public class CurriculumModel
    {
        /// <summary>
        /// Выпускающая кафедра.
        /// </summary>
        public string? GraduatingDepartment { get; set; }

        /// <summary>
        /// Номер учебного плана.
        /// </summary>
        public string? CurriculumNumber { get; set; }

        /// <summary>
        /// Отделение.
        /// </summary>
        public string? Department { get; set; }

        /// <summary>
        /// Факультет.
        /// </summary>
        public int? Faculty { get; set; }

        /// <summary>
        /// Курс.
        /// </summary>
        public int? Course { get; set; }

        /// <summary>
        /// Семестр.
        /// </summary>
        public int? Semester { get; set; }

        /// <summary>
        /// Направление/Специальность.
        /// </summary>
        public string? Direction { get; set; }
        
        /// <summary>
        /// Профиль/Cпециализация.
        /// </summary>
        public string? Profile { get; set; }

        /// <summary>
        /// Количество групп.
        /// </summary>
        public int? GroupsCount { get; set; }

        /// <summary>
        /// Количество студентов.
        /// </summary>
        public int? StudentsCount { get; set; }

        /// <summary>
        /// Номера групп.
        /// </summary>
        public ICollection<string> GroupNumbers { get; set; } = new List<string>();

        /// <summary>
        /// Количество недель.
        /// </summary>
        public int? WeekCount { get; set; }

        /// <summary>
        /// Дисциплины.
        /// </summary>
        public ICollection<CurriculumDisciplineModel> Disciplines { get; set; } = new List<CurriculumDisciplineModel>();

        /// <summary>
        /// Потоки.
        /// </summary>
        public ICollection<CurriculumFlowModel> Flows { get; set; } = new List<CurriculumFlowModel>();
    }
}