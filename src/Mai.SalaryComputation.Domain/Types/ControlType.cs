namespace Mai.SalaryComputation.Domain.Types
{
    public enum ControlType
    {
        /// <summary>
        /// Неизвестно.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Коллоквиум.
        /// </summary>
        Colloquium = 1,

        /// <summary>
        /// Контрольная работа.
        /// </summary>
        ControlWork = 2,

        /// <summary>
        /// Тестирование.
        /// </summary>
        Testing = 3,

        /// <summary>
        /// Другое.
        /// </summary>
        Other = 4
    }
}