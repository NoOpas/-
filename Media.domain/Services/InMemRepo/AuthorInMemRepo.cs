using Media.domain.Data;
using Media.domain.Model;

namespace Media.domain.Services.InMemRepo
{
    /// <summary>
    /// Реализация репозитория авторов в памяти.
    /// </summary>
    public class AuthorInMemRepo : IRepo<Author, int>
    {
        private List<Author> _authors;
        public AuthorInMemRepo()
        {
            _authors = DataSeeder.Authors;
        }

        public bool Add(Author entity)
        {
            try
            {
                _authors.Add(entity);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool Delete(int key)
        {
            try
            {
                var author = Get(key);
                if (author != null)
                    _authors.Remove(author);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public bool Update(Author entity)
        {
            try
            {
                Delete(entity.Id);
                Add(entity);
            }
            catch
            {
                return false;
            }
            return true;
        }
        public Author? Get(int key) =>
            _authors.FirstOrDefault(item => item.Id == key);
        public IList<Author> GetAll() =>
            _authors;

        /// <summary>
        /// Возвращает информацию о всех артистах в виде списка строк.
        /// </summary>
        public IList<string> GetAllArtisInfo()
        {
            return _authors.Select(Artist =>
                    $"Имя: {Artist.Name}, Описание: {Artist.Description}, Жанр: {Artist.Genre} ")
                .ToList();
        }

        /// <summary>
        /// Метод для вывода артистов с максимальныи количествм альбомов
        /// </summary>
        /// <returns>Список артистов и альбомов</returns>
        /// <summary>
        public IList<string> GetArtistsWithMaxAlbums()
        {
            var maxAlbums = _authors
                .Where(Artist => Artist.Albums != null)
                .Max(Artist => Artist.AlbumCount);

            return _authors
                .Where(Artist => Artist.Albums != null && Artist.Albums.Count == maxAlbums)
                .Select(Artist =>
                    $"Имя: {Artist.Name}, Описание: {Artist.Description}, Жанр: {Artist.Genre} " +
                    $"Количество альбомов: {Artist.AlbumCount}")
                .ToList();
        }
    }
}
