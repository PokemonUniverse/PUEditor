using System;
using System.Drawing;
using System.Windows.Forms;
using NoNameLib.TileEditor;
using NoNameLib.TileEditor.Collections;
using NoNameLib.TileEditor.Enums;
using PokeEditorV3.Logic.Events.TileEvents;
using PokeEditorV3.Logic.Managers;
using PokeEditorV3.Logic.Pointers;

namespace PokeEditorV3.Logic.Windows
{
    public class TileEditorController
    {
        private bool isOpenGLInitialized;

        private readonly TileEngine tileEngine;
        private readonly int mapId;

        private TilePoint lastTilePoint;

        private TilePointTable tilePointTableCached = new TilePointTable();

        #region Ctor

        public TileEditorController(int mapId)
        {
            this.isOpenGLInitialized = false;
            this.tileEngine = new TileEngine();
            this.mapId = mapId;
            this.lastTilePoint = new TilePoint(0, 0);

            HookupEvents();

            // Some default values
            SetPointer(PointerTypes.Placement);
            SetMovementType(MovementTypes.Walk);
            SetTileSize(32);
        }

        #endregion

        #region Event Handlers

        private void HookupEvents()
        {
            var tm = GlobalManager.GetManager<TileManager>();
            tm.OnRenderInvoked += TileManagerOnRenderInvoked;
            tm.OnTranslateViewport += TileManagerOnTranslateViewport;
        }

        private void TileManagerOnRenderInvoked(object sender, int invokedMapId, ref TilePointTable tilePointTable)
        {
            if (invokedMapId != this.mapId)
                return;

            tilePointTableCached = tilePointTable;
            InternalDoRender(tilePointTableCached);
        }

        private void TileManagerOnTranslateViewport(object sender, int invokedMapId, Point point)
        {
            if (invokedMapId != this.mapId)
                return;

            this.tileEngine.TranslateMap(point);
            InternalDoRender(tilePointTableCached);
        }

        #endregion

        #region Events

        public delegate void RenderingCompleteEventHanlder();

        /// <summary>
        /// Event is called after the TileEngine render method has finished.
        /// </summary>
        public event RenderingCompleteEventHanlder OnRenderingComplete;

        #endregion

        #region Rendering

        /// <summary>
        /// Initialize OpenGL. This method should be called on Form_Load before any rendering is done.
        /// </summary>
        public void InitializeOpenGL()
        {
            tileEngine.Initialize();
            isOpenGLInitialized = true;

            string textureKey = this.tileEngine.AddTexture("e:\\Users\\Mr_Dark\\Dropbox\\Pokemon Universe\\Mapping\\util\\Pokemon Universe Tileset 2.png");
            Console.WriteLine("Texture: " + textureKey);
        }

        /// <summary>
        /// Change the size of the ViewPort. Recommended to call this on window size change.
        /// </summary>
        /// <param name="width">ViewPort width</param>
        /// <param name="height">ViewPort height</param>
        /// <param name="forceRender">Optional boolean to force the re-render of the OpenGL control. Default is true.</param>
        public void SetMapSize(int width, int height, bool forceRender = true)
        {
            tileEngine.SetMapSize(height, width);

            if (forceRender)
            {
                InternalDoRender(tilePointTableCached);
            }
        }

        /// <summary>
        /// Force the re-render of OpenGL control with the latest TilePointTable
        /// </summary>
        public void DoRender()
        {
            TilePointTable tpTable;
            var tm = GlobalManager.GetManager<TileManager>();
            tm.GetTilePointTableForMap(this.mapId, out tpTable);

            if (tpTable != null)
            {
                InternalDoRender(tpTable);
            }
        }

        /// <summary>
        /// Internal rendering method. This actually initiates the rendering logic of <see cref="TileEngine"/>
        /// </summary>
        /// <param name="tilePointTable"><see cref="TilePointTable"/> data to render on screen</param>
        private void InternalDoRender(TilePointTable tilePointTable)
        {
            if (!isOpenGLInitialized)
                return;

            tileEngine.DoRender(ref tilePointTable);

            if (OnRenderingComplete != null)
            {
                OnRenderingComplete();
            }
        }

        #endregion

        #region Mouse Movements

        public void MouseDown(Point location, MouseButtons button)
        {
            var tilepoint = tileEngine.GetTilePointCoordinatesFromScreen(location.X, location.Y);
            this.lastTilePoint = tilepoint;

            var mouseEvent = new EventTileMouseEvent(this.mapId, EventTileMouseEvent.MouseEvents.Down);
            mouseEvent.TilePoint = tilepoint;
            mouseEvent.MouseButton = button;
            mouseEvent.Post();
        }

        public void MouseUp(Point location, MouseButtons button)
        {
            var tilepoint = tileEngine.GetTilePointCoordinatesFromScreen(location.X, location.Y);
            this.lastTilePoint = tilepoint;

            var mouseEvent = new EventTileMouseEvent(this.mapId, EventTileMouseEvent.MouseEvents.Up);
            mouseEvent.TilePoint = tilepoint;
            mouseEvent.MouseButton = button;
            mouseEvent.Post();
        }

        public void MouseClick(Point location, MouseButtons button)
        {
            var tilepoint = tileEngine.GetTilePointCoordinatesFromScreen(location.X, location.Y);
            this.lastTilePoint = tilepoint;

            var mouseEvent = new EventTileMouseEvent(this.mapId, EventTileMouseEvent.MouseEvents.Click);
            mouseEvent.TilePoint = tilepoint;
            mouseEvent.MouseButton = button;
            mouseEvent.Post();
        }

        public void MouseMove(Point location, MouseButtons button)
        {
            var tilepoint = tileEngine.GetTilePointCoordinatesFromScreen(location.X, location.Y);
            if (!tilepoint.Equals(lastTilePoint))
            {
                this.lastTilePoint = tilepoint;

                var mouseEvent = new EventTileMouseEvent(this.mapId, EventTileMouseEvent.MouseEvents.Move);
                mouseEvent.TilePoint = tilepoint;
                mouseEvent.MouseButton = button;
                mouseEvent.Post();
            }
        }

        public void MouseLeave()
        {
            this.lastTilePoint = null;

            var mouseEvent = new EventTileMouseEvent(this.mapId, EventTileMouseEvent.MouseEvents.Leave);
            mouseEvent.Post();
        }

        #endregion

        #region Toolbar

        /// <summary>
        /// Change the active tile editor pointer.
        /// </summary>
        /// <param name="pointerType">New active pointer type</param>
        public void SetPointer(PointerTypes pointerType)
        {
            var pointerEvent = new EventPointerChanged(this.mapId, pointerType);
            pointerEvent.Post();
        }

        /// <summary>
        /// Change the active movement type.
        /// </summary>
        /// <param name="movementType">New active movement type</param>
        public void SetMovementType(MovementTypes movementType)
        {
            var movementEvent = new EventMovementTypeChanged(movementType);
            movementEvent.Post();
        }

        /// <summary>
        /// Change the rendering size of the tiles. OpenGL control is re-rendered on change.
        /// </summary>
        /// <param name="tilesize">New tile size. It's adviced to keep it size in a power of 2</param>
        public void SetTileSize(int tilesize)
        {
            tileEngine.SetTileSize(tilesize);
            InternalDoRender(tilePointTableCached);
        }

        #endregion
    }
}
