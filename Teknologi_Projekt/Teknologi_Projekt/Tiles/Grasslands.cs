﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Teknologi_Projekt.Tiles
{
    internal class Grasslands : Tile
    {
        public Grasslands(Texture2D textureAtlas, int x, int y) : base(textureAtlas, x, y)
        {
            source = new(0 * tileSize, 0 * tileSize, tileSize, tileSize);
        }

        public override void LoadContent(ContentManager content)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}
