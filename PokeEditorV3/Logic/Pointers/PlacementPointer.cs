using System.Windows.Forms;
using NoNameLib.Extension;
using NoNameLib.TileEditor.Collections;
using PokeEditorV3.Logic.Managers;

namespace PokeEditorV3.Logic.Pointers
{
    public class PlacementPointer : IPointer
    {
        private bool isMouseDown;
        private TilePoint lastTilePointPosition;

        public new PointerTypes GetType()
        {
            return PointerTypes.Placement;
        }

        public PointerResult Click(int mapId, TilePoint tp, MouseButtons button)
        {
            return null; // Do nothing
        }

        public PointerResult Down(int mapId, TilePoint tp, MouseButtons button)
        {
            var result = new PointerResult();

            if (button == MouseButtons.Left || button == MouseButtons.Right)
            {
                lastTilePointPosition = tp;
                isMouseDown = true;

                result.InvokeRender = PlaceTile(mapId, tp, button);
            }

            return result;
        }

        public PointerResult Up(int mapId, TilePoint tp, MouseButtons button)
        {
            lastTilePointPosition = null;
            isMouseDown = false;

            return null;
        }

        public PointerResult Move(int mapId, TilePoint tp, MouseButtons button)
        {
            var result = new PointerResult();

            if (isMouseDown && lastTilePointPosition != tp)
            {
                result.InvokeRender = PlaceTile(mapId, tp, button);
            }

            return result;
        }

        public PointerResult Hover(int mapId, TilePoint tp)
        {
            return null;
        }

        private bool PlaceTile(int mapId, TilePoint tp, MouseButtons button)
        {
            var tileManager = GlobalManager.GetManager<TileManager>();

            // Get active tile based on which mouse button is pressed
            int[][] selectedSprites = tileManager.SelectedSprites;

            // Don't place tile if we dont have a tile selected
            if (selectedSprites.Length == 0)
                return false;

            // Fetch TilePointTable for mapId
            TilePointTable tilePointTable;
            tileManager.GetTilePointTableForMap(mapId, out tilePointTable);

            bool tileChanged = false;
            for (int x = 0; x < selectedSprites.Length; x++)
            {
                for (int y = 0; y < selectedSprites[x].Length; y++)
                {
                    int tpX = tp.X + x;
                    int tpY = tp.Y + y;

                    // Get TilePoint from table, creates new if it doesn't exists
                    var tilePoint = tilePointTable.GetTilePoint(tpX, tpY);
                    tileChanged = tilePoint.IsNew;

                    // Get TilePointLayer, creates new if it doesnt already exists
                    var tpLayer = tilePoint.GetLayer(TileManager.DEFAULT_LAYER, true);
                    if (tpLayer.Movement != tileManager.MovementType)
                    {
                        tpLayer.Movement = tileManager.MovementType;
                        tileChanged = true;
                    }

                    // Get TilePointTileLayer, create new if it doesn't already exists
                    var tpTileLayer = tpLayer.GetLayer(tileManager.GetCurrentLayer(), true);
                    if (tpTileLayer.TileId != selectedSprites[x][y])
                    {
                        tpTileLayer.TileId = selectedSprites[x][y];
                        tileChanged = true;
                    }

                    // Add TilePoint to TilePointTable if it's new
                    if (tilePoint.IsNew)
                        tilePointTable.AddTilePoint(tp);
                }
            }

            // TODO: Send ConnectionEvent with the tile data, only if tile is changed!

            return tileChanged;
        }
    }
}
