using System;
using System.Collections.Generic;

namespace Mai.SalaryComputation.Domain.Entities
{
    /// <summary>
    /// Поток.
    /// </summary>
    public class Flow
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Код потока.
        /// </summary>
        public string Code { get; set; } = default!;

        /// <summary>
        /// Группы потока.
        /// </summary>
        public virtual ICollection<Group> Groups { get; set; }

        /// <summary>
        /// Дисциплины учебного плана.
        /// </summary>
        public virtual ICollection<CurriculumDiscipline> CurriculumDisciplines { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<FlowGroup> FlowGroups { get; set; } = new HashSet<FlowGroup>();
    }
}