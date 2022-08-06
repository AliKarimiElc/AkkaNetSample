
using Akka.Actor;
using AkkaSample.ActorTermination;

Console.WriteLine("AkkaSample - Full lifecycle started");

var system = ActorSystem.Create("TerminationSystem");

#region Method 1

Console.WriteLine("Method 1 - Self actor stopping -----------------------------------");

var actor = system.ActorOf<TerminationActor>();

actor.Tell("Hello termination actor");

actor.Tell(new StopMessage());

#endregion


#region Method 2

Console.WriteLine("Method 2 - Terminate actor by system stop ------------------------");

actor = system.ActorOf<TerminationActor>();

actor.Tell("Hello termination actor");

system.Stop(actor);

#endregion


#region Method 3

Console.WriteLine("Method 3 - Terminate actor by poison pill ------------------------");

actor = system.ActorOf<TerminationActor>();

actor.Tell("Message 1");
actor.Tell("Message 2");

actor.Tell(PoisonPill.Instance);

actor.Tell("Message 3");

#endregion

#region Methode 4

Console.WriteLine("Method 4 - Terminate actor by system terminate -------------------");

actor = system.ActorOf<TerminationActor>();

actor.Tell("Hello termination actor");
actor.Tell("Hello termination actor");
actor.Tell("Hello termination actor");
actor.Tell("Hello termination actor");
actor.Tell("Hello termination actor");

system.Terminate();

#endregion

#region Method 5

Console.WriteLine("Method 5 - Terminate actor by kill message -----------------------");

actor = system.ActorOf<TerminationActor>();

actor.Tell("Message 1");
actor.Tell("Message 2");

actor.Tell(Kill.Instance);

actor.Tell("Message 3");

#endregion

#region Gracefully stop

Console.WriteLine("Method 5 - Gracefully termination --------------------------------");

actor = system.ActorOf<TerminationActor>();

actor.Tell("Message 1");
actor.Tell("Message 2");

actor.GracefulStop(TimeSpan.FromSeconds(15));

actor.Tell("Message 3");

#endregion

Console.ReadLine();




