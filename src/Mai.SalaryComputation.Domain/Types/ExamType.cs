namespace Mai.SalaryComputation.Domain.Types
{
    public enum ExamType
    {
        /// <summary>
        /// Неизвестно.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Экзамен.
        /// </summary>
        Exam = 1,

        /// <summary>
        /// Зачет.
        /// </summary>
        Pass = 2,

        /// <summary>
        /// Дифференцированный зачет.
        /// </summary>
        DifferentiatedPass = 2,

        /// <summary>
        /// Другое.
        /// </summary>
        Other = 3
    }
}