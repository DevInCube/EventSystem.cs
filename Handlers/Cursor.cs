public class Cursor : IEventHandler 
{
    public int positionX;
    public int positionY;

    private void HandleKeyInput(Event ev)
    {
        char keyChar = char.ToLower((char)ev.data);
        if (keyChar == 'w')
        {
            positionY -= 1;
            EventSystem.Emit(new Event(this, "cursorMove", this));
        }
        else if (keyChar == 's')
        {
            positionY += 1;
            EventSystem.Emit(new Event(this, "cursorMove", this));
        }
        else if (keyChar == 'a')
        {
            positionX -= 1;
            EventSystem.Emit(new Event(this, "cursorMove", this));
        }
        else if (keyChar == 'd')
        {
            positionX += 1;
            EventSystem.Emit(new Event(this, "cursorMove", this));
        }
        else if (keyChar == ' ')
        {
            EventSystem.Emit(new Event(this, "cursorClick", this));
        }
    }

    private void Draw()
    {
        System.Console.SetCursorPosition(this.positionX, this.positionY);
        System.Console.Write('+');
        System.Console.SetCursorPosition(0, 0);
    }

    public void Handle(Event ev)
    {
        if (ev.type == "keyInput")
        {
            HandleKeyInput(ev);
        }
        else if (ev.type == "draw")
        {
            Draw();
        }
    }
}