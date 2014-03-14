using System;
using System.Reflection;
using System.Text;
using PokeEditorV3.Logic.Dialogs;

namespace PokeEditorV3.Dialogs
{
    partial class FrmAbout : DialogBase
    {
        private readonly string[] developers = {"Mr_Dark", "Zatir" };
        private readonly string[] extraCredits = {"Icons: famfamfam"};

        public FrmAbout()
        {
            InitializeComponent();

            this.labelProductName.Text = NoNameLib.Global.ApplicationInfo.ApplicationName;
            this.labelVersion.Text = String.Format("Version: {0}", NoNameLib.Global.ApplicationInfo.ApplicationVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.textBoxDescription.Text = AboutDescription;
        }

        private string AboutDescription
        {
            get
            {
                var builder = new StringBuilder();
                builder.AppendFormat("Developers: {0}\r\n", string.Join(", ", developers));
                builder.AppendLine("Other:");
                foreach (var extraCredit in extraCredits)
                {
                    builder.AppendLine(extraCredit);
                }
                
                return builder.ToString();
            }
        }

        #region Assembly Attribute Accessors

        private string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        #endregion
    }
}
