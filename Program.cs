using System;

class Program
{
    static Label label;
    static void Main(string[] args)
    {
        EventSystem.AddHandler(new KeyInput());
        EventSystem.AddHandler(new Screen());
        Button btn1 = new Button(new System.Drawing.Rectangle(3, 3, 10, 4));
        btn1.MouseOver += OnMouseOver;
        btn1.MouseLeave += OnMouseLeave;
        EventSystem.AddHandler(btn1);
        EventSystem.AddHandler(new Button(new System.Drawing.Rectangle(20, 3, 10, 3)));
        label = new Label(new System.Drawing.Rectangle(40, 3, 10, 3), "default");
        EventSystem.AddHandler(label);
        EventSystem.AddHandler(new Cursor());

        Console.WriteLine("App started!");
        EventSystem.Run();  // loop starts
    }

    private static void OnMouseOver()
    {
        label.SetValue("mouse over!!");
    }

    private static void OnMouseLeave()
    {
        label.SetValue("mouse leave!!");
    }
}
