using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using NoNameLib.TileEditor.Collections;
using PokeEditorV3.Logic.Windows;
using WeifenLuo.WinFormsUI.Docking;
using PokeEditorV3.Properties;

namespace PokeEditorV3.Windows
{
    public partial class FrmTileInfo : DockContent
    {
        private readonly TileInfoController tileInfoController;

        private RadioButton selectedTileLayer;

        public FrmTileInfo()
        {
            InitializeComponent();

            tileInfoController = new TileInfoController();

            HookupEvents();

            selectedTileLayer = this.rbLayer0;

            SetTileValues(null);
        }

        private void HookupEvents()
        {
            tileInfoController.OnMouseTileHover += tileInfoController_OnMouseTileHover;
        }

        private void tileInfoController_OnMouseTileHover(object sender, TilePoint tp)
        {
            SetTileValues(tp);
        }

        private void TilePointLayerCheckedChanged(Object sender, EventArgs e)
        {
            if (((RadioButton) sender).Checked)
            {
                selectedTileLayer = (RadioButton) sender;
            }
        }

        private void SetTileValues(TilePoint tp)
        {
            if (tp == null)
            {
                this.tbTileX.Text = @"xxx";
                this.tbTileY.Text = @"xxx";
                
                ResetTileLayers();
            }
            else
            {
                this.tbTileX.Text = tp.X.ToString(CultureInfo.InvariantCulture);
                this.tbTileY.Text = tp.Y.ToString(CultureInfo.InvariantCulture);

                if (tp.Layers.Count > 0)
                {
                    this.rbLayerN3.ForeColor = tp.HasLayer(-3) ? Color.Green : Color.Red;
                    this.rbLayerN2.ForeColor = tp.HasLayer(-2) ? Color.Green : Color.Red;
                    this.rbLayerN1.ForeColor = tp.HasLayer(-1) ? Color.Green : Color.Red;
                    this.rbLayer0.ForeColor = tp.HasLayer(0) ? Color.Green : Color.Red;
                    this.rbLayerP1.ForeColor = tp.HasLayer(1) ? Color.Green : Color.Red;
                    this.rbLayerP2.ForeColor = tp.HasLayer(2) ? Color.Green : Color.Red;
                    this.rbLayerP3.ForeColor = tp.HasLayer(3) ? Color.Green : Color.Red;

                    TilePointLayer tpLayer = tp.GetLayer(GetSelectedTilePointLayer());
                    if (tpLayer != null)
                    {
                        this.tbMovementType.Text = tpLayer.Movement.ToString();

                        if (tpLayer.HasLayer(0))
                        {
                            string tileId = tpLayer.GetLayer(0).TileId;
                            this.pbTileLayer1.Image = tileInfoController.GetBitmapForTileId(tileId);
                            this.tbTileIdLayer1.Text = tileId;
                        }
                        else
                        {
                            this.pbTileLayer1.Image = Resources.sys_base;
                            this.tbTileIdLayer1.Text = @"None";
                        }

                        if (tpLayer.HasLayer(1))
                        {
                            string tileId = tpLayer.GetLayer(1).TileId;
                            this.pbTileLayer2.Image = tileInfoController.GetBitmapForTileId(tileId);
                            this.tbTileIdLayer2.Text = tileId;
                        }
                        else
                        {
                            this.pbTileLayer2.Image = Resources.sys_base;
                            this.tbTileIdLayer2.Text = @"None";
                        }

                        if (tpLayer.HasLayer(2))
                        {
                            string tileId = tpLayer.GetLayer(2).TileId;
                            this.pbTileLayer3.Image = tileInfoController.GetBitmapForTileId(tileId);
                            this.tbTileIdLayer3.Text = tileId;
                        }
                        else
                        {
                            this.pbTileLayer3.Image = Resources.sys_base;
                            this.tbTileIdLayer3.Text = @"None";
                        }
                    }
                    else
                    {
                        this.tbMovementType.Text = @"Unknown";
                        this.pbTileLayer1.Image = Resources.sys_base;
                        this.tbTileIdLayer1.Text = @"None";
                        this.pbTileLayer2.Image = Resources.sys_base;
                        this.tbTileIdLayer2.Text = @"None";
                        this.pbTileLayer3.Image = Resources.sys_base;
                        this.tbTileIdLayer3.Text = @"None";
                    }
                }
                else
                {
                    ResetTileLayers();
                }
            }
        }

        private void ResetTileLayers()
        {
            this.tbMovementType.Text = @"Unknown";

            this.rbLayerN3.ForeColor = Color.Red;
            this.rbLayerN2.ForeColor = Color.Red;
            this.rbLayerN1.ForeColor = Color.Red;
            this.rbLayer0.ForeColor = Color.Red;
            this.rbLayerP1.ForeColor = Color.Red;
            this.rbLayerP2.ForeColor = Color.Red;
            this.rbLayerP3.ForeColor = Color.Red;

            this.pbTileLayer1.Image = Resources.sys_base;
            this.tbTileIdLayer1.Text = @"None";
            this.pbTileLayer2.Image = Resources.sys_base;
            this.tbTileIdLayer2.Text = @"None";
            this.pbTileLayer3.Image = Resources.sys_base;
            this.tbTileIdLayer3.Text = @"None";
        }

        private int GetSelectedTilePointLayer()
        {
            int tilePointLayer;
            if (!int.TryParse(selectedTileLayer.Text, out tilePointLayer))
            {
                tilePointLayer = 0;
            }
            return tilePointLayer;
        }
    }
}
