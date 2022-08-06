
using Akka.Actor;
using AkkaSample.ActorSelection.MusicPlayer;
using AkkaSample.ActorSelection.MusicPlayerCoordinator;
using AkkaSample.ActorSelection.SongPerformance;

Console.WriteLine("AkkaSample - Actor Selection");

var system = ActorSystem.Create("ActorSelectionSystem");

var musicPlayerCoordinatorActor = 
    system.ActorOf<MusicPlayerCoordinatorActor>(nameof(MusicPlayerCoordinatorActor));

var stats = system.ActorOf<SongPerformanceActor>("statistics");

musicPlayerCoordinatorActor.Tell(new PlaySongMessage("Smoke on the water", "John"));
musicPlayerCoordinatorActor.Tell(new PlaySongMessage("Smoke on the water", "Mike"));
musicPlayerCoordinatorActor.Tell(new StopPlayingMessage("Mike"));
musicPlayerCoordinatorActor.Tell(new PlaySongMessage("Smoke on the water", "Mike"));
musicPlayerCoordinatorActor.Tell(new PlaySongMessage("Another Brick in the wall", "Andrew"));
Console.Read();
system.Terminate();

