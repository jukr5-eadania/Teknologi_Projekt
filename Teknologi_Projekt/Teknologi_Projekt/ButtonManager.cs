using System;
using Teknologi_Projekt.Tiles;

namespace Teknologi_Projekt
{
    internal class ButtonManager
    {
        private UIManager UIM;

        public ButtonManager(UIManager uim)
        {
            UIM = uim;
            UIM.AddButton(new(1000, 100), "House").OnClick += BuildHouse;
            UIM.AddButton(new(1000, 200), "StoneMill").OnClick += BuildStoneMill;
            UIM.AddButton(new(1000, 300), "Mine").OnClick += BuildMine;
        }
        public void BuildHouse(object sender, EventArgs e)
        {
            if (UIManager.brick >= 10)
            {
                GameWorld.BuildHouse();
            }
        }

        public void BuildStoneMill(object sender, EventArgs e)
        {
            if (UIManager.brick >= 15)
            {
                GameWorld.BuildStoneMill();
            }
        }

        public void BuildMine(object sender, EventArgs e)
        {
            if (UIManager.brick >= 20)
            {
                GameWorld.BuildMine();
            }
        }
    }
}
