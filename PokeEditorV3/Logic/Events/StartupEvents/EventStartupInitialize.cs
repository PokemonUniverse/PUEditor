namespace PokeEditorV3.Logic.Events.StartupEvents
{
    public class EventStartupInitialize : StartupEvent
    {
        public EventStartupInitialize() : base(Events.Initialize)
        {
        }

        public override bool Validate()
        {
            return true;
        }
    }
}
