using System;
using System.Threading;
using System.Windows.Forms;
using NoNameLib.Extension;
using PokeEditorV3.Logic.Exceptions;
using PokeEditorV3.Logic.Views;

namespace PokeEditorV3.Views
{
    public partial class FrmLogin : Form
    {
        private readonly LoginController loginController;

        #region Ctor 

        public FrmLogin()
        {
            InitializeComponent();

            // Set global context (should be from main window)
            Program.Context = SynchronizationContext.Current;

            // Setup controller
            loginController = new LoginController();
            loginController.OnConnectToServerFailed += OnConnectToServerFailed;
            loginController.OnConnectToServerSuccess += OnConnectToServerSuccess;
            loginController.OnConnectionStatusChanged += OnConnectionStatusChanged;
        }

        #endregion

        #region Event Handlers

        void OnConnectToServerFailed(object sender, string errorMessage)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<object, string>(OnConnectToServerFailed), sender, errorMessage);
                return;
            }
            
            this.btnExit.Enabled = true;
            this.btnLogin.Enabled = true;
        }

        void OnConnectToServerSuccess(object sender)
        {
            DialogResult = DialogResult.OK;
        }

        void OnConnectionStatusChanged(object sender, string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<object, string>(OnConnectionStatusChanged), sender, message);
                return;
            }

            this.lblConnectionStatus.Text = message;
        }

        #endregion

        #region Form Control Events

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.gbAuthenticate.Enabled = false;
            this.btnExit.Enabled = false;
            this.btnLogin.Enabled = false;

            try
            {
                loginController.Login(tbServer.Text, tbUsername.Text, tbPassword.Text);
            }
            catch (ControllerException cex)
            {
                this.gbAuthenticate.Enabled = true;
                this.btnExit.Enabled = true;
                this.btnLogin.Enabled = true;

                // Reset any previous errors
                this.errorProvider.Clear();

                if (cex.ErrorEnumValue.Equals(LoginController.LoginExceptions.NoHostSupplied))
                {
                    this.errorProvider.SetError(this.tbServer, "No host name supplied");
                }
                else if (cex.ErrorEnumValue.Equals(LoginController.LoginExceptions.NoUsernamePasswordSupplied))
                {
                    if (tbUsername.Text.IsNullOrWhiteSpace())
                    {
                        this.errorProvider.SetError(this.tbUsername, "No username specified");
                    }
                    else
                    {
                        this.errorProvider.SetError(this.tbPassword, "No password specified");
                    }
                }
            }
        }

        #endregion
    }
}
