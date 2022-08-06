// See https://aka.ms/new-console-template for more information

using Akka.Actor;
using Akka.DI.AutoFac;
using Akka.DI.Core;
using AkkaSample.DependencyInjection.MusicActor;
using AkkaSample.DependencyInjection.MusicService;
using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.AddTransient<IMusicSongService, MusicSongService>())
    .Build();

Console.WriteLine("AkkaSample - Dependency injection started");

var builder = new Autofac.ContainerBuilder();
builder.RegisterType<MusicSongService>().As<IMusicSongService>();
builder.RegisterType<MusicActor>().AsSelf();
var container = builder.Build();

var system = ActorSystem.Create("MusicPlayer");
var resolver = new AutoFacDependencyResolver(container, system);

var musicActor = system.ActorOf(system.DI().Props<MusicActor>(), "MusicActor");
musicActor.Tell("Ebi");

Console.ReadLine();

system.Terminate();
