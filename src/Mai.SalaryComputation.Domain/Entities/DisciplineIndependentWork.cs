using System;
using Mai.SalaryComputation.Domain.Types;

namespace Mai.SalaryComputation.Domain.Entities
{
    /// <summary>
    /// Самостоятельная работа по дисциплине.
    /// </summary>
    public class DisciplineIndependentWork
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор диспциплины по учебному плану.
        /// </summary>
        public Guid CurriculumDisciplineId { get; set; }

        /// <summary>
        /// Колличество самостоятельных работ.
        /// </summary>
        public uint Count { get; set; }

        /// <summary>
        /// Тип самостоятельной работы.
        /// </summary>
        public IndependentWorkType Type { get; set; }

        /// <summary>
        /// Диспциплина по учебному плану.
        /// </summary>
        public virtual CurriculumDiscipline CurriculumDiscipline { get; set; }
    }
}