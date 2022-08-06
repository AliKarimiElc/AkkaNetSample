using Akka.Actor;
using AkkaSample.ActorSelection.MusicPlayer;

namespace AkkaSample.ActorSelection.SongPerformance;

public class SongPerformanceActor:ReceiveActor
{
    public Dictionary<string, int> SongPerformanceCounters;
    public SongPerformanceActor()
    {
        SongPerformanceCounters = new Dictionary<string, int>();
        Receive<PlaySongMessage>(IncreaseSongCounter);
    }

    private void IncreaseSongCounter(PlaySongMessage playSongMessage)
    {
        var counter = 1;
        if (SongPerformanceCounters.ContainsKey(playSongMessage.Song))
            counter = SongPerformanceCounters[playSongMessage.Song]++;
        else
            SongPerformanceCounters.Add(playSongMessage.Song, counter);

        Console.WriteLine($"Song: {playSongMessage.Song} has been played {counter} times");
    }
}