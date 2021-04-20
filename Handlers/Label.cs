public class Label : IEventHandler 
{
    public System.Drawing.Rectangle rectangle;
    private string value;

    public Label(System.Drawing.Rectangle rect, string value)
    {
        this.rectangle = rect;
        this.value = value;
    }

    public void SetValue(string newValue)
    {
        this.value = newValue;
        EventSystem.Emit(new Event(this, "updated", null));
    }

    public void Handle(Event ev)
    {
        if (ev.type == "draw")
        {
            System.Console.SetCursorPosition(rectangle.Left, rectangle.Top);
            System.Console.Write(this.value);
        }
    }
}