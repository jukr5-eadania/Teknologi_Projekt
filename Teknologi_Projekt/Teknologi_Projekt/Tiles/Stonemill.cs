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
        private static bool buildingActive;
        private bool hireWorker;
        private static int stone;
        Thread mining = new Thread(Mining);


        public override void LoadContent(ContentManager content)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            mining.IsBackground = true;
            hireWorker = true;
        }

        public void HireWorker()
        {
            if (hireWorker)
            {
                if (worker >= 1)
                {
                    worker--;
                    buildingActive = true;
                    mining.Start();
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
                stone++;
                Thread.Sleep(1000);
            }
        }
    }
}
