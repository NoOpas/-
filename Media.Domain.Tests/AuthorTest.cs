using Media.domain.Data;
using Media.domain.Services.InMemRepo;

namespace Media.Domain.Tests
{
    /// <summary>
    /// Класс с юнит-тестами
    /// </summary>
    public class AuthorTest
    {
        private readonly AuthorInMemRepo _repository;
        public AuthorTest()
        {
            _repository = new AuthorInMemRepo();
        }

        /// <summary>
        /// Тест метода, возвращающего информацию о всех артистах
        /// </summary>
        [Fact]
        public void GetAllArtisInfo_ReturnsCorrectArtistDetails()
        {
            var result = _repository.GetAllArtisInfo();
            Assert.NotNull(result);
            Assert.Equal(DataSeeder.Authors.Count, result.Count);

            foreach (var artist in DataSeeder.Authors)
            {
                var expectedInfo = $"Имя: {artist.Name}, Описание: {artist.Description}, Жанр: {artist.Genre} ";
                Assert.Contains(expectedInfo, result);
            }
        }

        /// <summary>
        /// Тест метода, возвращающего артистов с максимальным количеством альбомов
        /// </summary>
        [Fact]
        public void GetArtistsWithMaxAlbums_ReturnsGetArtistsWithMaxAlbums()
        {
            var result = _repository.GetArtistsWithMaxAlbums();

            Assert.NotNull(result);
            Assert.NotEmpty(result);

            var maxAlbums = DataSeeder.Authors
                .Where(a => a.Albums != null)
                .Max(f => f.AlbumCount);

            var expectedArtists = DataSeeder.Authors
                .Where(a => a.Albums != null && a.Albums.Count == maxAlbums)
                .ToList();

            foreach (var artist in expectedArtists)
            {
                var expectedInfo = $"Имя: {artist.Name}, Описание: {artist.Description}, Жанр: {artist.Genre} " +
                    $"Количество альбомов: {artist.AlbumCount}";
                Assert.Contains(expectedInfo, result);
            }
        }
    }
}
