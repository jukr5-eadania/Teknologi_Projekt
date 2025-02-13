using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Teknologi_Projekt.Tiles;

namespace Teknologi_Projekt
{
    internal class Worker : GameObject
    {
        private Vector2 dir;
        private static Castle castle;
        private Tile destTile;

        public int stones;
        public int bricks;

        public int target;

        List<Mine> mines = new();
        List<Mountain> mountains = new();
        List<Stonemill> stonemills = new();

        public Worker(Texture2D sprite)
        {
            this.sprite = sprite;
            position = new Vector2(448, 448);
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
            position += (dir * 1) * deltaTime;
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, new Rectangle(0, 0, 150, 150), color, 0, new Vector2(75, 75), 0.5f, SpriteEffects.None, 0);
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
                Search();


                if (bricks > 0)
                {
                    MoveTo(castle);
                    if (Vector2.Distance(position, castle.pathfindingDest) <= 20)
                    {
                        UIManager.brick += this.bricks;
                        this.bricks = 0;
                    }
                }
                else if (mines.Any() && (stones <= 0))
                {
                    bool looking = true;
                    while (looking)
                    {
                        Thread.Sleep(random.Next(0, 10));
                        Search();
                        target = random.Next(0, mines.Count);
                        destTile = mines[target];
                        MoveTo(destTile);
                        if (mines[target].stones > 0 && !mines[target].taken && Vector2.Distance(position, destTile.pathfindingDest) <= 20)
                        {
                            mines[target].taken = true;
                            mines[target].EnterMine(this);
                            looking = false;
                        }
                    }
                    
                }
                else if (stonemills.Any() && (stones > 0))
                {
                    bool looking = true;
                    while (looking)
                    {
                        Search();
                        target = random.Next(0, stonemills.Count);
                        destTile = stonemills[target];
                        MoveTo(destTile);
                        if (!stonemills[target].taken && Vector2.Distance(position, destTile.pathfindingDest) <= 20)
                        {
                            stonemills[target].taken = true;
                            stonemills[target].MakeBricks(this);
                            looking = false;
                        }
                    }
                }
                else
                {
                    destTile = GameWorld.tileArray[random.Next(0, 6), random.Next(0, 6)];
                    MoveTo(destTile);
                }
            }
        }

        private void Search()
        {
            mines = new();
            mountains = new();
            stonemills = new();

            foreach (Tile tile in GameWorld.tileArray)
            {
                if (tile is Mine)
                {
                    mines.Add((Mine)tile);
                }
                if (tile is Mountain)
                {
                    mountains.Add((Mountain)tile);
                }
                if (tile is Stonemill)
                {
                    stonemills.Add((Stonemill)tile);
                }
            }
        }
        private void MoveTo(Tile destTile)
        {
            while (true)
            {
                
                dir = destTile.pathfindingDest - position;
                
                if (Vector2.Distance(position, destTile.pathfindingDest) <= 20)
                {
                    dir = Vector2.Zero;
                    return;
                }
            }

        }
    }

}
