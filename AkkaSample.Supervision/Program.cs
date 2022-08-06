
using Akka.Actor;
using AkkaSample.Supervision.MusicPlayer;
using AkkaSample.Supervision.MusicPlayerCoordinator;

Console.WriteLine("AkkaSample - Supervision");

var system = ActorSystem.Create("my-first-akka");

var dispatcher =
    system.ActorOf(Props.Create<MusicPlayerCoordinatorActor>());

dispatcher.Tell(new PlaySongMessage("Bohemian Rhapsody", "John"));
dispatcher.Tell(new PlaySongMessage("Stairway to Heaven", "Andrew"));

Console.Read();

system.Terminate();