using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Teknologi_Projekt.Tiles
{
    /// <summary>
    /// The Mine class keeps track of its capacity and how many workers
    /// is using it. 
    /// </summary>
    internal class Mine : Tile
    {
        private int mineCapacity;

        private Semaphore workerCapacity = new Semaphore(0, 4);

        private List<Thread> miningThreads = new List<Thread>();
        private List<CancellationTokenSource> cancellationTokens = new List<CancellationTokenSource>();

        public Mine(Texture2D textureAtlas, int x, int y) : base(textureAtlas, x, y)
        {
            source = new(2 * tileSize, 0 * tileSize, tileSize, tileSize);
        }

        public override void LoadContent(ContentManager content)
        {

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
            mineCapacity++;
            var cts = new CancellationTokenSource();
            var miningThread = new Thread(() => MiningStone(cts.Token));
            miningThread.IsBackground = true;
            miningThread.Start();
            miningThreads.Add(miningThread);
            cancellationTokens.Add(cts);
            workerCapacity.Release();
        }

        public void LeaveMine()
        {
            var cts = cancellationTokens[0];
            cts.Cancel();

            miningThreads.RemoveAt(0);
            cancellationTokens.RemoveAt(0);
        }

        /// <summary>
        /// When having entered, the
        /// workers in the mine will collect stone
        /// </summary>
        public void MiningStone(CancellationToken token)
        {
            while (!token.IsCancellationRequested && mineCapacity > 0)
            {
                workerCapacity.WaitOne();
                UIManager.stone++;
                Thread.Sleep(1000);
                workerCapacity.Release();
            }

        }
    }
}
