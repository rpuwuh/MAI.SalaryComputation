using System;

namespace Mai.SalaryComputation.Domain.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class CurriculumGroup
    {
        /// <summary>
        /// Идентификатор учебного плана.
        /// </summary>
        public Guid CurriculumId { get; set; }

        /// <summary>
        /// Идентификатор группы.
        /// </summary>
        public Guid GroupId { get; set; }

        /// <summary>
        /// Учебный план.
        /// </summary>
        public virtual Curriculum Curriculum { get; set; }

        /// <summary>
        /// Группа.
        /// </summary>
        public virtual Group Group { get; set; }
    }
}