namespace Mai.SalaryComputation.Domain.Types
{
    public enum IndependentWorkType
    {
        /// <summary>
        /// Неизвестно.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Расчетно графическая работа.
        /// </summary>
        GraphicDesign = 1,

        /// <summary>
        /// Домашнее задание.
        /// </summary>
        Homework = 2,

        /// <summary>
        /// Рефератю
        /// </summary>
        Report = 3,

        /// <summary>
        /// Курсовая работа.
        /// </summary>
        Coursework = 4,

        /// <summary>
        /// Курсовой проект.
        /// </summary>
        CourseProject = 5,

        /// <summary>
        /// Другое.
        /// </summary>
        Other = 6
    }
}