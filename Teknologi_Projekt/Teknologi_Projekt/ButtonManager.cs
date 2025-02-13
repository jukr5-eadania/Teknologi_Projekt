using System;
using Teknologi_Projekt.Tiles;

namespace Teknologi_Projekt
{
    internal class ButtonManager
    {
        private UIManager UIM;
        private Tiles.Stonemill SM;

        public ButtonManager(UIManager uim, Tiles.Stonemill sm)
        {
            UIM = uim;
            SM = sm;

            UIM.AddButton(new(1000, 100)).OnClick += HireWorkerAction;
            UIM.AddButton(new(1000, 300)).OnClick += FireWorkerAction;
            UIM.AddButton(new(1000, 500)).OnClick += BuildHouse;
        }

        public void HireWorkerAction(object sender, EventArgs e)
        {
            SM.HireWorker();
        }

        public void FireWorkerAction(object sender, EventArgs e)
        {
            SM.FireWorker();
        }

        /// <summary>
        /// A button that builds a worker house if there are enough resources
        /// Adds to the workerCounter
        /// (Note: testing)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BuildHouse(object sender, EventArgs e)
        {
            if (UIManager.stone >= 10)
            {
                GameWorld.BuildHouse();
                UIManager.workerCounter += 2;
                UIManager.stone -= 10;
            }

        }
    }
}
