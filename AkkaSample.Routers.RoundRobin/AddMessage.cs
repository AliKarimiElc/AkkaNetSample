namespace AkkaSample.Routers.RoundRobin;

public class AddMessage
{
    public AddMessage(int term1, int term2)
    {
        Term1 = term1;
        Term2 = term2;
    }
    public int Term1 { get; }
    public int Term2 { get; }
}