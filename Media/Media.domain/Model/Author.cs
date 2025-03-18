using System.ComponentModel.DataAnnotations;

namespace Media.domain.Model
{
    public class Author
    {
        /// <summary>
        /// Идентификатор автора
        /// </summary>
        [Key]
        public required int Id { get; set; }

        /// <summary>
        /// Имя автора
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Описание 
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Id жанра,связанного с автором
        /// </summary>
        public required int GenreID { get; set; }

        /// <summary>
        /// Жанр
        /// </summary>
        public virtual Genre? Genre { get; set; }

        /// <summary>
        /// Список альбомов
        /// </summary>
        public virtual List<Album>? Albums { get; set; } = [];

        /// <summary>
        /// Возвращает количество альбомов
        /// </summary>
        public int? AlbumCount => Albums?.Count;
    }
}
