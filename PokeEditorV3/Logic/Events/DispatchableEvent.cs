using System;

namespace PokeEditorV3.Logic.Events
{
    public abstract class DispatchableEvent
    {
        public enum EventTypes
        {
            StartupEvent,
            ApplicationEvent,
            ConnectionEvent,
            TileEvent,
            KeyInputEvent,
            ViewEvent,
        }

        public EventTypes EventType { get; protected set; }

        public Enum Action { get; set; }

        //public DispatchableEvent NextEvent { get; set; }

        public Action Callback { get; set; }

        public abstract bool Validate();

        public void Post()
        {
            EventDispatcher.DispatchEvent(this);
        }

        public void PostWorkerThread()
        {
            EventDispatcher.DispatchEventOnWorkerThread(this);
        }

        public void PostUiThread()
        {
            EventDispatcher.DispatchEventOnUiThread(this);
        }
    }
}
