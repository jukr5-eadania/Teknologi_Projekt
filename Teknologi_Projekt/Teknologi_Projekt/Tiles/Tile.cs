using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Teknologi_Projekt.Tiles
{
    public abstract class Tile : GameObject
    {
        protected Texture2D textureAtlas;
        protected Rectangle destinationRectangle;
        public Vector2 pathfindingDest;
        protected Rectangle source;
        protected int tileSize = 128;

        protected Tile(Texture2D textureAtlas, int x, int y)
        {
            this.textureAtlas = textureAtlas;

            this.destinationRectangle = new Rectangle(x * tileSize, y * tileSize, tileSize, tileSize);
            pathfindingDest = new Vector2((x * tileSize) + (tileSize / 2), (y * tileSize) + (tileSize / 2));
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
            spriteBatch.Draw(textureAtlas, destinationRectangle, source, Color.White, 0, Vector2.Zero, SpriteEffects.None, 1);
        }
    }
}
