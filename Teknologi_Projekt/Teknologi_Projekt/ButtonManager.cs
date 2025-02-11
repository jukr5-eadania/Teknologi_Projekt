using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknologi_Projekt
{
    internal class ButtonManager
    {
        private UIManager UIM;

        public ButtonManager(UIManager uim)
        {
            UIM = uim;
            UIM.AddButton(new(100, 100)).OnClick += Action;
            UIM.AddButton(new(100, 200)).OnClick += Action1;
        }

        public void Action(object sender, EventArgs e)
        {
            UIM.counter++;
        }

        public void Action1(object sender, EventArgs e)
        {
            UIM.counter--;
        }
    }
}
