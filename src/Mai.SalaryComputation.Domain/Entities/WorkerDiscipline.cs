using System;

namespace Mai.SalaryComputation.Domain.Entities
{
    /// <summary>
    /// Дисциплина которую ведет работник.
    /// </summary>
    public class WorkerDiscipline
    {
        /// <summary>
        /// Идентификатор работника.
        /// </summary>
        public Guid WorkerId { get; set; }

        /// <summary>
        /// Идентификатор дисциплины.
        /// </summary>
        public Guid DisciplineId { get; set; }

        /// <summary>
        /// Работник.
        /// </summary>
        public virtual Worker Worker { get; set; }
        
        /// <summary>
        /// Дисциплина.
        /// </summary>
        public virtual Discipline Discipline { get; set; }
    }
}