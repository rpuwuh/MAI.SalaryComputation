using System;
using System.Collections.Generic;
using Mai.SalaryComputation.Domain.Types;

namespace Mai.SalaryComputation.Domain.Entities
{
    /// <summary>
    /// Работник.
    /// </summary>
    public class Worker
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; set; } = default!;

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string SecondName { get; set; } = default!;

        /// <summary>
        /// Отчество.
        /// </summary>
        public string MiddleName { get; set; } = default!;

        /// <summary>
        /// Номер телефона.
        /// </summary>
        public string Telephone { get; set; } = default!;

        /// <summary>
        /// Электронная почта.
        /// </summary>
        public string Email { get; set; } = default!;

        /// <summary>
        /// Вид занятости.
        /// </summary>
        public EmploymentType EmploymentType { get; set; }

        /// <summary>
        /// Тип программы.
        /// </summary>
        public ProgramType ProgramType { get; set; }

        /// <summary>
        /// Идентификатор ученой степень.
        /// </summary>
        public Guid? AcademicDegreeId { get; set; }

        /// <summary>
        /// Идентификатор кафедры.
        /// </summary>
        public Guid? DepartmentId { get; set; }

        /// <summary>
        /// Идентификатор должности.
        /// </summary>
        public Guid? PositionId { get; set; }

        /// <summary>
        /// Ученая степень.
        /// </summary>
        public virtual AcademicDegree AcademicDegree { get; set; }

        /// <summary>
        /// Кафедра.
        /// </summary>
        public virtual Department Department { get; set; }

        /// <summary>
        /// Должность.
        /// </summary>
        public virtual Position Position { get; set; }

        /// <summary>
        /// Дисциплины преподователя.
        /// </summary>
        public virtual ICollection<Discipline> Disciplines { get; set; } = new HashSet<Discipline>();
        
        /// <summary>
        /// Дисциплины по преподователю.
        /// </summary>
        public virtual ICollection<WorkerDiscipline> WorkerDisciplines { get; set; } = new HashSet<WorkerDiscipline>();
    }
}