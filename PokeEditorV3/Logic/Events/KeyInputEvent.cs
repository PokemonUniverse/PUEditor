namespace PokeEditorV3.Logic.Events
{
    public abstract class KeyInputEvent : DispatchableEvent
    {
        public enum Events
        {
            KeyPressDown,
            KeyPressUp,
        }

        protected KeyInputEvent(Events keyEvent)
        {
            this.EventType = EventTypes.KeyInputEvent;
            this.Action = keyEvent;
        }
    }
}
