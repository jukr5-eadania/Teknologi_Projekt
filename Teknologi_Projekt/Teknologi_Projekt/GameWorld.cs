using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Teknologi_Projekt.Tiles;

namespace Teknologi_Projekt
{
    public class GameWorld : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static List<GameObject> gameObjects = new();
        public static Tile[,] tileArray = new Tile[7, 7];
        public float scale = 1f;
        public static Vector2 cursorPosition = new(2, 0);
        private float cursorCooldown;

        static public GameTime publicGameTime;


        private UIManager UIM = new();
        private ButtonManager BM;


        public static int Height { get; set; }
        public static int Width { get; set; }

        private static Texture2D textureAtlas;
        private static Texture2D playerSprite;

        private Matrix translation;


        public GameWorld()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.HardwareModeSwitch = false;
            Window.IsBorderless = false;
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferHeight = 896;
            _graphics.PreferredBackBufferWidth = 1500;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            GameWorld.Height = _graphics.PreferredBackBufferHeight;
            GameWorld.Width = _graphics.PreferredBackBufferWidth;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            textureAtlas = Content.Load<Texture2D>("Tilesheet");
            playerSprite = Content.Load<Texture2D>("PlayerPNG");
            translation = Matrix.CreateScale(scale);
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.LoadContent(Content);
            }

            for (int y = 0; y < 7; y++)
            {
                for (int x = 0; x < 7; x++)
                {
                    tileArray[x, y] = new Grasslands(textureAtlas, x, y);
                }
            }
            tileArray[3, 3] = new Castle(textureAtlas, 3, 3);
            tileArray[2, 0] = new Mountain(textureAtlas, 2, 0);
            tileArray[0, 4] = new Mountain(textureAtlas, 0, 4);
            tileArray[6, 2] = new Mountain(textureAtlas, 6, 2);
            gameObjects.Add(new Cursor(textureAtlas, 0, 0));

            UIM.LoadContent(Content);
            BM = new ButtonManager(UIM);
        }

        protected override void Update(GameTime gameTime)
        {
            publicGameTime = gameTime;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Update(gameTime);
            }
            foreach (Tile tile in tileArray)
            {
                tile.Update(gameTime);
            }

            UIM.Update(gameTime);
            base.Update(gameTime);


            HandleInput(gameTime);
        }

        private void HandleInput(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();
            cursorCooldown += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (keyState.IsKeyDown(Keys.Down))
            {
                scale -= (float)0.001;
                translation = Matrix.CreateScale(scale);
            }
            else if (keyState.IsKeyDown(Keys.Up))
            {
                scale += (float)0.001;
                translation = Matrix.CreateScale(scale);
            }

            if (keyState.IsKeyDown(Keys.Right))
            {
                if (tileArray[(int)cursorPosition.X, (int)cursorPosition.Y] is Castle)
                {
                    return;
                }
                tileArray[(int)cursorPosition.X, (int)cursorPosition.Y] = new Mine(textureAtlas, (int)cursorPosition.X, (int)cursorPosition.Y);
            }
            if (keyState.IsKeyDown(Keys.Left))
            {
                if (tileArray[(int)cursorPosition.X, (int)cursorPosition.Y] is Castle)
                {
                    return;
                }
                tileArray[(int)cursorPosition.X, (int)cursorPosition.Y] = new Grasslands(textureAtlas, (int)cursorPosition.X, (int)cursorPosition.Y);
            }

            if (cursorCooldown < 150)
            {
                return;
            }
            if (keyState.IsKeyDown(Keys.W))
            {
                cursorPosition.Y -= 1;
                cursorCooldown = 0f;
            }
            if (keyState.IsKeyDown(Keys.A))
            {
                cursorPosition.X -= 1;
                cursorCooldown = 0f;
            }
            if (keyState.IsKeyDown(Keys.S))
            {
                cursorPosition.Y += 1;
                cursorCooldown = 0f;
            }
            if (keyState.IsKeyDown(Keys.D))
            {
                cursorPosition.X += 1;
                cursorCooldown = 0f;
            }
            if (cursorPosition.Y < 0)
            {
                cursorPosition.Y = 6;
            }
            if (cursorPosition.X < 0)
            {
                cursorPosition.X = 6;
            }
            if (cursorPosition.Y > 6)
            {
                cursorPosition.Y = 0;
            }
            if (cursorPosition.X > 6)
            {
                cursorPosition.X = 0;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise, null, transformMatrix: translation);
            foreach (GameObject gameObject in gameObjects)
            {
                gameObject.Draw(_spriteBatch);
            }

            foreach (Tile tile in tileArray)
            {
                tile.Draw(_spriteBatch);
            }

            UIM.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public static void BuildHouse()
        {
            if (tileArray[(int)cursorPosition.X, (int)cursorPosition.Y] is Grasslands)
            {
                tileArray[(int)cursorPosition.X, (int)cursorPosition.Y] = new WorkerHouse(textureAtlas, (int)cursorPosition.X, (int)cursorPosition.Y);
                UIManager.workerCounter += 1;
                gameObjects.Add(new Worker(playerSprite));
                UIManager.brick -= 10;
            }
            else
            {
                return;
            }
        }

        public static void BuildStoneMill()
        {
            if (tileArray[(int)cursorPosition.X, (int)cursorPosition.Y] is Grasslands)
            {
                tileArray[(int)cursorPosition.X, (int)cursorPosition.Y] = new Stonemill(textureAtlas, (int)cursorPosition.X, (int)cursorPosition.Y);
                UIManager.brick -= 15;
            }
            else
            {
                return;
            }
        }

        public static void BuildMine()
        {
            if (tileArray[(int)cursorPosition.X, (int)cursorPosition.Y] is Mountain)
            {
                tileArray[(int)cursorPosition.X, (int)cursorPosition.Y] = new Mine(textureAtlas, (int)cursorPosition.X, (int)cursorPosition.Y);
                UIManager.brick -= 20;
            }
            else
            {
                return;
            }
        }
    }
}
