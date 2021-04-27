using System;

namespace Mai.SalaryComputation.Domain.Types
{
    /// <summary>
    /// Тип программы.
    /// </summary>
    [Flags]
    public enum ProgramType
    {
        /// <summary>
        /// Неизвестно.
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Бакалавриат.
        /// </summary>
        BachelorDegree = 1 << 1,

        /// <summary>
        /// Магистратура.
        /// </summary>
        MasterDegree = 1 << 2,

        /// <summary>
        /// Аспирантура.
        /// </summary>
        PostgraduateDegree = 1 << 3,

        /// <summary>
        /// Специалитет.
        /// </summary>
        SpecialistDegree = 1 << 4,

        /// <summary>
        /// Другое.
        /// </summary>
        Other = 1 << 5
    }
}