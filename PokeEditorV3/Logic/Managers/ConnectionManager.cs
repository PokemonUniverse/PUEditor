using PokeEditorV3.Logic.Events.ConnectionEvents;
using PokeEditorV3.Net;

namespace PokeEditorV3.Logic.Managers
{
    public class ConnectionManager : Manager
    {
        private readonly OrgasmHandler orgasmHandler;

        #region Events

        public delegate void ConnectionStatusChangedEventHandler(object sender, string message);
        public delegate void ConnectToServerFailedEventHandler(object sender, string errorMessage);
        public delegate void ConnectToServerSuccessEventHandler(object sender);

        public event ConnectionStatusChangedEventHandler OnConnectionStatusChanged;
        public event ConnectToServerFailedEventHandler OnConnectToServerFailed;
        public event ConnectToServerSuccessEventHandler OnConnectToServerSuccess;

        #endregion

        public ConnectionManager() 
            : base("ConnectionManager")
        {
            orgasmHandler = new OrgasmHandler();
        }

        public void ConnectToServer(EventConnectToServer connectionEvent)
        {
            ConnectionStatusChanged("Connecting to server.");

            if (orgasmHandler.Connect(connectionEvent.Host))
            {
                ConnectionStatusChanged("Connected. Validating credentials.");

                if (orgasmHandler.Authenticate(connectionEvent.Username, connectionEvent.Password))
                {
                    ConnectionStatusChanged(string.Format("Welcome {0}!", connectionEvent.Username));
                    ConnectToServerSuccess();
                }
                else
                {
                    ConnectionStatusChanged("Supplied credentials are not valid.");
                    ConnectToServerFailed();
                }
            }
            else
            {
                ConnectionStatusChanged("Failed to connect to server.");
                ConnectToServerFailed();
            }
        }

        #region Private Methods

        private void ConnectToServerFailed()
        {
            if (OnConnectToServerFailed != null)
            {
                OnConnectToServerFailed(this, "");
            }
        }

        private void ConnectToServerSuccess()
        {
            if (OnConnectToServerSuccess != null)
            {
                OnConnectToServerSuccess(this);
            }
        }

        private void ConnectionStatusChanged(string message)
        {
            if (OnConnectionStatusChanged != null)
            {
                OnConnectionStatusChanged(this, message);
            }
        }

        #endregion
    }
}
