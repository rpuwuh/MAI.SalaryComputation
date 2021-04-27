namespace Mai.SalaryComputation.Domain.Types
{
    /// <summary>
    /// Тип аудиторного времени.
    /// </summary>
    public enum ClassroomType
    {
        /// <summary>
        /// Неизвестно.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Лекция.
        /// </summary>
        Lecture = 1,

        /// <summary>
        /// Лабораторная работа.
        /// </summary>
        LaboratoryWork = 2,

        /// <summary>
        /// Практическое занятие.
        /// </summary>
        PracticalLesson = 3,

        /// <summary>
        /// Контроль самостоятельной работы.
        /// </summary>
        IndependentWorkControl = 4,

        /// <summary>
        /// Другое.
        /// </summary>
        Other = 5
    }
}