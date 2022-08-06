namespace AkkaSample.EventBus;

public class NewBookMessage
{
    public string BookName { get; }

    public NewBookMessage(string bookName)
    {
        BookName = bookName;
    }
}