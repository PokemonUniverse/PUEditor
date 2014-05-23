using System;
using System.Drawing;
using System.Windows.Forms;
using NoNameLib.UI.Controls.ImageView;
using WeifenLuo.WinFormsUI.Docking;

namespace PokeEditorV3.Windows
{
    public partial class FrmTextureBrowser : DockContent
    {
        public FrmTextureBrowser()
        {
            InitializeComponent();
        }

        private void FrmTextureBrowser_Load(object sender, EventArgs e)
        {
            CreateNewTab();
        }

        private void CreateNewTab()
        {
            var tilesetView = new TilesetView();
            tilesetView.TilesetPath = "e:\\Users\\Mr_Dark\\Dropbox\\Pokemon Universe\\Mapping\\util\\Pokemon Universe Tileset 2.png";
            tilesetView.Dock = DockStyle.Fill;

            var tabPage = new TabPage("Custom Tab");
            tabPage.BackColor = Color.White;
            tabPage.Controls.Add(tilesetView);
            tcTilesets.TabPages.Add(tabPage);
        }

        #region Properties

        #endregion
    }
}
