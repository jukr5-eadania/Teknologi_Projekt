using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Threading;

namespace Teknologi_Projekt.Tiles
{
    /// <summary>
    /// The Mine class keeps track of its capacity and how many workers
    /// is using it. 
    /// </summary>
    internal class Mine : Tile
    {
        private float cooldown;
        public int stones;
        public bool taken;

        static readonly object lockObject = new();
        private Semaphore workerCapacity = new Semaphore(0, 4);

        private List<Thread> miningThreads = new List<Thread>();
        private List<CancellationTokenSource> cancellationTokens = new List<CancellationTokenSource>();

        public Mine(Texture2D textureAtlas, int x, int y) : base(textureAtlas, x, y)
        {

            source = new(2 * tileSize, 0 * tileSize, tileSize, tileSize);

        }

        public override void LoadContent(ContentManager content)
        {

        }

        public override void Update(GameTime gameTime)
        {
            cooldown += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (cooldown > 5000)
            {
                stones++;
                cooldown = 0;
            }

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textureAtlas, destinationRectangle, source, Color.White, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.DrawString(UIManager.UIFont, "" + stones, new Vector2(destinationRectangle.X + 15, destinationRectangle.Y + 15), Color.White);
        }

        /// <summary>
        /// Checks to see if there are space for 
        /// more workers in the mine.
        /// </summary>
        public void EnterMine(Worker worker)
        {
            lock (lockObject)
            {
                Thread.Sleep(5000);
                worker.stones = this.stones;
                stones = 0;
            }
            taken = false;
        }

    }
}
