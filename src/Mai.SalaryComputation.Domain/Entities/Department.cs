using System;
using System.Collections.Generic;

namespace Mai.SalaryComputation.Domain.Entities
{
    /// <summary>
    /// Кафедра.
    /// </summary>
    public class Department
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Код кафедры.
        /// </summary>
        public string Code { get; set; } = default!;

        /// <summary>
        /// Название кафедры.
        /// </summary>
        public string Name { get; set; } = default!;
        
        /// <summary>
        /// Работники.
        /// </summary>
        public virtual ICollection<Worker> Workers { get; set; } = new HashSet<Worker>();
        
        /// <summary>
        /// Учебные планы.
        /// </summary>
        public virtual ICollection<Curriculum> Curriculums { get; set; }
    }
}