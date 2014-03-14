using System.Windows.Forms;

namespace PokeEditorV3.Logic.Events.KeyInputEvents
{
    public class EventKeyPressDown : KeyInputEvent
    {
        public KeyEventArgs KeyEvent { get; set; }

        public EventKeyPressDown(KeyEventArgs keyEvent) : base(Events.KeyPressDown)
        {
            KeyEvent = keyEvent;
        }

        public override bool Validate()
        {
            return true;
        }
    }
}
