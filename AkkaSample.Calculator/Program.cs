
using Akka.Actor;

Console.WriteLine("AkkaSample - Calculator started");

var system = ActorSystem.Create("CalculatorSystem");
var calculatorActor = system.ActorOf<CalculatorActor>("CalculatorActor");

calculatorActor.Tell(new Add(3, 5));
calculatorActor.Tell(new Minus(10, 4));

Console.ReadLine();

