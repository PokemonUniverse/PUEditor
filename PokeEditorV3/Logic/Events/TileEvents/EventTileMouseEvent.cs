using System.Windows.Forms;
using NoNameLib.TileEditor.Collections;

namespace PokeEditorV3.Logic.Events.TileEvents
{
    public class EventTileMouseEvent : TileEvent
    {
        public enum MouseEvents
        {
            Click,
            Up,
            Down,
            Move,
            Leave
        }

        public int MapId { get; set; }
        public MouseEvents MouseEvent { get; set; }
        public TilePoint TilePoint { get; set; }
        public MouseButtons MouseButton { get; set; }

        public EventTileMouseEvent(int mapId, MouseEvents mouseEvent) : base(Events.TileMouseEvent)
        {
            MapId = mapId;
            MouseEvent = mouseEvent;
        }

        public override bool Validate()
        {
            return true;
        }
    }
}
