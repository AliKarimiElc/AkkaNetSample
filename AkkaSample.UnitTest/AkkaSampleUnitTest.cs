using AkkaSample.ActorSelection.MusicPlayer;
using AkkaSample.ActorSelection.SongPerformance;
using Xunit;

namespace AkkaSample.UnitTest;

public class AkkaSampleUnitTest : Akka.TestKit.Xunit2.TestKit
{
    [Fact]
    private void Should_SongCounterIncreaseByOne_When_PlaySongMessage_Received()
    {
        #region Arrange

        var actor = ActorOfAsTestActorRef<SongPerformanceActor>();
        var songMessage = new PlaySongMessage("Song 1", "User id 1");

        #endregion



        #region Act

        actor.Tell(songMessage);

        #endregion



        #region Assert

        var counter = actor.UnderlyingActor.SongPerformanceCounters[songMessage.Song];
        Assert.Equal(1, counter);

        #endregion
    }
}