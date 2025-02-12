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
        private int capacity = 4;
        private Mine mine;

        public override void LoadContent(ContentManager content)
        {

        }

        public override void Update(GameTime gameTime)
        {

        }

        public Stonemill(Texture2D textureAtlas, int x, int y, Mine M) : base(textureAtlas, x, y)
        {
            mine = M;
            source = new(1 * tileSize, 1 * tileSize, tileSize, tileSize);
        }

        public void HireWorker()
        {
            if (UIManager.workerCounter >= 1 && capacity > 0)
            {
                capacity--;
                mine.EnterMine();
                UIManager.workerCounter--;
            }
        }

        public void FireWorker()
        {
            if (capacity < 4)
            {
                mine.LeaveMine();
                capacity++;
                UIManager.workerCounter++;
            }
        }
    }
}
