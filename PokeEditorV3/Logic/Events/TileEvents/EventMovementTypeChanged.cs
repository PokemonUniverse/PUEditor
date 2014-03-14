using NoNameLib.TileEditor.Enums;

namespace PokeEditorV3.Logic.Events.TileEvents
{
    public class EventMovementTypeChanged : TileEvent
    {
        public MovementTypes MovementType { get; set; }

        public EventMovementTypeChanged(MovementTypes movementType) : base(Events.MovementTypeChanged)
        {
            MovementType = movementType;
        }

        public override bool Validate()
        {
            return true;
        }
    }
}
