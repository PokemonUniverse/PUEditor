namespace PokeEditorV3.Logic.Events
{
    public abstract class StartupEvent : DispatchableEvent
    {
        public enum Events
        {
            Initialize,
            ValidateConfiguration,
        }

        protected StartupEvent(Events events)
        {
            this.EventType = EventTypes.StartupEvent;
            this.Action = events;
        }
    }
}
