using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System.Threading;

namespace Teknologi_Projekt.Tiles
{
    internal class Stonemill : GameObject
    {
        private int worker = 3;
        private static bool buildingActive = true;
        private bool hireWorker;


        public override void LoadContent(ContentManager content)
        {
        }

        public override void Update(GameTime gameTime)
        {
            hireWorker = true;
            HireWorker();
        }

        public void HireWorker()
        {
            //if statement is in place of a button to hire/fire workers. (If is hiring, else is firing)
            if (hireWorker)
            {
                if (worker >= 1)
                {
                    Thread mining = new Thread(Mining);
                    mining.IsBackground = true;
                    buildingActive = true;
                    mining.Start();
                    worker--;
                }
            }
            else
            {
                worker++;
                buildingActive = false;
            }
        }

        private static void Mining()
        {
            while (buildingActive)
            {
                Thread.Sleep(1000);
                GameWorld.stone++;
                Thread.Sleep(1000);
            }
        }
    }
}
