using System.Windows.Forms;
using NoNameLib.TileEditor.Collections;
using PokeEditorV3.Logic.Managers;

namespace PokeEditorV3.Logic.Pointers
{
    public class EraserPointer : IPointer
    {
        private bool isMouseDown;
        private TilePoint lastTilePoint;

        public new PointerTypes GetType()
        {
            return PointerTypes.Eraser;
        }

        public PointerResult Click(int mapId, TilePoint tp, MouseButtons button)
        {
            return null;
        }

        public PointerResult Down(int mapId, TilePoint tp, MouseButtons button)
        {
            var result = new PointerResult();

            if (button == MouseButtons.Left)
            {
                isMouseDown = true;
                lastTilePoint = tp;

                result.InvokeRender = EraseTile(mapId, tp);
            }

            return result;
        }

        public PointerResult Up(int mapId, TilePoint tp, MouseButtons button)
        {
            isMouseDown = false;
            lastTilePoint = null;

            return null;
        }

        public PointerResult Move(int mapId, TilePoint tp, MouseButtons button)
        {
            var result = new PointerResult();

            if (isMouseDown && button == MouseButtons.Left && lastTilePoint != tp)
            {
                result.InvokeRender = EraseTile(mapId, tp);
            }

            return result;
        }

        public PointerResult Hover(int mapId, TilePoint tp)
        {
            return null;
        }

        private bool EraseTile(int mapId, TilePoint tp)
        {
            var tileManager = GlobalManager.GetManager<TileManager>();
            TilePointTable tilePointTable;
            tileManager.GetTilePointTableForMap(mapId, out tilePointTable);

            var tilePoint = tilePointTable.GetTilePoint(tp.X, tp.Y, false);
            if (tilePoint != null)
            {
                foreach (var tilePointLayer in tilePoint.Layers.Values)
                {
                    tilePointLayer.TileLayers.Clear();
                }
                tilePoint.Layers.Clear();

                // TODO: Send ConnectionEvent with the erased tile data
            }

            return (tilePoint != null);
        }
    }
}
