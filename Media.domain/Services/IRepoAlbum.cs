using Media.domain.Model;

namespace Media.domain.Services
{
    public interface IRepoAlbum : IRepo<Album, int>
    {
        /// <summary>
        /// Возвращает список треков для указанного альбома
        /// </summary>
        /// <returns>Список строк с информацией о треках.</returns>
        public IList<string> GetTreksInAlbum();

        /// <summary>
        /// Возвращает список треков для указанного альбома
        /// </summary>
        /// <param name="year">Год выпуска.</param>
        public IEnumerable<(string AlbumName, int TrackCount)> GetAlbumsWithTrackCount();

        /// <summary>
        /// Возвращает топ-5  альбомов по продолжительности
        /// </summary>
        public IList<Tuple<string, int>> GetTop5AlbumsByDuration();

        /// <summary>
        /// Получить информацию о количестве треков, среднем и максимальной дляительности для каждого альбома.
        /// </summary>
        /// <returns>Список с мин, авг и макс длительностью альбомов.</returns>
        public Task<IList<(int MinDuration, double avgDuration, int maxDuration)>> GetAlbumDurationStatistics();

    }
}
