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
            this.tileView = new NoNameLib.UI.Controls.ListView.ImageListView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSwitchView = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.directoryView = new System.Windows.Forms.TreeView();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
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
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSwitchView,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(405, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbSwitchView
            // 
            this.tsbSwitchView.Image = global::PokeEditorV3.Properties.Resources.arrow_switch;
            this.tsbSwitchView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSwitchView.Name = "tsbSwitchView";
            this.tsbSwitchView.Size = new System.Drawing.Size(90, 22);
            this.tsbSwitchView.Text = "Switch View";
            this.tsbSwitchView.Click += new System.EventHandler(this.tsbSwitchView_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::PokeEditorV3.Properties.Resources.arrow_refresh;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(66, 22);
            this.toolStripButton1.Text = "Refresh";
            // 
            // directoryView
            // 
            this.directoryView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.directoryView.Location = new System.Drawing.Point(0, 28);
            this.directoryView.Name = "directoryView";
            this.directoryView.Size = new System.Drawing.Size(405, 478);
            this.directoryView.TabIndex = 2;
            // 
            // FrmTextureBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 506);
            this.Controls.Add(this.directoryView);
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
        private System.Windows.Forms.ToolStripButton tsbSwitchView;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TreeView directoryView;
    }
}