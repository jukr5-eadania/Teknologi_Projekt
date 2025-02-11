using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Teknologi_Projekt
{
    internal class Button
    {
        private Texture2D sprite;
        private Vector2 position;
        private Color color;
        private Rectangle rect;
        private MouseState lastMouseState;

        public Button(Texture2D s, Vector2 p)
        {
            sprite = s;
            position = p;

            rect = new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
        }

        public void Update(GameTime gameTime)
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

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, color);
        }
    }
}
