using System;
using System.Collections.Generic;

namespace Mai.SalaryComputation.Domain.Entities
{
    /// <summary>
    /// Учебный план.
    /// </summary>
    public class Curriculum
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор кафедры.
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Код учебного плана.
        /// </summary>
        public string Code { get; set; } = default!;

        /// <summary>
        /// Факультет.
        /// </summary>
        public string Faculty { get; set; } = default!;

        /// <summary>
        /// Курс.
        /// </summary>
        public uint Course { get; set; }

        /// <summary>
        /// Семестр.
        /// </summary>
        public uint Semester { get; set; }

        /// <summary>
        /// Количество учащихся.
        /// </summary>
        public uint StudentsCount { get; set; }

        /// <summary>
        /// Количество групп.
        /// </summary>
        public uint GroupCount { get; set; }

        /// <summary>
        /// Кафедра.
        /// </summary>
        public Department Department { get; set; }

        /// <summary>
        /// Группы.
        /// </summary>
        public virtual ICollection<Group> Groups { get; set; }

        /// <summary>
        /// Дисциплины учебного плана.
        /// </summary>
        public virtual ICollection<CurriculumDiscipline> CurriculumDisciplines { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CurriculumGroup> CurriculumGroups { get; set; } = new HashSet<CurriculumGroup>();
    }
}