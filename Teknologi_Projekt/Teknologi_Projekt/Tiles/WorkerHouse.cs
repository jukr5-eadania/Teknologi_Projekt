﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknologi_Projekt.Tiles
{
   
    /// <summary>
    /// The WorkerHouse class adds more workers
    /// for the player to assigne jobs in the game
    /// </summary>
    internal class WorkerHouse : Tile
    {
        private int workerCounter = 0;

        public WorkerHouse(Texture2D textureAtlas, int x, int y) : base(textureAtlas, x, y)
        {

        }

        public override void LoadContent(ContentManager content)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void AddWorkers()
        {
            workerCounter += 2;
        }

    }
}
