namespace AkkaSample.Console.Domain.UnTypedActors;

internal class GreetType1:IGreetType
{
    public GreetType1()
    {
        GreetText = "This is greet type 1";
    }

    public string GreetText { get;}
}