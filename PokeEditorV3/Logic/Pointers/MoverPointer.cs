using System.Drawing;
using System.Windows.Forms;
using NoNameLib.TileEditor.Collections;

namespace PokeEditorV3.Logic.Pointers
{
    public class MoverPointer : IPointer
    {
        private bool isMouseDown;
        private TilePoint mouseDownStart;

        public new PointerTypes GetType()
        {
            return PointerTypes.Mover;
        }

        public PointerResult Click(int mapId, TilePoint tp, MouseButtons button)
        {
            return null;
        }

        public PointerResult Down(int mapId, TilePoint tp, MouseButtons button)
        {
            if (button == MouseButtons.Left)
            {
                isMouseDown = true;
                mouseDownStart = tp;
            }

            return null;
        }

        public PointerResult Up(int mapId, TilePoint tp, MouseButtons button)
        {
            isMouseDown = false;
            mouseDownStart = null;

            return null;
        }

        public PointerResult Move(int mapId, TilePoint tp, MouseButtons button)
        {
            var result = new PointerResult();

            if (isMouseDown && button == MouseButtons.Left)
            {
                var diff = TilePoint.Difference(mouseDownStart, tp);
                var translatePoint = new Point(0, 0);

                if (diff.X > 0)
                    translatePoint.X = 1;
                else if (diff.X < 0)
                    translatePoint.X = -1;

                if (diff.Y > 0)
                    translatePoint.Y = 1;
                else if (diff.Y < 0)
                    translatePoint.Y = -1;

                if (translatePoint.X != 0 && translatePoint.Y != 0)
                {
                    result.InvokeTranslate = true;
                    result.InvokeRender = true;
                    result.TranslatePoint = translatePoint;
                }
            }

            return result;
        }

        public PointerResult Hover(int mapId, TilePoint tp)
        {
            return null;
        }
    }
}
