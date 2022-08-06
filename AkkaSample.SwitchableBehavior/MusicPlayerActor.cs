using Akka.Actor;

namespace AkkaSample.SwitchableBehavior;

public class MusicPlayerActor : ReceiveActor
{
    protected string? CurrentSong;

    public MusicPlayerActor()
    {
        StoppedBehavior();
    }

    private void StoppedBehavior()
    {
        Receive<PlaySongMessage>(message => PlaySong(message.Song));
        Receive<StopPlayingMessage>(message => Console.WriteLine("Cannot stop, The music player already stopped"));
    }

    private void PlayingBehavior()
    {
        Receive<PlaySongMessage>(message => Console.WriteLine("Cannot play, Currently playing"));
        Receive<StopPlayingMessage>(message => StopPlaying());
    }

    private void StopPlaying()
    {
        CurrentSong = null;
        Console.WriteLine($"Music player is stopped");
        Become(StoppedBehavior);
    }


    private void PlaySong(string? song)
    {
        CurrentSong = song;
        Console.WriteLine($"Currently playing '{song}'");
        Become(PlayingBehavior);
    }
}