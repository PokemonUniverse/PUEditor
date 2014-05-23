using System;
using System.Collections.Generic;
using System.Drawing;
using NoNameLib.Debug;
using NoNameLib.Enums;
using NoNameLib.TileEditor.Collections;
using NoNameLib.TileEditor.Enums;
using PokeEditorV3.Logic.Events.TileEvents;
using PokeEditorV3.Logic.Exceptions;
using PokeEditorV3.Logic.Pointers;

namespace PokeEditorV3.Logic.Managers
{
    public class TileManager : Manager
    {
        private enum TileManagerException
        {
            MapDoesNotExists,
            NoEditorPointerSet
        }
        
        private readonly Dictionary<int, TilePointTable> masterTilePointDictionary = new Dictionary<int, TilePointTable>();
        private IPointer editorPointer;

        #region Public Properties

        /// <summary>
        /// TEMP VALUE FOR DEFAULT LAYER
        /// </summary>
        public const int DEFAULT_LAYER = 0;

        public int[][] SelectedSprites { get; private set; }
        public MovementTypes MovementType { get; private set; }

        #endregion

        #region Events

        public delegate void InvokeRenderEventHandler(object sender, int mapId, ref TilePointTable tilePointTable);
        public delegate void InvokeTranslateViewportEventHandler(object sender, int mapId, Point point);
        public delegate void MouseTileHoverEventHandler(object sender, TilePoint tp);

        public event InvokeRenderEventHandler OnRenderInvoked;
        public event InvokeTranslateViewportEventHandler OnTranslateViewport;
        public event MouseTileHoverEventHandler OnMouseTileHover;

        #endregion

        #region Ctor

        public TileManager() : base("TileManager")
        {
            if (TestUtil.IsPcMrDark) 
            {
                masterTilePointDictionary.Add(0, new TilePointTable());
            }
        }

        #endregion

        #region Public Methods

        public void GetTilePointTableForMap(int mapId, out TilePointTable tilePointTable)
        {
            if (mapId < 0 || !masterTilePointDictionary.TryGetValue(mapId, out tilePointTable))
            {
                throw new ManagerException(TileManagerException.MapDoesNotExists, "Map with id '{0}' could not be found.", mapId);
            }
        }

        /// <summary>
        /// Returns the layer id based on pressed keys
        /// </summary>
        /// <returns>Current layer as Integer</returns>
        public int GetCurrentLayer()
        {
            int currentLayer = 1;

            var inputManager = GlobalManager.GetManager<KeyInputManager>();
            if (inputManager.IsKeyPressed(KeysEnum.Shift))
            {
                if (inputManager.IsKeyPressed(KeysEnum.Alt))
                {
                    currentLayer = 2;
                }
                else
                {
                    currentLayer = 0;
                }
            }

            return currentLayer;
        }

        #endregion

        #region EventDispatcher Handlers

        public void PointerChanged(EventPointerChanged tileEvent)
        {
            switch (tileEvent.PointerType)
            {
                case PointerTypes.Placement:
                    editorPointer = new PlacementPointer();
                    break;
                case PointerTypes.Eraser:
                    editorPointer = new EraserPointer();
                    break;
                case PointerTypes.Dropper:
                    break;
                case PointerTypes.Mover:
                    editorPointer = new MoverPointer();
                    break;
                case PointerTypes.Selector:
                    break;
                case PointerTypes.Npcplacer:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(string.Format("Pointer of type '{0}' is not implemented in TileManager.", tileEvent.PointerType));
            }
        }

        public void TileMouseEvent(EventTileMouseEvent mouseEvent)
        {
            if (editorPointer == null)
            {
                throw new ManagerException(TileManagerException.NoEditorPointerSet, "There is no editor pointer set, probably forgot to fire off a PointerChanged event.");
            }

            PointerResult pointerResult = null;
            switch (mouseEvent.MouseEvent)
            {
                case EventTileMouseEvent.MouseEvents.Click:
                    pointerResult = editorPointer.Click(mouseEvent.MapId, mouseEvent.TilePoint, mouseEvent.MouseButton);
                    break;
                case EventTileMouseEvent.MouseEvents.Up:
                    pointerResult = editorPointer.Up(mouseEvent.MapId, mouseEvent.TilePoint, mouseEvent.MouseButton);
                    break;
                case EventTileMouseEvent.MouseEvents.Down:
                    pointerResult = editorPointer.Down(mouseEvent.MapId, mouseEvent.TilePoint, mouseEvent.MouseButton);
                    break;
                case EventTileMouseEvent.MouseEvents.Move:
                    pointerResult = editorPointer.Move(mouseEvent.MapId, mouseEvent.TilePoint, mouseEvent.MouseButton);
                    break;
                case EventTileMouseEvent.MouseEvents.Leave:
                    break;
            }

            if (pointerResult != null)
            {
                // Always translate first before rendering
                if (pointerResult.InvokeTranslate)
                {
                    InvokeTranslateViewport(mouseEvent.MapId, pointerResult.TranslatePoint);
                }

                if (pointerResult.InvokeRender)
                {
                    InvokeRender(mouseEvent.MapId);    
                }
            }

            // If something has subscribed to this event, get data to send
            if (OnMouseTileHover != null)
            {
                // Get TilePoint from table
                TilePointTable tilePointTable;
                GetTilePointTableForMap(mouseEvent.MapId, out tilePointTable);

                TilePoint tilePoint = null;
                if (mouseEvent.TilePoint != null)
                    tilePoint = tilePointTable.GetTilePoint(mouseEvent.TilePoint.X, mouseEvent.TilePoint.Y, false);

                // If there is no TilePoint placed, send mouse TilePoint for coordinates
                if (tilePoint == null)
                    tilePoint = mouseEvent.TilePoint;

                MouseTileHover(tilePoint);
            }

        }

        public void MovementTypeChanged(EventMovementTypeChanged changedEvent)
        {
            this.MovementType = changedEvent.MovementType;
        }

        #endregion

        public void SetSelectedSprites(int sprites)
        {
            SelectedSprites = new[] {new[] {sprites}};
        }

        public void SetSelectedSprites(int[][] sprites)
        {
            SelectedSprites = sprites;
        }

        #region Private Method

        private void InvokeRender(int mapId)
        {
            if (OnRenderInvoked != null)
            {
                TilePointTable tpTable;
                GetTilePointTableForMap(mapId, out tpTable);
                OnRenderInvoked(this, mapId, ref tpTable);
            }
        }

        private void InvokeTranslateViewport(int mapId, Point point)
        {
            if (OnTranslateViewport != null)
            {
                OnTranslateViewport(this, mapId, point);
            }
        }

        private void MouseTileHover(TilePoint tp)
        {
            if (OnMouseTileHover != null)
            {
                OnMouseTileHover(this, tp);
            }
        }

        #endregion
    }
}
