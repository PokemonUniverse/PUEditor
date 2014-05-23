using System;
using NoNameLib.Extension;

namespace PokeEditorV3.Logic.Models
{
    public class TilesetModel
    {
        private string name;

        public TilesetModel()
        {
            TileHeight = 32;
            TileWidth = 32;
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value.IsNullOrWhiteSpace())
                    throw new Exception("Tileset name can not be empty");
                name = value;
            }
        }

        public string Path { get; set; }

        public int TileHeight { get; set; }
        public int TileWidth { get; set; }
    }
}
