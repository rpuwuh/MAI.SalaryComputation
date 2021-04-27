using System.Collections.Generic;

namespace Mai.SalaryComputation.Domain.Models.Curriculum
{
    public class CurriculumFlowModel
    {
        /// <summary>
        /// Номер потока.
        /// </summary>
        public int FlowNumber { get; set; }

        /// <summary>
        /// Номера групп.
        /// </summary>
        public ICollection<string> GroupNumbers { get; set; } = new List<string>();
    }
}