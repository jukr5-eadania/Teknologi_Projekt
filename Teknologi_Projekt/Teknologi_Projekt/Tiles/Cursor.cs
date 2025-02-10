﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Teknologi_Projekt.Tiles
{
    internal class Cursor : Tile
    {
        public Cursor(Texture2D textureAtlas, int x, int y) : base(textureAtlas, x, y)
        {
            source = new(0 * 256, 2 * 256, 256, 256);
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
            spriteBatch.Draw(textureAtlas, new Rectangle((int)GameWorld.cursorPosition.X * 256, (int)GameWorld.cursorPosition.Y * 256, 256, 256)  , source, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
        }
    }
}
