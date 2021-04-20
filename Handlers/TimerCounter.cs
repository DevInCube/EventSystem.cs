public class TimerCounter : IEventHandler
{
    private int _counter = 0;
    private int _count;

    public TimerCounter(int count)
    {
        this._count = count;
    }

    public void Handle(Event ev)
    {
        if (ev.type == "timer")
        {
            System.Console.WriteLine($"{nameof(TimerCounter)} got timer event!");
            _counter += 1;
            if (_counter == _count)
            {
                Timer oldTimer = (Timer)ev.sender;
                EventSystem.RemoveHandler(oldTimer);
                System.Console.WriteLine($"{nameof(TimerCounter)} created new timer");
                EventSystem.AddHandler(new Timer(oldTimer.TimeoutMillis * 2));
                _counter = 0;
            }
        }
    }
}