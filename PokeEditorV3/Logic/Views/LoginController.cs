using NoNameLib.Attributes;
using NoNameLib.Extension;
using PokeEditorV3.Logic.Events.ConnectionEvents;
using PokeEditorV3.Logic.Exceptions;
using PokeEditorV3.Logic.Managers;

namespace PokeEditorV3.Logic.Views
{
    public class LoginController
    {
        public enum LoginExceptions
        {
            [StringValue("No host supplied")]
            NoHostSupplied,

            [StringValue("No username or password supplied")]
            NoUsernamePasswordSupplied
        }

        #region Events

        public delegate void ConnectionStatusChangedEventHandler(object sender, string message);
        public delegate void ConnectToServerFailedEventHandler(object sender, string errorMessage);
        public delegate void ConnectToServerSuccessEventHandler(object sender);

        public event ConnectionStatusChangedEventHandler OnConnectionStatusChanged;
        public event ConnectToServerFailedEventHandler OnConnectToServerFailed;
        public event ConnectToServerSuccessEventHandler OnConnectToServerSuccess;

        #endregion

        public LoginController()
        {
            // Hook events
            var connectionManager = GlobalManager.GetManager<ConnectionManager>();
            connectionManager.OnConnectToServerFailed += ConnectToServerFailed;
            connectionManager.OnConnectToServerSuccess += ConnectToServerSuccess;
            connectionManager.OnConnectionStatusChanged += ConnectionStatusChanged;
        }

        public void Login(string host, string username, string password)
        {
            if (host.IsNullOrWhiteSpace())
            {
                throw new ControllerException(LoginExceptions.NoHostSupplied);
            }
            if (username.IsNullOrWhiteSpace() || password.IsNullOrWhiteSpace())
            {
                throw new ControllerException(LoginExceptions.NoUsernamePasswordSupplied);
            }

            var connectEvent = new EventConnectToServer();
            connectEvent.Host = host.Trim();
            connectEvent.Username = username.Trim();
            connectEvent.Password = password.Trim();
            connectEvent.PostWorkerThread();
        }

        #region Event Handlers

        void ConnectToServerFailed(object sender, string errorMessage)
        {
            if (OnConnectToServerFailed != null)
            {
                OnConnectToServerFailed(sender, errorMessage);
            }
        }

        void ConnectToServerSuccess(object sender)
        {
            if (OnConnectToServerSuccess != null)
            {
                OnConnectToServerSuccess(sender);
            }
        }

        void ConnectionStatusChanged(object sender, string message)
        {
            if (OnConnectionStatusChanged != null)
            {
                OnConnectionStatusChanged(sender, message);
            }
        }

        #endregion
    }
}
