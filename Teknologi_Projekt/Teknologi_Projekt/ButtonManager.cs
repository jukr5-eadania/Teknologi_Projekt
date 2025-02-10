using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknologi_Projekt
{
    internal class ButtonManager
    {
        private UIManager UIM = new();

        public ButtonManager()
        {
            UIM.AddButton(new(100, 100)).OnClick += Action;
        }

        public void Action(object sender, EventArgs e)
        {

        }
    }
}
