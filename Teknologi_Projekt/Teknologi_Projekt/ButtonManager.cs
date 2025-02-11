using System;

namespace Teknologi_Projekt
{
    internal class ButtonManager
    {
        private UIManager UIM;

        public ButtonManager(UIManager uim)
        {
            UIM = uim;
            UIM.AddButton(new(100, 100)).OnClick += HireWorkerAction;

        }

        public void HireWorkerAction(object sender, EventArgs e)
        {
            
        }
    }
}
