using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace AspectStar
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private SpriteFont gameFont;

        public static Textures texCollection;

        Screen currentMode;

        public enum Aspects
        {
            Blue = 0,
            Green = 1,
            Red = 2,
            None = 255
        }
        
        public enum Directions
        {
            Up = 1,
            Down = 0,
            Left = 2,
            Right = 3
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            TargetElapsedTime = System.TimeSpan.FromTicks(333333 / 2);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            // Load sound effects
            PlaySound.thud = Content.Load<SoundEffect>("thud"); // Hitting walls, failed bullet; from pdsounds.org, which claims to be public domain
            PlaySound.pew = Content.Load<SoundEffect>("pew"); // Shooting sound effect; Made it myself in sfxr
            PlaySound.aspect = Content.Load<SoundEffect>("aspect"); // Changing color aspect; Made it myself in sfxr
            PlaySound.boom = Content.Load<SoundEffect>("boom"); // Enemy defeated; Made it myself in sfxr
            PlaySound.die = Content.Load<SoundEffect>("die"); // Death chime; Made it myself in sfxr
            PlaySound.win = Content.Load<SoundEffect>("win"); // Level victory chime; Made it myself in sfxr
            PlaySound.pause = Content.Load<SoundEffect>("pause"); // Pause chime; Made it myself in sfxr
            PlaySound.Initialize();

            // Load relevant content
            texCollection.texNadine = Content.Load<Texture2D>("nadine_3col");
            texCollection.texBullet = Content.Load<Texture2D>("bullets");
            texCollection.testMap = Content.Load<Texture2D>("test_map");
            texCollection.factoryMap = Content.Load<Texture2D>("factory_map");
            texCollection.texMouse = Content.Load<Texture2D>("bigmouse");
            texCollection.texBaddog = Content.Load<Texture2D>("baddog");
            texCollection.texBirdie = Content.Load<Texture2D>("birdie_3col");

            EnemyDict.build();

            gameFont = Content.Load<SpriteFont>("testSprite");

            currentMode = new TitleScreen(this, gameFont, "Press Start!");
        }

        public void Start()
        {
            currentMode = new GameScreen(this);
        }

        public void GameOver()
        {
            currentMode = new TitleScreen(this, gameFont, "Game over. Press Start to play again.");
        }

        public void YouWin()
        {
            currentMode = new TitleScreen(this, gameFont, "You win! Press Start to play again.");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            currentMode.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            currentMode.Draw(spriteBatch, gameTime);

            base.Draw(gameTime);
        }
    }

    public struct Textures
    {
        public Texture2D texNadine;
        public Texture2D texBullet;
        public Texture2D testMap;
        public Texture2D factoryMap;
        public Texture2D texMouse;
        public Texture2D texBaddog;
        public Texture2D texBirdie;
    }
}
