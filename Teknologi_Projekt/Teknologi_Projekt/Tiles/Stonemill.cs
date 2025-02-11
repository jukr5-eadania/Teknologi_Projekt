using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Threading;

namespace Teknologi_Projekt.Tiles
{
    internal class Stonemill : GameObject
    {
        private int worker = 3;
        private int capacity = 3;
        private Semaphore sCapacity = new Semaphore(0, 3);
        public Thread mining;

        public override void LoadContent(ContentManager content)
        {

        }

        public override void Update(GameTime gameTime)
        {

        }

        public void HireWorker()
        {
            if (worker >= 1 && capacity <= 3)
            {
                capacity--;
                sCapacity.Release();
                mining = new(Mining);
                mining.IsBackground = true;
                mining.Start();
                worker--;
            }
        }

        public void FireWorker()
        {
            capacity++;
            worker++;
        }

        private void Mining()
        {
            while (capacity >= 0)
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
