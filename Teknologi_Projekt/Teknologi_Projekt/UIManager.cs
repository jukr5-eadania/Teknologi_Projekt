using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknologi_Projekt
{
    internal class UIManager
    {
        private Texture2D buttonTexture;
        private List<Button> buttons = new();

        public void LoadContent(ContentManager content)
        {
            buttonTexture = content.Load<Texture2D>("button_rectangle_depth_flat");
        }

        public Button AddButton(Vector2 pos)
        {
            Button b = new Button(buttonTexture, pos);
            buttons.Add(b);

            return b;
        }

        public void Update(GameTime gameTime)
        {
            foreach (var item in buttons)
            {
                item.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var item in buttons)
            {
                item.Draw(spriteBatch);
            }
        }
    }
}
