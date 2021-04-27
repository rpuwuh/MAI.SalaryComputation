using System;
using System.Collections.Generic;

namespace Mai.SalaryComputation.Domain.Entities
{
    /// <summary>
    /// Должность.
    /// </summary>
    public class Position
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название должности.
        /// </summary>
        public string Name { get; set; } = default!;
        
        /// <summary>
        /// Работники.
        /// </summary>
        public virtual ICollection<Worker> Workers { get; set; } = new HashSet<Worker>();
    }
}