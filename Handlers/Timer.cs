public class Timer: IEventHandler
{
    private int _timeCounter = 0;
    private int _timeoutMillis;

    public int TimeoutMillis
    {
        get 
        {
            return _timeoutMillis;
        }
    }

    public Timer(int timeoutMillis)
    {
        this._timeoutMillis = timeoutMillis;
    }

    public void Handle(Event ev)
    {
        if (ev.type == "tick")
        {
            long elapsedMillis = (long)ev.data;
            _timeCounter += (int)elapsedMillis;
            if (_timeCounter > _timeoutMillis)
            {
                EventSystem.Emit(new Event(this, "timer", null));
                _timeCounter = 0;
            }
        }
    }
}