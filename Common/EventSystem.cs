using System.Collections.Generic;

public static class EventSystem
{
    private static List<IEventHandler> _handlers = new List<IEventHandler>();
    private static Queue<Event> _eventQueue = new Queue<Event>();
    private static bool _isRunning = true;

    private static void Handle(Event ev)
    {
        if (ev.type == nameof(AddHandler))
        {
            _handlers.Add((IEventHandler)ev.data);
        }
        else if (ev.type == nameof(RemoveHandler))
        {
            _handlers.Remove((IEventHandler)ev.data);
        }
        else if (ev.type == nameof(Stop))
        {
            _isRunning = false;
        }
    }

    public static void Stop()
    {
        Emit(new Event(null, nameof(Stop), null));
    }

    public static void Run() 
    {
        const int TicksPerSecond = 20;
        int sleepMillis = 1000 / TicksPerSecond;
        System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();
        while (_isRunning)
        {
            object tickData = (object)stopwatch.ElapsedMilliseconds;
            Emit(new Event(null, "tick", tickData));
            stopwatch.Restart();

            while (_eventQueue.Count > 0)
            {
                Event nextEvent = _eventQueue.Dequeue();
                Handle(nextEvent);
                foreach (IEventHandler handler in _handlers)
                {
                    handler.Handle(nextEvent);
                }
            }

            long elapsedTime = stopwatch.ElapsedMilliseconds;
            long sleepTime = sleepMillis - elapsedTime;
            if (sleepTime > 0)
            {
                System.Threading.Thread.Sleep((int)sleepTime);
            }
        }
    }

    public static void AddHandler(IEventHandler eventHandler)
    {
        Emit(new Event(null, nameof(AddHandler), eventHandler));
    }

    public static void RemoveHandler(IEventHandler eventHandler)
    {
        Emit(new Event(null, nameof(RemoveHandler), eventHandler));
    }

    public static void Emit(Event ev)
    {
        _eventQueue.Enqueue(ev);
    }
}