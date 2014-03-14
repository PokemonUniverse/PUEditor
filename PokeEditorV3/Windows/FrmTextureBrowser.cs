using System;
using WeifenLuo.WinFormsUI.Docking;

namespace PokeEditorV3.Windows
{
    public partial class FrmTextureBrowser : DockContent
    {
        private const int VIEW_TILE = 1;
        private const int VIEW_DIRCTORY = 2;

        private int currentView = VIEW_DIRCTORY;

        public FrmTextureBrowser()
        {
            InitializeComponent();
        }

        private void FrmTextureBrowser_Load(object sender, EventArgs e)
        {
            CurrentView = VIEW_DIRCTORY;
        }

        #region Properties

        private int CurrentView
        {
            get { return currentView; }
            set 
            { 
                currentView = value;

                directoryView.Visible = (currentView == VIEW_DIRCTORY);
                tileView.Visible = (currentView == VIEW_TILE);
            }
        }

        #endregion

        #region OnClick Handlers

        private void tsbSwitchView_Click(object sender, EventArgs e)
        {
            if (CurrentView == VIEW_DIRCTORY)
                CurrentView = VIEW_TILE;
            else
                CurrentView = VIEW_DIRCTORY;
        }

        #endregion
    }
}
