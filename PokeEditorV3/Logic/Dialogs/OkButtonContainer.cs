using PokeEditorV3.Logic.Events;

namespace PokeEditorV3.Logic.Dialogs
{
    public class OkButtonContainer
    {
        public OkButtonContainer()
        {
            
        }

        public OkButtonContainer(string text, DispatchableEvent buttonEvent)
        {
            ButtonText = text;
            ButtonEvent = buttonEvent;
        }

        public string ButtonText { get; set; }
        public DispatchableEvent ButtonEvent { get; set; }
    }
}
