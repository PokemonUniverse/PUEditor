using System;
using System.Windows.Forms;
using PokeEditorV3.Dialogs;
using PokeEditorV3.Logic.Dialogs;
using PokeEditorV3.Logic.Events.ViewEvents;
using PokeEditorV3.Properties;
using WeifenLuo.WinFormsUI.Docking;

namespace PokeEditorV3.Logic.Managers
{
    public class ViewManager : Manager
    {
        public ViewManager() : base("ViewManager")
        {
            
        }

        public delegate void ShowWindowEventHandler(object sender, DockContent dockContent, DockState dockState);

        public delegate void ShowDialogEventHandler(object sender, DialogBase form);

        public event ShowWindowEventHandler OnShowWindow;
        public event ShowDialogEventHandler OnShowDialog;

        public void ShowWindow(EventShowWindow viewEvent)
        {
            Type windowName = viewEvent.WindowName;
            DockState dockState = viewEvent.DockState;

            try
            {
                var window = (DockContent)Activator.CreateInstance(windowName);
            
                if (OnShowWindow != null)
                {
                    OnShowWindow(this, window, dockState);
                }
            }
            catch (Exception ex)
            {
                ShowSystemException(ex);
            }
        }

        public void ShowDialog(EventShowDialog viewEvent)
        {
            try
            {
                var dialog = (DialogBase) Activator.CreateInstance(viewEvent.DialogName);

                if (viewEvent.DialogName == typeof (FrmOkDialog))
                {
                    ((FrmOkDialog) dialog).SetEvent(viewEvent);
                }

                if (OnShowDialog != null)
                {
                    OnShowDialog(this, dialog);
                }
            }
            catch (Exception ex)
            {
                ShowSystemException(ex);
            }
        }

        private void ShowSystemException(Exception ex)
        {
            MessageBox.Show(ex.Message, Resources.ViewManager_Exception, MessageBoxButtons.OK, MessageBoxIcon.Error);
            Program.WriteExceptionToFile(ex);
        }
    }
}
