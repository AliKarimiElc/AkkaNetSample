namespace AkkaSample.Hierarchies.MusicPlayer;

public class StopPlayingMessage
{
    public string User { get; }

    public StopPlayingMessage(string user)
    {
        User = user;
    }
}