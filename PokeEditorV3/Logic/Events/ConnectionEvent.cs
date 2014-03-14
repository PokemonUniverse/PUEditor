namespace PokeEditorV3.Logic.Events
{
    public abstract class ConnectionEvent : DispatchableEvent
    {
        public enum Events
        {
            ConnectToServer
        }

        protected ConnectionEvent(Events events)
        {
            this.EventType = EventTypes.ConnectionEvent;
            this.Action = events;
        }
    }
}
