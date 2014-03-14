using System.Windows.Forms;

namespace PokeEditorV3.Logic.Events.KeyInputEvents
{
    public class EventKeyPressUp : KeyInputEvent
    {
        public KeyEventArgs KeyEvent { get; set; }

        public EventKeyPressUp(KeyEventArgs keyEvent) : base(Events.KeyPressUp)
        {
            KeyEvent = keyEvent;
        }

        public override bool Validate()
        {
            return true;
        }
    }
}
