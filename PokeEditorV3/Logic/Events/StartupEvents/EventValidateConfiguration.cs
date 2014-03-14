namespace PokeEditorV3.Logic.Events.StartupEvents
{
    public class EventValidateConfiguration : StartupEvent
    {
        public EventValidateConfiguration() : base(Events.ValidateConfiguration)
        {
        }

        public override bool Validate()
        {
            return true;
        }
    }
}
