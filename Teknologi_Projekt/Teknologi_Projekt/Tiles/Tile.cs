using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Teknologi_Projekt.Tiles
{
    public abstract class Tile : GameObject
    {
        protected Texture2D textureAtlas;
        private Rectangle destinationRectangle;
        public Vector2 pathfindingDest;
        protected Rectangle source;

        protected Tile(Texture2D textureAtlas, int x, int y)
        {
            this.textureAtlas = textureAtlas;
            this.destinationRectangle = new Rectangle(x * 256, y * 256, 256, 256);
            pathfindingDest = new Vector2((x * 256) + 128, (y * 256) + 128);

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
