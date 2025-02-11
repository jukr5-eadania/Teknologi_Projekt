using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Teknologi_Projekt
{
    internal class UIManager
    {
        private Texture2D buttonTexture;
        private static List<Button> buttons = new();
        private SpriteFont UIFont;
        private float timer;
        public static int stone;


        public void LoadContent(ContentManager content)
        {
            buttonTexture = content.Load<Texture2D>("button_rectangle_depth_flat");
            UIFont = content.Load<SpriteFont>("UIFont");
        }

        public Button AddButton(Vector2 position)
        {
            Button b = new Button(buttonTexture, position);
            buttons.Add(b);

            return b;
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

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

            spriteBatch.DrawString(UIFont, "Time: " + FormatTime(timer), new Vector2(0, 0), Color.White);
            spriteBatch.DrawString(UIFont, "Stone: " + stone, new Vector2(0, 30), Color.White);
        }

        private string FormatTime(float totalSeconds)
        {
            int minutes = (int)totalSeconds / 60;
            int seconds = (int)totalSeconds % 60;
            int milliseconds = (int)((totalSeconds - (int)totalSeconds) * 1000);
            return $"{minutes:D2}:{seconds:D2}:{milliseconds:D3}"; // MM:SS:MS
        }
    }
}
