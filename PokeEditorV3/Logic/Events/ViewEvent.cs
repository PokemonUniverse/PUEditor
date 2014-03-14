using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokeEditorV3.Logic.Events
{
    public class ViewEvent : DispatchableEvent
    {
        public enum Events
        {
            ShowWindow,
            ShowDialog,
        }

        public ViewEvent(Events action)
        {
            this.EventType = EventTypes.ViewEvent;
            this.Action = action;
        }

        public override bool Validate()
        {
            return true;
        }
    }
}
