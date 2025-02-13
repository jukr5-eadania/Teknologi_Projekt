using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Teknologi_Projekt
{
    public abstract class GameObject
    {
        protected Texture2D sprite;
        protected Vector2 position;
        protected Color color = Color.White;
        protected Rectangle rect;

        public abstract void LoadContent(ContentManager content);
        public abstract void Update(GameTime gameTime);
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(sprite, position, color);
        }

    }
}
