using Akka.Actor;
using AkkaSample.Remoting.Common;

Console.WriteLine("AkkaSample - Remoting Server");
var hocon = HoconLoader.FromFile("akka.net.hocon");
var system = ActorSystem.Create("server-system",hocon);

Console.WriteLine($"Akka Server Started At {DateTime.Now:R}");

Console.WriteLine("For stop and close the server, press any key ...");
Console.ReadLine();

system.Terminate().Wait();