public class Event
{
    public IEventHandler sender;
    public string type;
    public object data;

    public Event(IEventHandler sender, string type, object data)
    {
        this.sender = sender;
        this.type = type;
        this.data = data;
    }
}