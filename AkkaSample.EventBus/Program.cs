
using Akka.Actor;
using AkkaSample.EventBus;

Console.WriteLine("AkkaSample - Event bus");

var system = ActorSystem.Create("EventBusSystem");

var publisher = system.ActorOf<BookPublisher>("BookPublisherActor");

var subscriber1 = system.ActorOf<BookSubscriber>("Subscriber1");
var subscriber2 = system.ActorOf<BookSubscriber>("Subscriber2");

system.EventStream.Subscribe(subscriber1,typeof(NewBookMessage));
system.EventStream.Subscribe(subscriber2,typeof(NewBookMessage));

publisher.Tell(new NewBookMessage("Clean code"));
publisher.Tell(new NewBookMessage("Clean Architecture"));

Console.ReadLine();

system.Terminate();