
using Media.domain.Data;
using Media.domain.Services.InMemRepo;

namespace Media.Domain.Tests;

public class AlbumServiceTests
{
    private readonly AlbumInMemRepo _repository;
    public AlbumServiceTests()
    {
        _repository = new AlbumInMemRepo();
    }

    /// <summary>
    /// Непараметрический тест метода, выводящего треки в альбоме
    /// </summary>
    [Fact]
    public void GetTreksInAlbum_AlbumWithTracks_ReturnsOrderedTracks()
    {
        // Arrange
        var albumId = 1;

        // Act
        var album = DataSeeder.Albums.FirstOrDefault(a => a.Id == albumId);
        var result = album?.Tracks
            .Where(track => track.AlbumId == albumId)
            .OrderBy(track => track.NumberInAlbum)
            .Select(track => $"Трек: {track.Name ?? "Без имени"}")
            .ToList();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(4, result.Count);
        Assert.Single(result); // Since there's only one track
        Assert.Equal("Трек: The Number of the Beast", result[0]);
    }

    /// <summary>
    /// Непараметрический тест метода, выводящего альбомы в указанный год
    /// </summary>
    [Fact]
    public void GetAlbumsWithTrackCount_AlbumsInYear_ReturnsAlbumsWithTrackCounts()
    {
        var year = 1997;
        var result = _repository.GetAlbumsWithTrackCount(year);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
    }


}