using Media.domain.Model;

namespace Media.domain.Services
{
    interface IRepoAuthor : IRepo<Author, int>
    {
        /// <summary>
        /// Возвращает информацию о всех авторах в виде списка строк.
        /// </summary>
        public IList<string> GetAllArtisInfo();

        /// <summary>
        /// Метод для вывода авторов с макс кол-вом альбомов
        /// </summary>
        /// <returns>Список авторов и альбомов</returns>
        public IList<string> GetArtistsWithMaxAlbums();
    }
}
