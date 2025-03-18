using Media.domain.Model;

namespace Media.domain.Data
{
    /// <summary>
    /// Класс для заполнения коллекций датой
    /// </summary>
    public static class DataSeeder
    {
        /// <summary>
        /// Список жанров
        /// </summary>
        public static readonly List<Genre> Genres =
    [
        new()
        {
            Id = 1,
            Name="Rock"
        },
        new()
        {
            Id = 2,
            Name="Pop"
        },
        new()
        {
            Id = 3,
            Name="Hip-Hop/Rap"
        },
        new()
        {
            Id = 4,
            Name="Jazz"
        },
        new()
        {
            Id = 5,
            Name="K-Pop"
        },

     ];

        /// <summary>
        /// Список Авторов
        /// </summary>
        public static readonly List<Author> Authors =
        [
            new()
            {
                Id = 1,
                Name = "Iron Maiden",
                Description = "Английская хэви-метал-группа, прославившаяся мощными рифами, драматичными сюжетами и симфonicными элементами.",
                GenreID = 2
            },
            new()
            {
                Id = 2,
                Name = "Radiohead",
                Description = "Английская альтернативная рок-группа, известная инновационными текстурами и экспериментальным подходом к музыке.",
                GenreID = 3
            },
            new()
            {
                Id = 3,
                Name = "Deep Purple",
                Description = "Английская rock-группа, легендарная своим использованием синтезаторов и инструментальным мастерством.",
                GenreID = 2
            },
            new()
            {
                Id = 4,
                Name = "U2",
                Description = "Ирландская рок-группа, известная глубокими социальными и духовными темами в своих песнях.",
                GenreID = 2
            },
            new()
            {
                Id = 5,
                Name = "Kings of Leon",
                Description = "Английская альтернативная рок-группа, сочетающая элементы garage rock и southern rock.",
                GenreID = 3
            },
     ];

        /// <summary>
        /// Список артистов
        /// </summary>
        public static readonly List<Album> Albums =
        [
           new()
           {
                Id = 1,
                Name = "The Number of the Beast",
                Year = 1982,
           },
           new()
           {
                Id = 2,
                Name = "OK Computer",
                Year = 1997,
           },
           new()
           {
                Id = 3,
                Name = "Made in Japan",
                Year = 1973,
           },
           new()
           {
                Id = 4,
                Name = "The Joshua Tree",
                Year = 1987,
           },
           new()
           {
                Id = 5,
                Name = "Only by the Night",
                Year = 2008,
           },
     ];

        /// <summary>
        /// Список треков
        /// </summary>
        public static readonly List<Track> Tracks =
        [
            new()
            {
                Id = 1,
                Name = "The Number of the Beast",
                NumberInAlbum = 1,
                AlbumId = 1,
                Duration = 261,
            },
            new()
            {
                Id = 2,
                Name = "Paranoid Android",
                NumberInAlbum = 3,
                AlbumId = 2,
                Duration = 370,
            },
            new()
            {
                Id = 3,
                Name = "Smoke on the Water",
                NumberInAlbum = 11,
                AlbumId = 3,
                Duration = 150,
            },
            new()
            {
                Id = 4,
                Name = "With or Without You",
                NumberInAlbum = 3,
                AlbumId = 4,
                Duration = 350,
            },
            new()
            {
                Id = 5,
                Name = "Use Somebody",
                NumberInAlbum = 6,
                AlbumId = 5,
                Duration = 242,
            },
        ];

        static DataSeeder()
        {
            foreach (var t in Tracks)
            {
                t.Albums = Albums.FirstOrDefault(al => al.Id == t.AlbumId);
            }

            foreach (var al in Albums)
            {

                if (al.Tracks == null)
                    al.Tracks = new List<Track>();


                al.Tracks.AddRange(Tracks.Where(t => t.AlbumId == al.Id));
            }
        }

    }
}
