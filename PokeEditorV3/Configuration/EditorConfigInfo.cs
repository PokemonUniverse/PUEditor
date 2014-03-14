using NoNameLib.Configuration;

namespace PokeEditorV3.Configuration
{
    public class EditorConfigInfo : ConfigurationItemCollection
    {
        private const string SECTION_NAME = "PokeEditor";

        public EditorConfigInfo()
        {
            Add(new ConfigurationItem(SECTION_NAME, EditorConfigConstants.TileRootDirectory, "Root path of the tiles directory.", "", typeof(string)));
        }
    }
}
