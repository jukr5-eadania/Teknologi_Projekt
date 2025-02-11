using System;

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
        }

        public void HireWorkerAction(object sender, EventArgs e)
        {
            SM.HireWorker();
        }

        public void FireWorkerAction(object sender, EventArgs e)
        {
            SM.FireWorker();
        }
    }
}
