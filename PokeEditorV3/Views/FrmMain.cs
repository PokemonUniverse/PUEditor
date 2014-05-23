using System;
using System.Windows.Forms;
using PokeEditorV3.Dialogs;
using PokeEditorV3.Logic.Dialogs;
using PokeEditorV3.Logic.Managers;
using PokeEditorV3.Logic.Views;
using PokeEditorV3.Windows;
using WeifenLuo.WinFormsUI.Docking;

namespace PokeEditorV3.Views
{
    public partial class FrmMain : Form
    {
        private readonly MainWindowController mainController;

        public FrmMain()
        {
            InitializeComponent();

            mainController = new MainWindowController();

            HookupEvents();
            InitializeWindows();
        }

        protected override void OnLoad(EventArgs e)
        {
 	         base.OnLoad(e);

             mainController.StartInitialization();
        }

        private void InitializeWindows()
        {
            //mainController.ShowWindow(typeof(FrmTextureBrowser), DockState.DockLeft);

            //new FrmNewTilesetDialog().ShowDialog(this);
        }

        private void HookupEvents()
        {
            var vm = GlobalManager.GetManager<ViewManager>();
            vm.OnShowWindow += ViewManagerOnShowWindow;
            vm.OnShowDialog += ViewManagerOnShowDialog;
        }

        private void ViewManagerOnShowWindow(object sender, DockContent dockContent, DockState dockState)
        {
            dockContent.Show(dockPanel, dockState);
        }

        private void ViewManagerOnShowDialog(object sender, DialogBase dialog)
        {
            dialog.ShowDialog(this);
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            this.mainController.KeyPressDown(e);
        }

        private void FrmMain_KeyUp(object sender, KeyEventArgs e)
        {
            this.mainController.KeyPressUp(e);
        }

        #region Toolbar Events

        #region File

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Windows

        private void tileEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.ShowWindow(typeof(FrmTileEditor), DockState.Document);
        }

        private void tileInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.ShowWindow(typeof(FrmTileInfo), DockState.DockLeft);
        }

        private void tileSetBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.ShowWindow(typeof(FrmTextureBrowser), DockState.DockLeft);
        }

        #endregion

        #region Tools

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.ShowWindow(typeof(FrmSettings), DockState.Document);
        }

        #endregion

        #region Help

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainController.ShowDialog(typeof(FrmAbout));
        }

        #endregion


        #endregion
    }
}
