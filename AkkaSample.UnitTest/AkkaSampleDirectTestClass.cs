using AkkaSample.ActorSelection.MusicPlayer;
using AkkaSample.ActorSelection.SongPerformance;
using Xunit;
using static Xunit.Assert;

namespace AkkaSample.UnitTest;

public class AkkaSampleDirectTestClass : Akka.TestKit.Xunit2.TestKit
{
    [Fact]
    public void Should_CountersISEmpty_When_ActorStateIs_Start()
    {
        var actor = new SongPerformanceActor();
        False(actor.SongPerformanceCounters.Any());
    }
}