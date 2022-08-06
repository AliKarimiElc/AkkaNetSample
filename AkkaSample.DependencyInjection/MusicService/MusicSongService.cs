using AkkaSample.DependencyInjection.Model;

namespace AkkaSample.DependencyInjection.MusicService;

public class MusicSongService : IMusicSongService
{
    public Song GetSongByName(string songName)
    {
        return new Song(songName, Array.Empty<byte>());
    }
}