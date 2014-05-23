using NoNameLib.UI.Controls.ListView;

namespace PokeEditorV3.Windows
{
    partial class FrmTextureBrowser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newTilesetButton = new System.Windows.Forms.ToolStripButton();
            this.tcTilesets = new System.Windows.Forms.TabControl();
            this.tileView = new NoNameLib.UI.Controls.ListView.ImageListView();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTilesetButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 481);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(405, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newTilesetButton
            // 
            this.newTilesetButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newTilesetButton.Image = global::PokeEditorV3.Properties.Resources.picture_add;
            this.newTilesetButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newTilesetButton.Name = "newTilesetButton";
            this.newTilesetButton.Size = new System.Drawing.Size(23, 22);
            this.newTilesetButton.Text = "New Tileset";
            // 
            // tcTilesets
            // 
            this.tcTilesets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcTilesets.Location = new System.Drawing.Point(0, 0);
            this.tcTilesets.Name = "tcTilesets";
            this.tcTilesets.SelectedIndex = 0;
            this.tcTilesets.Size = new System.Drawing.Size(405, 481);
            this.tcTilesets.TabIndex = 4;
            // 
            // tileView
            // 
            this.tileView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tileView.Location = new System.Drawing.Point(0, 28);
            this.tileView.Name = "tileView";
            this.tileView.Size = new System.Drawing.Size(405, 478);
            this.tileView.TabIndex = 0;
            this.tileView.TileSize = new System.Drawing.Size(32, 32);
            this.tileView.UseCompatibleStateImageBehavior = false;
            this.tileView.View = System.Windows.Forms.View.Tile;
            // 
            // FrmTextureBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 506);
            this.Controls.Add(this.tcTilesets);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tileView);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight)));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmTextureBrowser";
            this.Text = "Texture Browser";
            this.Load += new System.EventHandler(this.FrmTextureBrowser_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ImageListView tileView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TabControl tcTilesets;
        private System.Windows.Forms.ToolStripButton newTilesetButton;
    }
}