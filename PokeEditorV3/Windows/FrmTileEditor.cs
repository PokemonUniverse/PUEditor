using System;
using System.Windows.Forms;
using PokeEditorV3.Logic.Windows;
using WeifenLuo.WinFormsUI.Docking;

namespace PokeEditorV3.Windows
{
    public partial class FrmTileEditor : DockContent
    {
        readonly TileEditorController tileEditorController;

        public FrmTileEditor()
        {
            InitializeComponent();

            tileEditorController = new TileEditorController(0);

            HookupEvents();
        }

        private void HookupEvents()
        {
            // Form controller
            tileEditorController.OnRenderingComplete += tileEditorController_OnRenderingComplete;

            // OpenGL control
            this.OpenGlControl.Paint += OpenGlControl_Paint;
            this.OpenGlControl.MouseClick += OpenGlControl_MouseClick;
            this.OpenGlControl.MouseDown += OpenGlControl_MouseDown;
            this.OpenGlControl.MouseLeave += OpenGlControl_MouseLeave;
            this.OpenGlControl.MouseMove += OpenGlControl_MouseMove;
            this.OpenGlControl.MouseUp += OpenGlControl_MouseUp;
            this.OpenGlControl.Resize += OpenGlControl_Resize;
        }

        void tileEditorController_OnRenderingComplete()
        {
            OpenGlControl.SwapBuffers();
        }       

        #region Window Events

        private void FrmTileEditor_Load(object sender, EventArgs e)
        {
            InitializeOpenGL();
        }

        #endregion

        #region OpenGlControl Events
        
        private void OpenGlControl_Paint(object sender, PaintEventArgs e)
        {
            this.tileEditorController.DoRender();
        }

        private void OpenGlControl_Resize(object sender, EventArgs e)
        {
            this.tileEditorController.SetMapSize(this.OpenGlControl.Width, this.OpenGlControl.Height);
        }

        private void OpenGlControl_MouseUp(object sender, MouseEventArgs e)
        {
            this.tileEditorController.MouseUp(e.Location, e.Button);
        }

        private void OpenGlControl_MouseMove(object sender, MouseEventArgs e)
        {
            this.tileEditorController.MouseMove(e.Location, e.Button);
        }

        private void OpenGlControl_MouseLeave(object sender, EventArgs e)
        {
            this.tileEditorController.MouseLeave();
        }

        private void OpenGlControl_MouseDown(object sender, MouseEventArgs e)
        {
            this.tileEditorController.MouseDown(e.Location, e.Button);
        }

        private void OpenGlControl_MouseClick(object sender, MouseEventArgs e)
        {
            this.tileEditorController.MouseClick(e.Location, e.Button);
        }

        #endregion

        private void InitializeOpenGL()
        {
            this.tileEditorController.InitializeOpenGL();
        }
    }
}
