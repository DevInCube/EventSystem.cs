public class Screen : IEventHandler
{
    private Cursor cursorRef;

    private void Draw()
    {
        System.Console.Clear();
        EventSystem.Emit(new Event(this, "draw", null));
    }

    public void Handle(Event ev)
    {
        if (ev.type == "cursorMove")
        {
            cursorRef = (Cursor)ev.data;
            Draw();
        }
        else if (ev.type == "updated")
        {
            Draw();
        }
    }
}