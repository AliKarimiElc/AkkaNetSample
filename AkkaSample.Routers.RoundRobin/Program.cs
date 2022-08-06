
using Akka.Actor;
using Akka.Routing;
using AkkaSample.Routers.RoundRobin;

Console.WriteLine("AkkaSample - Routers - Round robin");

var system = ActorSystem.Create("RoundRobin");

var calculatorProps = Props.Create<CalculatorActor>()
    .WithRouter(new RoundRobinPool(5));

var calculatorActorRef = system.ActorOf(calculatorProps, "CalculatorActor");

var result1 = calculatorActorRef.Ask(new AddMessage(1, 2)).Result as Answer;
var result2 = calculatorActorRef.Ask(new AddMessage(2, 3)).Result as Answer;
var result3 = calculatorActorRef.Ask(new AddMessage(3, 2)).Result as Answer;
var result4 = calculatorActorRef.Ask(new AddMessage(4, 5)).Result as Answer;
var result5 = calculatorActorRef.Ask(new AddMessage(5, 4)).Result as Answer;
var result6 = calculatorActorRef.Ask(new AddMessage(6, 3)).Result as Answer;
var result7 = calculatorActorRef.Ask(new AddMessage(7, 1)).Result as Answer;
var result8 = calculatorActorRef.Ask(new AddMessage(8, 5)).Result as Answer;

Console.WriteLine($"{nameof(result1)}: {result1.Value}");
Console.WriteLine($"{nameof(result2)}: {result2.Value}");
Console.WriteLine($"{nameof(result3)}: {result3.Value}");
Console.WriteLine($"{nameof(result4)}: {result4.Value}");
Console.WriteLine($"{nameof(result5)}: {result5.Value}");
Console.WriteLine($"{nameof(result6)}: {result6.Value}");
Console.WriteLine($"{nameof(result7)}: {result7.Value}");
Console.WriteLine($"{nameof(result8)}: {result8.Value}");

Console.ReadLine();

system.Terminate();
