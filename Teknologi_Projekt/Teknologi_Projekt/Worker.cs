using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using SharpDX.MediaFoundation;
using SharpDX.MediaFoundation.DirectX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Teknologi_Projekt.Tiles;

namespace Teknologi_Projekt
{
    internal class Worker : GameObject
    {
        private Vector2 dir;
        private static Castle castle;
        private Tile destTile;
        public Worker(Texture2D sprite)
        {
            this.sprite = sprite;
            position = new Vector2(896, 896);
            Thread workerLogic = new(WorkerLoop);
            workerLogic.IsBackground = true;
            workerLogic.Start();
        }
        public override void LoadContent(ContentManager content)
        {
        }

        public override void Update(GameTime gameTime)
        {
            float deltaTime = (float)GameWorld.publicGameTime.ElapsedGameTime.TotalSeconds;
            position += (dir * 2) * deltaTime;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, new Rectangle(0, 0, 150, 150), color, 0, new Vector2(75, 75), 1, SpriteEffects.None, 0);
        }

        private void WorkerLoop()
        {
            foreach (Tile tile in GameWorld.tileArray)
            {
                if (tile is Castle)
                {
                    castle = (Castle)tile;
                }
            }

            while (true)
            {
                Random random = new();
                List<Tile> mines = new();
                List<Tile> mountains = new();

                foreach (Tile tile in GameWorld.tileArray)
                {
                    if (tile is Mine)
                    {
                        mines.Add(tile);
                    }
                    if (tile is Mountain)
                    {
                        mountains.Add(tile);
                    }
                }



                //destTile = GameWorld.tileArray[random.Next(0, 6), random.Next(0, 6)];
                //MoveTo(destTile);
                if (mountains.Any())
                {
                destTile = mountains[random.Next(0, mountains.Count)];
                }
                else
                {
                    destTile = castle;
                }

                MoveTo(destTile);

            }
            

        }

        private void MoveTo(Tile destTile)
        {
            while (true)
            {
                
                dir = destTile.pathfindingDest - position;
                //dir.Normalize();
                
                if (Vector2.Distance(position, destTile.pathfindingDest) <= 20)
                {
                    return;
                }
            }

        }
    }

}
