
using Akka.Actor;
using AkkaSample.SwitchableBehavior;

Console.WriteLine("AkkaSample - Switchable behavior");

var system = ActorSystem.Create("my-first-akka");
var musicPlayer = system.ActorOf<MusicPlayerActor>("musicPlayer");

musicPlayer.Tell(new PlaySongMessage("Smoke on the water"));
musicPlayer.Tell(new PlaySongMessage("Another brick in the wall"));
musicPlayer.Tell(new StopPlayingMessage());
musicPlayer.Tell(new StopPlayingMessage());
musicPlayer.Tell(new PlaySongMessage("Another brick in the wall"));

Console.ReadLine();

system.Terminate();