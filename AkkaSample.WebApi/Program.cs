using Akka.Actor;
using AkkaSample.WebApi.Services.CalculatorService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var actorSystem = ActorSystem.Create("AkkaSampleWebApi");
builder.Services.AddSingleton(typeof(ActorSystem), _ => actorSystem);
builder.Services.AddSingleton<ICalculatorActorInstance, CalculatorActorInstance>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
