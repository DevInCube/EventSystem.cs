public class Logger : IEventHandler
{
    public void Handle(Event ev)
    {
        if (ev.type == "cursorMove")
        {
            Cursor cursor = (Cursor)ev.data;
            System.Console.WriteLine("cursor position at: " 
                + cursor.positionX + "|" + cursor.positionY);
        }
        else if (ev.type == "cursorClick")
        {
            Cursor cursor = (Cursor)ev.data;
            System.Console.WriteLine("cursor CLICK at: " 
                + cursor.positionX + "|" + cursor.positionY);
        }
    }
}