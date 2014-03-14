using System.Text;
using NoNameLib.Configuration;
using NoNameLib.Extension;
using PokeEditorV3.Configuration;
using PokeEditorV3.Logic.Dialogs;
using PokeEditorV3.Logic.Events.StartupEvents;
using PokeEditorV3.Logic.Events.ViewEvents;
using PokeEditorV3.Windows;
using WeifenLuo.WinFormsUI.Docking;

namespace PokeEditorV3.Logic.Managers
{
    public class StartupManager : Manager
    {
        public StartupManager() : base("StartupManager")
        {
        }

        public void InitStartup()
        {
            new EventValidateConfiguration().Post();
        }

        public void ValidateConfiguration()
        {
            var tileRootDir = ConfigurationManager.GetString(EditorConfigConstants.TileRootDirectory);

            var configErrors = new StringBuilder();
            if (tileRootDir.IsNullOrWhiteSpace())
            {
                configErrors.AppendLine(" - Tile Root Directory is not set");
            }

            if (configErrors.Length > 0)
            {
                var openSettingsEvent = new EventShowWindow();
                openSettingsEvent.DockState = DockState.Document;
                openSettingsEvent.WindowName = typeof (FrmSettings);

                var okButtonContainer = new OkButtonContainer();
                okButtonContainer.ButtonText = "Open Settings";
                okButtonContainer.ButtonEvent = openSettingsEvent;

                EventShowDialog.ShowOkDialog("Configuration Error", string.Format("The configuration file is missing paramters:\n{0}", configErrors), okButtonContainer);
            }
        }
    }
}
