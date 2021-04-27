namespace Mai.SalaryComputation.Domain.Types
{
    /// <summary>
    /// Вид занятости.
    /// </summary>
    public enum EmploymentType
    {
        /// <summary>
        /// Неизвестно.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Основное место работы.
        /// </summary>
        MainWork = 1,

        /// <summary>
        /// Не трудоустроен.
        /// </summary>
        NotEmployed = 2,

        /// <summary>
        /// Внешнее совместительство.
        /// </summary>
        ExternalWork = 3,

        /// <summary>
        /// Внутреннее совместительство.
        /// </summary>
        InternalWork = 4,

        /// <summary>
        /// Другое.
        /// </summary>
        Other = 5
    }
}