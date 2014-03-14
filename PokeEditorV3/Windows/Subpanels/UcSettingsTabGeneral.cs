using System;
using System.Windows.Forms;
using NoNameLib.Configuration;
using PokeEditorV3.Configuration;

namespace PokeEditorV3.Windows.Subpanels
{
    public partial class UcSettingsTabGeneral : UserControl
    {
        public UcSettingsTabGeneral()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            if (DesignMode)
                return;

            this.tbTileRootPath.Text = ConfigurationManager.GetString(EditorConfigConstants.TileRootDirectory);

            this.tbTileRootPath.TextChanged += tbTileRootPath_TextChanged;
        }

        #region Events

        private void tbTileRootPath_TextChanged(object sender, EventArgs e)
        {
            ConfigurationManager.SetValue(EditorConfigConstants.TileRootDirectory, this.tbTileRootPath.Text);
        }

        private void btnBrowseTileRootPath_Click(object sender, EventArgs e)
        {
            string folderPath = "";
            var folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderBrowserDialog1.SelectedPath;
            }

            this.tbTileRootPath.Text = folderPath;
        }

        #endregion

    }
}
