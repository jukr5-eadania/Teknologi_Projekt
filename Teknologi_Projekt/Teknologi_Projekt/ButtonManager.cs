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

        public ButtonManager(UIManager uim)
        {
            UIM = uim;
           
            UIM.AddButton(new(1000, 100)).OnClick += HireWorkerAction;
            UIM.AddButton(new(1000, 300)).OnClick += FireWorkerAction;            
            UIM.AddButton(new(1000, 500)).OnClick += BuildHouse;
            UIM.AddButton(new(1000, 700)).OnClick += AssignTask;
        }

        public void HireWorkerAction(object sender, EventArgs e)
        {
        }

        public void FireWorkerAction(object sender, EventArgs e)
        {
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
            if (UIManager.brick >= 10)
            {
                UIManager.workerCounter += 2;
                UIManager.brick -= 10;
            }
        }

        /// <summary>
        /// A button that assigns a non-working worker to a job
        /// Removes a wworker from the workerCounter
        /// (Note: testing)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AssignTask(object sender, EventArgs e)
        {
            if (UIManager.workerCounter >= 1)
            {
                UIManager.workerCounter--;
            }
        }

    }
}
