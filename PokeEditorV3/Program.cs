using System;
using System.IO;
using System.Reflection;
using System.Security;
using System.Threading;
using System.Windows.Forms;
using NoNameLib;
using NoNameLib.Configuration;
using NoNameLib.Debug;
using NoNameLib.Verification;
using PokeEditorV3.Configuration;
using PokeEditorV3.Logic.Managers;
using PokeEditorV3.Properties;
using PokeEditorV3.Views;

namespace PokeEditorV3
{
    static class Program
    {
        public static SynchronizationContext Context { get; set; }

        private static string RootDirectory { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            // Setup uncaught exception catching, only if we're not running from Visual Studio thou...
            if (!AppDomain.CurrentDomain.FriendlyName.EndsWith("vshost.exe"))
            {
                Application.ThreadException += ApplicationOnThreadException;
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException;
            }

            RootDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (RootDirectory == null)
                throw new Exception("Unable to find Assembly root path. The fuck happened here?");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Global.ApplicationInfo = new ApplicationInfo();
            Global.ApplicationInfo.ApplicationName = "PokeEditorV3";
            Global.ApplicationInfo.ApplicationVersion = "0.1";
            Global.ApplicationInfo.BasePath = Application.StartupPath;

            // Set the configuration provider
            var provider = new XmlConfigurationProvider();
            provider.ManualConfigFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "PokeEditor.config");
            Global.ConfigurationProvider = provider;
            Global.ConfigurationInfo.Add(new EditorConfigInfo());

            // Initialize validators
            var verifiers = new VerifierCollection();
            verifiers.Add(new WritePermissionVerifier(Path.Combine(RootDirectory, "Exceptions")));
            verifiers.Add(new WritePermissionVerifier(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)));
            if (!verifiers.Verify())
            {
                throw new VerificationException(verifiers.ErrorMessage);
            }

            // Load all managers
            GlobalManager.Initialize();

            var mainForm = new FrmMain();
            Context = SynchronizationContext.Current;

            Application.Run(mainForm);

            // Show Login form
            /*using (var loginForm = new FrmLogin())
            {
                DialogResult result = loginForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Application.Run(mainForm);
                }
            }*/
        }

        private static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs unhandledExceptionEventArgs)
        {
            WriteExceptionToFile((Exception)unhandledExceptionEventArgs.ExceptionObject);

            MessageBox.Show(unhandledExceptionEventArgs.ExceptionObject.ToString(), Resources.Program_Unhandled_Exception, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void ApplicationOnThreadException(object sender, ThreadExceptionEventArgs threadExceptionEventArgs)
        {
            WriteExceptionToFile(threadExceptionEventArgs.Exception);

            MessageBox.Show(threadExceptionEventArgs.Exception.ToString(), Resources.Program_Unhandled_Exception, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void WriteExceptionToFile(Exception ex)
        {
            var filename = string.Format("Exception-{0}.txt", DateTime.UtcNow.Ticks);
            var file = new StreamWriter(Path.Combine(RootDirectory, "Exceptions", filename), true);
            file.WriteLine(ex.ToString());

            file.Close();
        }
    }
}
