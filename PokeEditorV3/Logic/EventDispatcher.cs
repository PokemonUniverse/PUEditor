using System;
using System.Threading;
using System.Threading.Tasks;
using PokeEditorV3.Logic.Events;
using PokeEditorV3.Logic.Events.ConnectionEvents;
using PokeEditorV3.Logic.Events.KeyInputEvents;
using PokeEditorV3.Logic.Events.TileEvents;
using PokeEditorV3.Logic.Events.ViewEvents;
using PokeEditorV3.Logic.Managers;

namespace PokeEditorV3.Logic
{
    public static class EventDispatcher
    {
        private static void DispatchEvent(object dispatchableEvent)
        {
            DispatchEvent((DispatchableEvent)dispatchableEvent);
        }

        /// <summary>
        /// Dispatch event on new thread. Usable for long running operations so the UI won't block.
        /// </summary>
        /// <param name="dispatchableEvent">Event to dispatch</param>
        public static void DispatchEventOnWorkerThread(DispatchableEvent dispatchableEvent)
        {
            Task.Factory.StartNew(() => DispatchEvent(dispatchableEvent));
        }

        /// <summary>
        /// Dispatch event on main UI thread. Usable for when an event has to update UI components.
        /// </summary>
        /// <param name="dispatchableEvent"></param>
        public static void DispatchEventOnUiThread(DispatchableEvent dispatchableEvent)
        {
            Program.Context.Send(DispatchEvent, dispatchableEvent);
        }

        /// <summary>
        /// Dispatch event on current thread. Default.
        /// </summary>
        /// <param name="dispatchableEvent"></param>
        public static void DispatchEvent(DispatchableEvent dispatchableEvent)
        {
            switch (dispatchableEvent.EventType)
            {
                case DispatchableEvent.EventTypes.StartupEvent:
                    HandleStartupEvent((StartupEvent)dispatchableEvent);
                    break;
                case DispatchableEvent.EventTypes.ApplicationEvent:
                    break;
                case DispatchableEvent.EventTypes.ConnectionEvent:
                    HandleConnectionEvent((ConnectionEvent)dispatchableEvent);
                    break;
                case DispatchableEvent.EventTypes.TileEvent:
                    HandleTileEvent((TileEvent)dispatchableEvent);
                    break;
                case DispatchableEvent.EventTypes.KeyInputEvent:
                    HandleKeyInputEvent((KeyInputEvent)dispatchableEvent);
                    break;
                case DispatchableEvent.EventTypes.ViewEvent:
                    HandleViewEvent((ViewEvent) dispatchableEvent);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(string.Format("EventType '{0}' is not handled in the EventDispatcher.", dispatchableEvent.EventType));
            }

            if (dispatchableEvent.Callback != null)
            {
                dispatchableEvent.Callback();
            }
        }

        private static void HandleStartupEvent(StartupEvent startupEvent)
        {
            var manager = GlobalManager.GetManager<StartupManager>();
            switch ((StartupEvent.Events) startupEvent.Action)
            {
                case StartupEvent.Events.Initialize:
                    manager.InitStartup();
                    break;
                case StartupEvent.Events.ValidateConfiguration:
                    manager.ValidateConfiguration();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(string.Format("StartupEvent '{0}' is not handled in the EventDispatcher.", startupEvent.Action));
            }
        }

        private static void HandleConnectionEvent(ConnectionEvent connectionEvent)
        {
            var manager = GlobalManager.GetManager<ConnectionManager>();
            switch ((ConnectionEvent.Events)connectionEvent.Action)
            {
                case ConnectionEvent.Events.ConnectToServer:
                    manager.ConnectToServer((EventConnectToServer)connectionEvent);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(string.Format("ConnectionEvent '{0}' is not handled in the EventDispatcher.", connectionEvent.Action));
            }
        }

        private static void HandleTileEvent(TileEvent tileEvent)
        {
            var manager = GlobalManager.GetManager<TileManager>();
            switch ((TileEvent.Events)tileEvent.Action)
            {
                case TileEvent.Events.PointerChanged:
                    manager.PointerChanged((EventPointerChanged)tileEvent);
                    break;
                case TileEvent.Events.TileMouseEvent:
                    manager.TileMouseEvent((EventTileMouseEvent)tileEvent);
                    break;
                case TileEvent.Events.MovementTypeChanged:
                    manager.MovementTypeChanged((EventMovementTypeChanged)tileEvent);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(string.Format("TileEvent '{0}' is not handled in the EventDispatcher.", tileEvent.Action));
            }
        }

        private static void HandleKeyInputEvent(KeyInputEvent keyInputEvent)
        {
            var manager = GlobalManager.GetManager<KeyInputManager>();
            switch ((KeyInputEvent.Events) keyInputEvent.Action)
            {
                case KeyInputEvent.Events.KeyPressDown:
                    manager.SetKeyPressDown((EventKeyPressDown)keyInputEvent);
                    break;
                case KeyInputEvent.Events.KeyPressUp:
                    manager.SetKeyPressUp((EventKeyPressUp)keyInputEvent);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(string.Format("KeyInputEvent '{0}' is not handled in the EventDispatcher.", keyInputEvent.Action));
            }
        }

        private static void HandleViewEvent(ViewEvent viewEvent)
        {
            var manager = GlobalManager.GetManager<ViewManager>();
            switch ((ViewEvent.Events) viewEvent.Action)
            {
                case ViewEvent.Events.ShowWindow:
                    manager.ShowWindow((EventShowWindow)viewEvent);
                    break;
                case ViewEvent.Events.ShowDialog:
                    manager.ShowDialog((EventShowDialog)viewEvent);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
