using AkkaSample.DependencyInjection.Model;

namespace AkkaSample.DependencyInjection.MusicService;

public interface IMusicSongService
{
    public Song GetSongByName(string songName);
}