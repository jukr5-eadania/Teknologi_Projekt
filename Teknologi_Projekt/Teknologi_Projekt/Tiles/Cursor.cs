using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Teknologi_Projekt.Tiles
{
    internal class Cursor : Tile
    {
        public Cursor(Texture2D textureAtlas, int x, int y) : base(textureAtlas, x, y)
        {
            source = new(0 * tileSize, 2 * tileSize, tileSize, tileSize);
        }

        public override void LoadContent(ContentManager content)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textureAtlas, new Rectangle((int)GameWorld.cursorPosition.X * tileSize, (int)GameWorld.cursorPosition.Y * tileSize, tileSize, tileSize)  , source, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
        }
    }
}
