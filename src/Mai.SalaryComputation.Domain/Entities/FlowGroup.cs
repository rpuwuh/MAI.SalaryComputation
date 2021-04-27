using System;

namespace Mai.SalaryComputation.Domain.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class FlowGroup
    {
        /// <summary>
        /// Идентификатор потока.
        /// </summary>
        public Guid FlowId { get; set; }

        /// <summary>
        /// Идентификатор группы.
        /// </summary>
        public Guid GroupId { get; set; }

        /// <summary>
        /// Поток.
        /// </summary>
        public virtual Flow Flow { get; set; }

        /// <summary>
        /// Группа.
        /// </summary>
        public virtual Group Group { get; set; }
    }
}