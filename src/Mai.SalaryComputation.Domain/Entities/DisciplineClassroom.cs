using System;
using Mai.SalaryComputation.Domain.Types;

namespace Mai.SalaryComputation.Domain.Entities
{
    /// <summary>
    /// Аудиторное время дисциплины.
    /// </summary>
    public class DisciplineClassroom
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор диспциплины по учебному плану.
        /// </summary>
        public Guid CurriculumDisciplineId { get; set; }

        /// <summary>
        /// Время
        /// </summary>
        public TimeSpan Time { get; set; } = TimeSpan.Zero;

        /// <summary>
        /// Тип аудиторного времени.
        /// </summary>
        public ClassroomType Type { get; set; }

        /// <summary>
        /// Диспциплина по учебному плану.
        /// </summary>
        public virtual CurriculumDiscipline CurriculumDiscipline { get; set; }
    }

    /// <summary>
    /// Контроль.
    /// </summary>
    public class DisciplineControl
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор диспциплины по учебному плану.
        /// </summary>
        public Guid CurriculumDisciplineId { get; set; }

        /// <summary>
        /// Время на экзамен.
        /// </summary>
        public TimeSpan ExamTime { get; set; } = TimeSpan.Zero;

        /// <summary>
        /// Тип экзамена.
        /// </summary>
        public ExamType Type { get; set; }

        /// <summary>
        /// Диспциплина по учебному плану.
        /// </summary>
        public virtual CurriculumDiscipline CurriculumDiscipline { get; set; }
    }

    /// <summary>
    /// Рубежный контроль.
    /// </summary>
    public class BorderControl
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid DisciplineControlId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public uint Count { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ControlType Type { get; set; }
    }
}