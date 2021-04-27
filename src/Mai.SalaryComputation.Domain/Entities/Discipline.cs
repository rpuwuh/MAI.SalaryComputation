using System;
using System.Collections.Generic;

namespace Mai.SalaryComputation.Domain.Entities
{
    /// <summary>
    /// Дисциплина.
    /// </summary>
    public class Discipline
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название дисциплины.
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// Альтернативное название дисциплины.
        /// </summary>
        public string AlternativeName { get; set; } = default!;

        /// <summary>
        /// Преподователи ведущии дисциплину.
        /// </summary>
        public virtual ICollection<Worker> Workers { get; set; } = new HashSet<Worker>();
        
        /// <summary>
        /// Преподователи по дисциплине.
        /// </summary>
        public virtual ICollection<WorkerDiscipline> WorkerDisciplines { get; set; } = new HashSet<WorkerDiscipline>();
        
        /// <summary>
        /// Учебные планы по дисциплине.
        /// </summary>
        public virtual ICollection<CurriculumDiscipline> CurriculumDisciplines { get; set; } = new HashSet<CurriculumDiscipline>();
    }
}