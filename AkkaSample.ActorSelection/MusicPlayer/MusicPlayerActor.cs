using Akka.Actor;

namespace AkkaSample.ActorSelection.MusicPlayer;

public class MusicPlayerActor : ReceiveActor
{
    protected string? CurrentSong;

    public MusicPlayerActor()
    {
        StoppedBehavior();
    }

    private void StoppedBehavior()
    {
        Receive<PlaySongMessage>(PlaySong);
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


    private void PlaySong(PlaySongMessage message)
    {
        CurrentSong = message.Song;
        Console.WriteLine($"Currently playing '{CurrentSong}'");
        // DisplayInformation();

        var statsActor = Context.ActorSelection("../../statistics");
        statsActor.Tell(message);
        Become(PlayingBehavior);
    }

    private void DisplayInformation()
    {
        Console.WriteLine("Actor's information:");
        Console.WriteLine($"Typed Actor named: {Self.Path.Name}");
        Console.WriteLine($"Actor's path: {Self.Path}");
        Console.WriteLine($"Actor is part of the ActorSystem: {Context.System.Name}");
        Console.WriteLine($"Actor's parent: {Context.Self.Path.Parent.Name}");
    }

}