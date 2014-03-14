namespace PokeEditorV3.Windows
{
    partial class FrmTileEditor
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
            this.tsEditorMenu = new System.Windows.Forms.ToolStrip();
            this.OpenGlControl = new OpenTK.GLControl();
            this.SuspendLayout();
            // 
            // tsEditorMenu
            // 
            this.tsEditorMenu.Location = new System.Drawing.Point(0, 0);
            this.tsEditorMenu.Name = "tsEditorMenu";
            this.tsEditorMenu.Size = new System.Drawing.Size(659, 25);
            this.tsEditorMenu.TabIndex = 0;
            this.tsEditorMenu.Text = "toolStrip1";
            // 
            // OpenGlControl
            // 
            this.OpenGlControl.BackColor = System.Drawing.Color.Black;
            this.OpenGlControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OpenGlControl.Location = new System.Drawing.Point(0, 25);
            this.OpenGlControl.Name = "OpenGlControl";
            this.OpenGlControl.Size = new System.Drawing.Size(659, 402);
            this.OpenGlControl.TabIndex = 2;
            this.OpenGlControl.VSync = false;
            // 
            // FrmTileEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 427);
            this.Controls.Add(this.OpenGlControl);
            this.Controls.Add(this.tsEditorMenu);
            this.DockAreas = WeifenLuo.WinFormsUI.Docking.DockAreas.Document;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmTileEditor";
            this.Text = "FrmTileEditor";
            this.Load += new System.EventHandler(this.FrmTileEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsEditorMenu;
        private OpenTK.GLControl OpenGlControl;
    }
}