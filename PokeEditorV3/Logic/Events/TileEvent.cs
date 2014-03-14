namespace PokeEditorV3.Logic.Events
{
    public abstract class TileEvent : DispatchableEvent
    {
        public enum Events
        {
            PointerChanged,
            TileMouseEvent,
            MovementTypeChanged,
        }

        protected TileEvent(Events events)
        {
            this.EventType = EventTypes.TileEvent;
            this.Action = events;
        }
    }
}
