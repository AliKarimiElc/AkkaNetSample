// See https://aka.ms/new-console-template for more information

using Akka.Actor;
using AkkaSample.Console.Domain.TypedActors;
using AkkaSample.Console.Domain.UnTypedActors;

Console.WriteLine("AkkaSample Console started");

var system = ActorSystem.Create("AkkaSampleSystem");

var typedGreeter = system.ActorOf<GreetingActor>("TypedGreeter");
var unTypedGreeter = system.ActorOf<UnTypedGreeter>("UnTypedGreeter");

typedGreeter.Tell(new Greet("Hello Akka !!!"));

Console.WriteLine("Fire and forget");

unTypedGreeter.Tell(new GreetType1());

Console.WriteLine("Fire and forget");

unTypedGreeter.Tell(new GreetType2());

Console.WriteLine("Fire and forget");

unTypedGreeter.Tell(new Greet("Hello akka !!!"));

Console.WriteLine("Fire and forget");

Console.ReadLine();