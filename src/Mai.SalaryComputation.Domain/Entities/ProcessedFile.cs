using System;

namespace Mai.SalaryComputation.Domain.Entities
{
    public class ProcessedFile
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; protected set; }

        /// <summary>
        /// Хеш сумма файла
        /// </summary>
        public string Sha512Hash { get; protected set; } = default!;

        /// <summary>
        /// Название файла.
        /// </summary>
        public string Name { get; protected set; } = default!;
        
        /// <summary>
        /// Данные полученные из файла сериализованные в JSON.
        /// </summary>
        public string Payload { get; set; } = default!;

        /// <summary>
        /// Дата создания.
        /// </summary>
        public DateTime CreatedAt { get; set; }
        
        protected ProcessedFile()
        {
        }

        public ProcessedFile(string name, string payload, string sha512Hash)
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            Name = name;
            Payload = payload;
            Sha512Hash = sha512Hash;
        }
    }
}