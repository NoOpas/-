using System.ComponentModel.DataAnnotations;

namespace Media.domain.Model
{
    public class Album
    {
        /// <summary>
        /// Id альбома
        /// </summary>
        [Key]
        public required int Id { get; set; }

        /// <summary>
        /// Название альбома
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Год релиза
        /// </summary>
        public int? Year { get; set; }

        /// <summary>
        /// Список треков альбома
        /// </summary>
        public virtual List<Track>? Tracks { get; set; } = [];
        public virtual List<Track>? AlbumID { get; set; } = [];

        /// <summary>
        /// Возвращает кол-во треков в альбоме
        /// </summary>
        public int? TrackCount => Tracks?.Count;

        /// <summary>
        /// Подсчет длительности альбома
        /// </summary>
        public int GetTotalDuration()
        {
            var sum = 0;
            if (Tracks?.Count > 0)
                foreach (var t in Tracks)
                    if (t != null && t.Albums != null)
                        sum += t.Duration ?? 0;

            return sum;
        }

    }
}
