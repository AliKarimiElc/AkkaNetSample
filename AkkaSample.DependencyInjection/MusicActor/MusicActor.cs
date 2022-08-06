using Akka.Actor;
using AkkaSample.DependencyInjection.MusicService;

namespace AkkaSample.DependencyInjection.MusicActor;

public class MusicActor : ReceiveActor
{
    public IMusicSongService MusicSongService { get; set; }
    public MusicActor(IMusicSongService musicSongService)
    {
        MusicSongService = musicSongService;
        Receive<string>(HandleSongRetrieval);

        // using IServiceScope serviceScope = host.CreateScope();
        // IServiceProvider provider = serviceScope.ServiceProvider;
    }

    public void HandleSongRetrieval(string songName)
    {
        var song = MusicSongService.GetSongByName(songName);

        Console.WriteLine($"Music song retrieve, Song name : {song.SongName}");
    }
}