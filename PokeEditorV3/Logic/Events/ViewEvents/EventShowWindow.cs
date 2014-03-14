using System;
using WeifenLuo.WinFormsUI.Docking;

namespace PokeEditorV3.Logic.Events.ViewEvents
{
    public class EventShowWindow : ViewEvent
    {
        public Type WindowName { get; set; }
        public DockState DockState { get; set; }

        public EventShowWindow() : base(Events.ShowWindow)
        {
            
        }
    }
}
