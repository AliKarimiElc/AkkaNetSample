
using Akka.Actor;
using AkkaSample.Hierarchies.MusicPlayer;
using AkkaSample.Hierarchies.MusicPlayerCoordinator;

Console.WriteLine("AkkaSample - Hierarchical actors");

var system = ActorSystem.Create("MusicPlayerCoordinator");

var musicPlayerCoordinatorActorRef = 
    system.ActorOf<MusicPlayerCoordinatorActor>(nameof(MusicPlayerCoordinatorActor));

musicPlayerCoordinatorActorRef.Tell(new PlaySongMessage("Hayedeh","Ali"));
musicPlayerCoordinatorActorRef.Tell(new PlaySongMessage("Ebi", "Mohammad"));
musicPlayerCoordinatorActorRef.Tell(new PlaySongMessage("Leito", "Hamed"));

musicPlayerCoordinatorActorRef.Tell(new StopPlayingMessage("Ali"));
musicPlayerCoordinatorActorRef.Tell(new StopPlayingMessage("Mohammad"));
musicPlayerCoordinatorActorRef.Tell(new StopPlayingMessage("Hamed"));

Console.ReadLine();
system.Terminate();