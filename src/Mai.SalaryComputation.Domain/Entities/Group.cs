using System;
using System.Collections.Generic;

namespace Mai.SalaryComputation.Domain.Entities
{
    /// <summary>
    /// Группа.
    /// </summary>
    public class Group
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название группы.
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// Количество учащихся.
        /// </summary>
        public uint StudentsCount { get; set; }

        /// <summary>
        /// Факультет.
        /// </summary>
        public string Faculty { get; set; } = default!;

        /// <summary>
        /// Курс.
        /// </summary>
        public uint Course { get; set; }

        /// <summary>
        /// Учебные планы группы.
        /// </summary>
        public virtual ICollection<Curriculum> Curriculums { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<CurriculumGroup> CurriculumGroups { get; set; } = new HashSet<CurriculumGroup>();

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<FlowGroup> FlowGroups { get; set; } = new HashSet<FlowGroup>();

        /// <summary>
        /// Потоки группы.
        /// </summary>
        public virtual ICollection<Flow> Flows { get; set; }
    }
    
}