using System;
using PokeEditorV3.Dialogs;
using PokeEditorV3.Logic.Dialogs;

namespace PokeEditorV3.Logic.Events.ViewEvents
{
    public class EventShowDialog : ViewEvent
    {
        public Type DialogName { get; set; }

        public string Title { get; set; }
        public string Text { get; set; }
        public OkButtonContainer OkButtonContainer { get; set; }

        public EventShowDialog()
            : base(Events.ShowDialog)
        {

        }

        public static void ShowOkDialog(string title, string message, OkButtonContainer buttonContainer = null)
        {
            var dialogEvent = new EventShowDialog();
            dialogEvent.DialogName = typeof (FrmOkDialog);
            dialogEvent.Title = title;
            dialogEvent.Text = message;
            dialogEvent.OkButtonContainer = buttonContainer;

            dialogEvent.PostUiThread();
        }
    }
}
