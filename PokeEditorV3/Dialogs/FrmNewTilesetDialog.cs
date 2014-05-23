using System;
using PokeEditorV3.Logic.Dialogs;
using PokeEditorV3.Logic.Models;

namespace PokeEditorV3.Dialogs
{
    public partial class FrmNewTilesetDialog : DialogBase
    {
        readonly TilesetModel tilesetModel = new TilesetModel();
        readonly NewTilesetController controller = new NewTilesetController();

        public FrmNewTilesetDialog()
        {
            InitializeComponent();

            DataBindFields();
        }

        private void DataBindFields()
        {
            tilesetModelBindingSource.DataSource = tilesetModel;

            /*this.tbName.DataBindings.Add("Text", tilesetModel, "Name");
            this.tbImagePath.DataBindings.Add("Text", tilesetModel, "Path");
            this.numTileHeight.DataBindings.Add("Value", tilesetModel, "TileHeight");
            this.numTileWidth.DataBindings.Add("Value", tilesetModel, "TileWidth");*/

            //errorProvider.BindToDataAndErrors(tilesetModel, "Name");
        }

        #region Events

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                controller.CreateNewTileset(tilesetModel);
            }
        }

        #endregion

    }
}
