namespace AkkaSample.Console.Domain.TypedActors
{
    internal class Greet
    {
        public string Who { get; private set; }
        public Greet(string who)
        {
            Who = who;
        }
    }
}
