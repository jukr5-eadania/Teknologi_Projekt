using Microsoft.Xna.Framework;
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
        private string text;
        private Vector2 origin;

        public Button(Texture2D s, Vector2 p, string t)
        {
            sprite = s;
            position = p;
            text = t;

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
            spriteBatch.Draw(sprite, position, new(0,0, sprite.Width, sprite.Height), color, 0, Vector2.Zero, Vector2.One, SpriteEffects.None, 1);
            origin = UIManager.UIFont.MeasureString(text);
            spriteBatch.DrawString(UIManager.UIFont, text, new(position.X + sprite.Width / 2, position.Y + sprite.Height / 2), color, 0, origin / 2, 2, SpriteEffects.None, 0);
        }
    }
}
