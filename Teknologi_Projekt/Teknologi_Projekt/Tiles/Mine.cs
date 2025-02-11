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
        static Semaphore capacity = new Semaphore(0, 4); 
        public Mine(Texture2D textureAtlas, int x, int y) : base(textureAtlas, x, y)
        {
        }

        public override void LoadContent(ContentManager content)
        {
          
        }

        public override void Update(GameTime gameTime)
        {
            EnterMine();
        }

        /// <summary>
        /// Checks to see if there are space for 
        /// more workers in the mine.
        /// </summary>
        static void EnterMine()
        {
            for (int i = 0; i <= 6; i++)
            {
                new Thread(MiningStone).Start(i);
            }            
            capacity.Release(4);
        }

        /// <summary>
        /// When having entered, the
        /// workers in the mine will collect stone
        /// </summary>
        static void MiningStone(object worker)
        {
            capacity.WaitOne();
            UIManager.stone++;
            Thread.Sleep(1000*(int)worker);
            capacity.Release();
        }
    }
}
