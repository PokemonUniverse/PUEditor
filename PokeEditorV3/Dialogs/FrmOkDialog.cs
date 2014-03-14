using PokeEditorV3.Logic.Dialogs;
using PokeEditorV3.Logic.Events.ViewEvents;

namespace PokeEditorV3.Dialogs
{
    public partial class FrmOkDialog : DialogBase
    {
        private readonly int baseFormHeight;
        private readonly int baseLabelHeight;

        private OkButtonContainer okButtonContainer;

        public FrmOkDialog()
        {
            InitializeComponent();

            baseFormHeight = this.Height;
            baseLabelHeight = this.lblText.Height;
        }

        public void SetEvent(EventShowDialog showDialogEvent)
        {
            this.Text = showDialogEvent.Title;
            this.lblText.Text = showDialogEvent.Text;

            if (showDialogEvent.OkButtonContainer != null)
            {
                this.okButtonContainer = showDialogEvent.OkButtonContainer;

                if (this.okButtonContainer.ButtonText.Length > 0)
                {
                    this.btnOk.Text = this.okButtonContainer.ButtonText;
                }
            }

            RecalculateFormDimensions();
        }

        private void RecalculateFormDimensions()
        {
            this.Height = baseFormHeight + (this.lblText.Height - baseLabelHeight);
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            if (okButtonContainer != null && okButtonContainer.ButtonEvent != null)
            {
                okButtonContainer.ButtonEvent.Post();
            }

            Close();
        }
    }
}
