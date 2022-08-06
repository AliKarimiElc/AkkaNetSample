using Akka.Actor;
using AkkaSample.Supervision.MusicPlayer;

namespace AkkaSample.Supervision.MusicPlayerCoordinator;

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

        if (musicPlayerActorRef is not null) return musicPlayerActorRef;

        musicPlayerActorRef = Context.ActorOf<MusicPlayerActor>(user);
        MusicPlayerActors.Add(user, musicPlayerActorRef);

        return musicPlayerActorRef;
    }

    private IActorRef? GetMusicPlayerActor(string user)
    {
        MusicPlayerActors.TryGetValue(user, out var musicPlayerActorReference);
        return musicPlayerActorReference;
    }

    protected override SupervisorStrategy SupervisorStrategy()
    {
        return new OneForOneStrategy(ex =>
        {
            return ex switch
            {
                SongNotAvailableException => Directive.Resume,
                MusicSystemCorruptedException => Directive.Restart,
                _ => Directive.Stop
            };
        });
    }
}