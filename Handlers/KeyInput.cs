public class KeyInput : IEventHandler
{
    public void Handle(Event ev)
    {
        if (System.Console.KeyAvailable)
        {
            System.ConsoleKeyInfo keyInfo = System.Console.ReadKey(true);
            if (keyInfo.Key == System.ConsoleKey.Escape)
            {
                EventSystem.Stop();
            }
            else 
            {
                EventSystem.Emit(new Event(this, "keyInput", keyInfo.KeyChar));
            }
        }
    }
}