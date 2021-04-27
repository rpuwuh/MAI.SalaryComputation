using System;
using System.Collections.Generic;

namespace Mai.SalaryComputation.Domain.Entities
{
    /// <summary>
    /// Дисциплина учебного плана.
    /// </summary>
    public class CurriculumDiscipline
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор учебного плана.
        /// </summary>
        public Guid CurriculumId { get; set; }

        /// <summary>
        /// Идентификатор дисциплины.
        /// </summary>
        public Guid DisciplineId { get; set; }

        /// <summary>
        /// Идентификатор потока.
        /// </summary>
        public Guid? FlowId { get; set; }

        /// <summary>
        /// Код обеспечивающей кафедры.
        /// </summary>
        public string DepartmentCode { get; set; } = default!;

        /// <summary>
        /// Учебный план.
        /// </summary>
        public virtual Curriculum Curriculum { get; set; }

        /// <summary>
        /// Дисциплина.
        /// </summary>
        public virtual Discipline Discipline { get; set; }

        /// <summary>
        /// Поток по дисциплине.
        /// </summary>
        public virtual Flow Flow { get; set; }
        
        //todo:
        public virtual ICollection<Group> Groups { get; set; }

        /// <summary>
        /// Аудиторное время.
        /// </summary>
        public virtual ICollection<DisciplineClassroom> Classrooms { get; set; }

        /// <summary>
        /// Самостоятельные работы студентов.
        /// </summary>
        public virtual ICollection<DisciplineIndependentWork> IndependentWorks { get; set; }
    }
}