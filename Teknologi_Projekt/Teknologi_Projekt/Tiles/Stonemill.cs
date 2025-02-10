using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
