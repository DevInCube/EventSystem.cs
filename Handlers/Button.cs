public class Button : IEventHandler
{
    public System.Drawing.Rectangle rectangle;
    public bool mouseOver = false;

    public event System.Action MouseOver;
    public event System.Action MouseLeave;

    public Button(System.Drawing.Rectangle rect)
    {
        this.rectangle = rect;
    }

    private void Draw() 
    {
        if (mouseOver)
        {
            for (int x = rectangle.Left; x <= rectangle.Right; x++)
            {
                for (int y = rectangle.Top; y <= rectangle.Bottom; y++)
                {
                    System.Console.SetCursorPosition(x, y);
                    System.Console.Write('.');
                }
            }

            return;
        }

        for (int x = rectangle.Left; x <= rectangle.Right; x++)
        {
            System.Console.SetCursorPosition(x, rectangle.Top);
            System.Console.Write('=');
            System.Console.SetCursorPosition(x, rectangle.Bottom);
            System.Console.Write('=');
        }
        for (int y = rectangle.Top; y <= rectangle.Bottom; y++)
        {
            System.Console.SetCursorPosition(rectangle.Left, y);
            System.Console.Write('H');
            System.Console.SetCursorPosition(rectangle.Right, y);
            System.Console.Write('H');
        }
    }

    public void Handle(Event ev)
    {
        if (ev.type == "draw")
        {
            Draw();
        }
        else if (ev.type == "cursorMove")
        {
            Cursor cursorRef = (Cursor)ev.data;
            if (cursorRef.positionX >= rectangle.Left && cursorRef.positionX <= rectangle.Right
                && cursorRef.positionY >= rectangle.Top && cursorRef.positionY <= rectangle.Bottom)
            {
                if (!mouseOver)
                {
                    if (MouseOver != null)
                    {
                        MouseOver();
                    }
                }
                mouseOver = true;
            }
            else 
            {
                if (mouseOver)
                {
                    if (MouseLeave != null)
                    {
                        MouseLeave();
                    }
                }
                mouseOver = false;
            }
            Draw();
        }
    }
}