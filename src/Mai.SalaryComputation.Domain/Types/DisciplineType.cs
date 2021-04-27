using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Mai.SalaryComputation.Domain.Types
{
    /// <summary>
    /// Тип дисциплины.
    /// </summary>
    public enum DisciplineType
    {
        /// <summary>
        /// Неизвестно.
        /// </summary>
        [Description("Неизвестно")]
        [Display(Description = "Неизвестно")]
        [EnumMember(Value = "unknown")]
        Unknown = 0,

        /// <summary>
        /// Лекция.
        /// </summary>
        [Description("Лекция")]
        [Display(Description = "Лекция")]
        [EnumMember(Value = "lecture")]
        Lecture = 1,

        /// <summary>
        /// Лабораторная работа.
        /// </summary>
        [Description("Лабораторная работа")]
        [Display(Description = "Лабораторная работа")]
        [EnumMember(Value = "laboratoryWork")]
        LaboratoryWork = 2,

        /// <summary>
        /// Практическое занятие.
        /// </summary>
        [Description("Практическое занятие")]
        [Display(Description = "Практическое занятие")]
        [EnumMember(Value = "practicalLesson")]
        PracticalLesson = 3,

        /// <summary>
        /// Консультация.
        /// </summary>
        [Description("Консультация")]
        [Display(Description = "Консультация")]
        [EnumMember(Value = "consultation")]
        Consultation = 4,

        /// <summary>
        /// Другое.
        /// </summary>
        [Description("Другое")]
        [Display(Description = "Другое")]
        [EnumMember(Value = "other")]
        Other = 5
    }
}