using NoNameLib.Enums;
using PokeEditorV3.Logic.Events.KeyInputEvents;

namespace PokeEditorV3.Logic.Managers
{
    public class KeyInputManager : Manager
    {
        private KeysEnum pressedKeys;

        public KeyInputManager() : base("KeyInputManager")
        {
            
        }

        public bool IsKeyPressed(KeysEnum key)
        {
            return pressedKeys.HasFlag(key);
        }

        public void SetKeyPressDown(EventKeyPressDown keyEvent)
        {
            if (keyEvent.KeyEvent.Alt)
                pressedKeys |= KeysEnum.Alt;
            if (keyEvent.KeyEvent.Control)
                pressedKeys |= KeysEnum.Control;
            if (keyEvent.KeyEvent.Shift)
                pressedKeys |= KeysEnum.Shift;
        }

        public void SetKeyPressUp(EventKeyPressUp keyEvent)
        {
            if (!keyEvent.KeyEvent.Alt)
                pressedKeys ^= KeysEnum.Alt;
            if (!keyEvent.KeyEvent.Control)
                pressedKeys ^= KeysEnum.Control;
            if (!keyEvent.KeyEvent.Shift)
                pressedKeys ^= KeysEnum.Shift;
        }
    }
}
