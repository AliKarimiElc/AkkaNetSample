namespace AkkaSample.ActorSelection.MusicPlayer;

public class StopPlayingMessage
{
    public string User { get; }

    public StopPlayingMessage(string user)
    {
        User = user;
    }
}