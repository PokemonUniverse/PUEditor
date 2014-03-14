using PokeEditorV3.Logic.Pointers;

namespace PokeEditorV3.Logic.Events.TileEvents
{
    public class EventPointerChanged : TileEvent
    {
        public PointerTypes PointerType { get; private set; }
        public int MapId { get; set; }

        public EventPointerChanged(int mapId, PointerTypes pointerType) : base(Events.PointerChanged)
        {
            MapId = mapId;
            PointerType = pointerType;
        }

        public override bool Validate()
        {
            return true;
        }
    }
}
