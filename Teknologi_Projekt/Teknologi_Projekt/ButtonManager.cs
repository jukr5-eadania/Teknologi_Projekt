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
            UIM.AddButton(new(100, 300)).OnClick += BuildHouse;
            UIM.AddButton(new(100, 400)).OnClick += AssignTask;
        }

        public void Action(object sender, EventArgs e)
        {
            UIM.counter++;
        }

        public void Action1(object sender, EventArgs e)
        {
            UIM.counter--;
        }

        /// <summary>
        /// A button that builds a worker house if there are enough resources
        /// Adds to the workerCounter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void BuildHouse(object sender, EventArgs e)
        {
            if (UIManager.stone >= 10)
            {
                UIM.workerCounter += 2;
                UIManager.stone -= 10;
            }
        }

        /// <summary>
        /// A button that assigns a non-working worker to a job
        /// Removes a wworker from the workerCounter
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AssignTask(object sender, EventArgs e) //Assign worker
        {
            if (UIM.workerCounter >= 1)
            {
                UIM.workerCounter--;
            }
        }

    }
}
