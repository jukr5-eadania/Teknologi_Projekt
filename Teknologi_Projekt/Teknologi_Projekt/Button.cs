using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknologi_Projekt
{
    internal class Button : GameObject
    {
        private MouseState lastMouseState;

        public Button(Texture2D t, Vector2 p)
        {

        }

        public override void LoadContent(ContentManager content)
        {
            position = new Vector2(0, 0);
            sprite = content.Load<Texture2D>("button_rectangle_depth_flat");
            rect = new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
        }

        public override void Update(GameTime gameTime)
        {
            MouseState ms = Mouse.GetState();
            Rectangle cursor = new(ms.Position.X, ms.Position.Y, 1, 1);

            if (cursor.Intersects(rect))
            {
                color = Color.DarkGray;
                if (ms.LeftButton == ButtonState.Pressed && lastMouseState.LeftButton == ButtonState.Released)
                {
                    Click();
                }
            }
            else
            {
                color = Color.White;
            }

            lastMouseState = ms;
        }

        public event EventHandler OnClick;

        private void Click()
        {
            OnClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
