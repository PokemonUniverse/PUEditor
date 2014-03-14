using System.Drawing;
using System.IO;
using NoNameLib.TileEditor.Collections;
using NoNameLib.TileEditor.Graphics;
using PokeEditorV3.Logic.Managers;
using PokeEditorV3.Properties;

namespace PokeEditorV3.Logic.Windows
{
    public class TileInfoController
    {
        public delegate void MouseTileHoverEventHandler(object sender, TilePoint tp);

        public event MouseTileHoverEventHandler OnMouseTileHover;

        #region Ctor

        public TileInfoController()
        {
            HookupEvents();
        }
        
        #endregion

        #region Event Handlers

        private void HookupEvents()
        {
            var tm = GlobalManager.GetManager<TileManager>();
            tm.OnMouseTileHover += TileManagerOnMouseTileHover;
        }

        void TileManagerOnMouseTileHover(object sender, TilePoint tp)
        {
            if (OnMouseTileHover != null)
            {
                OnMouseTileHover(sender, tp);
            }
        }

        #endregion

        public Bitmap GetBitmapForTileId(string tileId)
        {
            Bitmap bitmap;
            Texture texture;
            if (TextureManager.Instance.TryGetTexture(tileId, out texture))
            {
                bitmap = (Bitmap)Image.FromFile(Path.Combine(texture.Directory, texture.Filename));
            }
            else
            {
                bitmap = Resources.sys_base;
            }

            return bitmap;
        }
    }
}
