using System;
using System.Collections.Generic;

namespace Mai.SalaryComputation.Domain.Entities
{
    /// <summary>
    /// Ученая степень.
    /// </summary>
    public class AcademicDegree
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название ученой степени.
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// Работники.
        /// </summary>
        public virtual ICollection<Worker> Workers { get; set; } = new HashSet<Worker>();
    }
}