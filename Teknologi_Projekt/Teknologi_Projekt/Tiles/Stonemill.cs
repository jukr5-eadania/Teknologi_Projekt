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
        private int worker = 3;
        private int capacity = 3;
        private Semaphore sCapacity = new Semaphore(0, 3);
        private List<Thread> miningThreads = new List<Thread>();
        private List<CancellationTokenSource> cancellationTokens = new List<CancellationTokenSource>();

        public override void LoadContent(ContentManager content)
        {

        }

        public override void Update(GameTime gameTime)
        {

        }
        public Stonemill(Texture2D textureAtlas, int x, int y) : base(textureAtlas, x, y)
        {

        }

        public void HireWorker()
        {
            if (worker >= 1 && capacity <= 3)
            {
                capacity--;
                sCapacity.Release();
                var cts = new CancellationTokenSource();
                var miningThread = new Thread(() => Mining(cts.Token));
                miningThread.IsBackground = true;
                miningThread.Start();
                miningThreads.Add(miningThread);
                cancellationTokens.Add(cts);
                worker--;
            }
        }

        public void FireWorker()
        {
            var cts = cancellationTokens[0];
            cts.Cancel();

            miningThreads.RemoveAt(0);
            cancellationTokens.RemoveAt(0);

            capacity++;
            worker++;
        }

        private void Mining(CancellationToken token)
        {
            while (!token.IsCancellationRequested && capacity >= 0)
            {
                sCapacity.WaitOne();
                Thread.Sleep(1000);
                UIManager.stone++;
                Thread.Sleep(1000);
                sCapacity.Release();
            }
        }
    }
}
