using Media.domain.Data;
using Media.domain.Model;

namespace Media.domain.Services.InMemRepo;

/// <summary>
/// Имплементация репозитория для альбомов, которая хранит коллекцию в оперативной памяти 
/// </summary>
public class AlbumInMemRepo : IRepo<Album, int>
{
    private List<Album> _albums;
    public AlbumInMemRepo()
    {
        _albums = DataSeeder.Albums;
    }

    public bool Add(Album entity)
    {
        try
        {
            _albums.Add(entity);
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
            var album = Get(key);
            if (album != null)
                _albums.Remove(album);
        }
        catch
        {
            return false;
        }
        return true;
    }
    public bool Update(Album entity)
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
    public Album? Get(int key) =>
        _albums.FirstOrDefault(item => item.Id == key);
    public IList<Album> GetAll() =>
        _albums;

    /// <summary>
    /// Выводит информацию о всех треках в указанном альбоме, упорядоченных по номеру.
    /// </summary>
    /// <param name="AlbumId">Идентификатор альбома</param>
    /// <returns>Список треков</returns>
    public IList<string> GetTreksInAlbum(int AlbumId)
    {
        var album = Get(AlbumId);
        if (album == null || album.Tracks == null || !album.Tracks.Any())
            return new List<string>();

        return album.Tracks
            .Where(track => track.AlbumId == AlbumId)
            .OrderBy(track => track.NumberInAlbum)
            .Select(track =>
                $"Трек: {track.Name ?? "Без имени"}")
            .ToList();
    }

    /// <summary>
    /// Возвращает инфо обо всех альбомах, выпущенных в указанный год, с указанием кол-ва треков в каждом альбоме.
    /// </summary>
    /// <param name="year">Год выпуска альбома</param>
    public IEnumerable<(string AlbumName, int TrackCount)> GetAlbumsWithTrackCount(int year)
    {
        return _albums
            .Where(album => album.Year == year)
            .Select(album => (
                AlbumName: album.Name ?? "Без названия",
                TrackCount: album.Tracks?.Count ?? 0))
            .ToList();
    }

    /// <summary>
    /// Возвращает топ-5  альбомов по длительности
    /// </summary>
    public IList<Tuple<string, int>> GetTop5AlbumsByDuration() =>
        _albums
            .OrderByDescending(Album => Album.GetTotalDuration())
            .Take(5)
            .Select(Album => new Tuple<string, int>(Album.ToString(), Album.GetTotalDuration()))
            .ToList();

    /// <summary>
    /// Получить информацию о кол-ве треков, авг и макс длительности для каждого альбома.
    /// </summary>
    /// <returns>Список с мин, авг и макс длительностью альбомов.</returns>
    public Task<IList<(int MinDuration, double avgDuration, int maxDuration)>> GetAlbumDurationStatistics()
    {
        var albumDurations = _albums
       .GroupBy(a => a.AlbumID) // Группировка по AlbumID
       .Select(g => new
       {
           MinDuration = g.Min(album => album.GetTotalDuration()),
           AvgDuration = g.Average(album => album.GetTotalDuration()),
           MaxDuration = g.Max(album => album.GetTotalDuration())
       })
       .Where(a => a.AvgDuration > 0)
       .Select(a => (a.MinDuration, a.AvgDuration, a.MaxDuration))
       .ToList();

        return Task.FromResult<IList<(int, double, int)>>(albumDurations);
    }
}
