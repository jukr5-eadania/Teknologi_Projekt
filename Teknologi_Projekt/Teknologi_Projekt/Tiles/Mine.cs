using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Threading;

namespace Teknologi_Projekt.Tiles
{
    /// <summary>
    /// The Mine class keeps track of its capacity and how many workers
    /// is using it. 
    /// </summary>
    internal class Mine : Tile
    {
        private Semaphore capacity = new Semaphore(0, 4);
        private int x;
        public Mine(Texture2D textureAtlas, int x, int y) : base(textureAtlas, x, y)
        {
        }

        public override void LoadContent(ContentManager content)
        {
            EnterMine();
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        /// <summary>
        /// Checks to see if there are space for 
        /// more workers in the mine.
        /// </summary>
        public void EnterMine()
        {
            for (int i = 0; i <= 5; i++)
            {
                x++;
                Thread miningStone = new Thread(MiningStone);
                miningStone.IsBackground = true;
                miningStone.Start();
            }
            capacity.Release(4);

        }

        /// <summary>
        /// When having entered, the
        /// workers in the mine will collect stone
        /// </summary>
        public void MiningStone()
        {
            while (x >= 4)
            {
            capacity.WaitOne();            
                UIManager.stone++;
                Thread.Sleep(1000);            
            capacity.Release();
            }
            
        }
    }
}
