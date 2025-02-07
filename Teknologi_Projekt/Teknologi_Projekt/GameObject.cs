using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Teknologi_Projekt
{
    public abstract class GameObject
    {
        public abstract void LoadContent(ContentManager content);
        public abstract void Update(GameTime gameTime);
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(null, Vector2.Zero, Color.White);
        }

    }
}
