using Akka.Actor;
using AkkaSample.ActorSelection.MusicPlayer;

namespace AkkaSample.ActorSelection.MusicPlayerCoordinator;

public class MusicPlayerCoordinatorActor : ReceiveActor
{
    protected Dictionary<string, IActorRef> MusicPlayerActors;
    public MusicPlayerCoordinatorActor()
    {
        MusicPlayerActors = new Dictionary<string, IActorRef>();

        Receive<PlaySongMessage>(PlaySong);
        Receive<StopPlayingMessage>(StopPlaying);
    }

    private void StopPlaying(StopPlayingMessage stopPlayingMessage)
    {
        var musicPlayerActorRef = GetMusicPlayerActor(stopPlayingMessage.User);
        musicPlayerActorRef?.Tell(stopPlayingMessage);
    }

    private void PlaySong(PlaySongMessage playSongMessage)
    {
        var musicPlayerActorRef = EnsureMusicPlayerActorExist(playSongMessage.User);
        musicPlayerActorRef.Tell(playSongMessage);
    }

    private IActorRef EnsureMusicPlayerActorExist(string user)
    {
        var musicPlayerActorRef = GetMusicPlayerActor(user);
        if (musicPlayerActorRef is null)
        {
            musicPlayerActorRef = Context.ActorOf<MusicPlayerActor>(user);
            MusicPlayerActors.Add(user, musicPlayerActorRef);
        }

        return musicPlayerActorRef;
    }

    private IActorRef? GetMusicPlayerActor(string user)
    {
        var isExist = MusicPlayerActors.TryGetValue(user, out var musicPlayerActorReference);
        return musicPlayerActorReference;
    }
}