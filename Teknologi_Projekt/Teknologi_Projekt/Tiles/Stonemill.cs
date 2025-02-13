using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Teknologi_Projekt.Tiles
{
    internal class Stonemill : Tile
    {
        static readonly object lockObject = new();


        public bool taken = false;

        public override void LoadContent(ContentManager content)
        {

        }

        public override void Update(GameTime gameTime)
        {

        }

        public Stonemill(Texture2D textureAtlas, int x, int y) : base(textureAtlas, x, y)
        {
            source = new(1 * tileSize, 1 * tileSize, tileSize, tileSize);
        }

        public void MakeBricks(Worker worker)
        {
            
                Thread.Sleep(5000);
                worker.bricks = worker.stones;
                worker.stones = 0;
          
            taken = false;
        }
        
    }
}
