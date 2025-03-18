using System.ComponentModel.DataAnnotations;

namespace Media.domain.Model
{
    public class Genre
    {
        /// <summary>
        /// Id жанра
        /// </summary>
        [Key]
        public required int Id { get; set; }

        /// <summary>
        /// Название жанра
        /// </summary>
        public string? Name { get; set; }
    }
}
