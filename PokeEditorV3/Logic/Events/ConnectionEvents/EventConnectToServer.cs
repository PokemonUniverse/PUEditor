namespace PokeEditorV3.Logic.Events.ConnectionEvents
{
    public class EventConnectToServer : ConnectionEvent
    {
        #region Fields

        public string Host { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        #endregion

        public EventConnectToServer() 
            : this("", "", "")
        {
        }

        public EventConnectToServer(string host, string username, string password)
            : base(Events.ConnectToServer)
        {
            Host = host;
            Username = username;
            Password = password;
        }

        public override bool Validate()
        {
            return true;
        }
    }
}
