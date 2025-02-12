using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teknologi_Projekt.Tiles
{
   
    internal class WorkerHouse : Tile
    {        
        public WorkerHouse(Texture2D textureAtlas, int x, int y) : base(textureAtlas, x, y)
        {
            source = new(2 * tileSize, 1 * tileSize, tileSize, tileSize);
        }

        public override void LoadContent(ContentManager content)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            
        }

    }
}
