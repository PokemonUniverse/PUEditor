using System;
using System.Windows.Forms;
using PokeEditorV3.Logic.Events.KeyInputEvents;
using PokeEditorV3.Logic.Events.StartupEvents;
using PokeEditorV3.Logic.Events.ViewEvents;
using WeifenLuo.WinFormsUI.Docking;

namespace PokeEditorV3.Logic.Views
{
    public class MainWindowController
    {
        public void StartInitialization()
        {
           new EventStartupInitialize().PostWorkerThread();
        }

        public void KeyPressDown(KeyEventArgs args)
        {
            var keyEvent = new EventKeyPressDown(args);
            keyEvent.Post();
        }

        public void KeyPressUp(KeyEventArgs args)
        {
            var keyEvent = new EventKeyPressUp(args);
            keyEvent.Post();
        }

        public void ShowWindow(Type windowName, DockState dockState)
        {
            var showWindowEvent = new EventShowWindow();
            showWindowEvent.WindowName = windowName;
            showWindowEvent.DockState = dockState;
            showWindowEvent.Post();
        }

        public void ShowDialog(Type dialogName)
        {
            var showWindowEvent = new EventShowDialog();
            showWindowEvent.DialogName = dialogName;
            showWindowEvent.Post();
        }
    }
}
