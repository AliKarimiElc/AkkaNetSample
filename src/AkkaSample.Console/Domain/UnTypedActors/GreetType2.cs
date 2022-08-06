namespace AkkaSample.Console.Domain.UnTypedActors;

internal class GreetType2:IGreetType
{
    public GreetType2()
    {
        GreetText = "This is greet type 2";
    }

    public string GreetText { get; }
}