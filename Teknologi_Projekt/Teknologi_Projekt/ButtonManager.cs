using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teknologi_Projekt.Tiles;

namespace Teknologi_Projekt
{
    internal class ButtonManager
    {
        private UIManager UIM;
        private WorkerHouse WH;

        public ButtonManager(UIManager uim)
        {
            UIM = uim;
            UIM.AddButton(new(100, 100)).OnClick += Action;
            UIM.AddButton(new(100, 200)).OnClick += Action1;
            UIM.AddButton(new(100, 300)).OnClick += Action2;
            UIM.AddButton(new(100, 400)).OnClick += Action3;
        }

        public void Action(object sender, EventArgs e)
        {
            UIM.counter++;
        }

        public void Action1(object sender, EventArgs e)
        {
            UIM.counter--;
        }

        public void Action2(object sender, EventArgs e) //Build house
        {
            if (UIManager.stone >= 10)
            {
                UIM.workerCounter += 2;
                UIManager.stone -= 10;
            }
        }
        public void Action3(object sender, EventArgs e) //Assign worker
        {
            if (UIM.workerCounter >= 1)
            {
                UIM.workerCounter--;
            }
        }

    }
}
