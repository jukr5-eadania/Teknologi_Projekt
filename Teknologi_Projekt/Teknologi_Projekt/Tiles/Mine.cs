using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Teknologi_Projekt.Tiles
{
    internal class Mine : Tile
    {
        public Mine(Texture2D textureAtlas, int x, int y) : base(textureAtlas, x, y)
        {
            source = new(2 * 256, 0 * 256, 256, 256);
        }

        public override void LoadContent(ContentManager content)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
