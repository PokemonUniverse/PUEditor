using System.Drawing;
using System.Windows.Forms;
using NoNameLib.TileEditor.Collections;

namespace PokeEditorV3.Logic.Pointers
{
    public enum PointerTypes
    {
        Placement,
        Eraser,
        Dropper,
        Mover,
        Selector,
        Npcplacer
    }

    public interface IPointer
    {
        PointerTypes GetType();
        PointerResult Click(int mapId, TilePoint tp, MouseButtons button);
        PointerResult Down(int mapId, TilePoint tp, MouseButtons button);
        PointerResult Up(int mapId, TilePoint tp, MouseButtons button);
        PointerResult Move(int mapId, TilePoint tp, MouseButtons button);
        PointerResult Hover(int mapId, TilePoint tp);
    }

    public class PointerResult
    {
        public bool InvokeRender { get; set; }
        public bool InvokeTranslate { get; set; }
        public Point TranslatePoint { get; set; }

        public PointerResult()
        {
            InvokeRender = false;
            InvokeTranslate = false;
        }
    }
}
