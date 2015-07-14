using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace AspectStar
{
    public class GameScreen : Screen
    {
        private Player player;
        private int fireLag = 0;

        List<Bullet> bulletList = new List<Bullet>();

        List<Enemy> enemyList = new List<Enemy>();

        public Map currentMap;

        int currentLevel = 1;

        int lives = 3;

        enum GameState
        {
            Playing,
            DeathAnim,
            WinAnim,
            FadeIn,
            Paused,
        }

        int animCount = 50;
        bool stallpause = false;

        GameState runState;

        public GameScreen(Game1 game)
        {
            this.game = game;
            this.runState = GameState.FadeIn;

            loadNewLevel();
            
        }

        void loadNewLevel()
        {
            LevelDef level = Level.getLevel(currentLevel, this);

            if (currentLevel > Level.levelMax)
            {
                game.YouWin();
                return;
            }

            this.enemyList = level.enemyList;
            this.currentMap = level.levelMap;
            this.bulletList = new List<Bullet>();

            // Load in player
            player = new Player(Game1.texCollection.texNadine, new Vector2(400, 200), currentMap);

            runState = GameState.FadeIn;
            animCount = 50;
        }

        public override void Update(GameTime gameTime)
        {
            switch (this.runState)
            {
                case GameState.Paused:
                    if (this.animCount == 0)
                        this.animCount = 120;
                    else animCount--;
                    KeyboardState state = Keyboard.GetState();
                    if (state.IsKeyUp(Keys.Enter))
                        stallpause = false;
                    if (state.IsKeyDown(Keys.Enter) && !stallpause)
                    {
                        stallpause = true;
                        runState = GameState.Playing;
                    }
                    break;
                case GameState.FadeIn:
                    this.animCount = this.animCount - 1;
                    if (this.animCount == 0)
                        this.runState = GameState.Playing;
                    break;
                case GameState.DeathAnim:
                    if (this.lives == 1)
                        this.animCount = this.animCount - 1;
                    else
                        this.animCount = this.animCount - 2;
                    if (this.animCount == 0)
                    {
                        if (this.lives == 0)
                            this.game.GameOver();
                        else
                        {
                            this.lives--;
                            loadNewLevel();
                        }
                    }
                    break;
                case GameState.WinAnim:
                    this.animCount = this.animCount - 1;
                    if (this.animCount == 0)
                    {
                        currentLevel++;
                        loadNewLevel();
                    }
                    break;
                default:
                    RunUpdate(gameTime);
                    break;
            }
        }

        public void RunUpdate(GameTime gameTime)
        {
            // Get input
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Game1.controls.Up))
            {
                player.moving = true;
                player.faceDir = Game1.Directions.Up;
            }
            else if (state.IsKeyDown(Game1.controls.Down))
            {
                player.moving = true;
                player.faceDir = Game1.Directions.Down;
            }
            else if (state.IsKeyDown(Game1.controls.Left))
            {
                player.moving = true;
                player.faceDir = Game1.Directions.Left;
            }
            else if (state.IsKeyDown(Game1.controls.Right))
            {
                player.moving = true;
                player.faceDir = Game1.Directions.Right;
            }
            else
            {
                player.moving = false;
            }

            // Firing a bullet
            if (fireLag == 0)
            {
                if (state.IsKeyDown(Game1.controls.Shoot))
                {
                    bulletList.Add(player.Fire());
                    fireLag = 40;
                }
            }
            else
                fireLag--;

            // Pausing
            if (state.IsKeyDown(Keys.Enter) & !stallpause)
            {
                animCount = 0;
                this.runState = GameState.Paused;
                stallpause = true;
                PlaySound.Pause();
            }
            if (stallpause & state.IsKeyUp(Keys.Enter))
                stallpause = false;

            // 1-body problems
            player.Update();
            foreach (Enemy i in enemyList)
                i.Update(player.location);
            foreach (Bullet i in bulletList)
                i.Update();

            // 2-body problems

            // Bullet interactions
            foreach (Bullet i in bulletList)
            {
                foreach (Enemy j in enemyList)
                {
                    if (j.Overlap(i.location))
                    {
                        i.inert = true;
                        if (j.takeDamage(i.aspect))
                        {
                            j.inert = true;
                            PlaySound.Boom();
                        }
                        else
                            PlaySound.Thud();
                    }
                }
            }

            // Multiple-character interactions
            // Enemy-character
            foreach (Enemy j in enemyList)
                if (isCircle(j.location, player.location))
                {
                    this.runState = GameState.DeathAnim;
                    this.animCount = 250;
                    PlaySound.Die();
                }

            // Clean up
            enemyList.RemoveAll(isInertEnemy);
            bulletList.RemoveAll(isInertBullet);

            // Win condition
            if (enemyList.Count == 0)
            {
                this.runState = GameState.WinAnim;
                this.animCount = 100;
                PlaySound.Win();
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            switch (runState)
            {
                case GameState.Paused:
                    Color pauseMask = Color.White;
                    if (animCount > 80)
                        pauseMask.R = 0;
                    else if (animCount > 40)
                        pauseMask.G = 0;
                    else
                        pauseMask.B = 0;
                    currentMap.Draw(spriteBatch, pauseMask);
                    // Draw lives
                    spriteBatch.Begin();
                    for (int i = this.lives; i > 0; i--)
                    {
                        Rectangle sourceRectangle = new Rectangle(0, 32 * (int)(player.aspect), 32, 32);
                        Rectangle destRectangle = new Rectangle((800 - (i * 32)), (480 - 32), 32, 32);
                        spriteBatch.Draw(Game1.texCollection.texNadine, destRectangle, sourceRectangle, Color.White);
                    }
                    spriteBatch.End();
                    break;
                case GameState.FadeIn:
                    Color mask4 = Color.White;
                    mask4.R = (byte)(mask4.R - (animCount * (255 / 50)));
                    mask4.G = (byte)(mask4.G - (animCount * (255 / 50)));
                    mask4.B = (byte)(mask4.B - (animCount * (255 / 50)));
                    currentMap.Draw(spriteBatch, mask4);
                    break;
                case GameState.WinAnim:
                    Color mask3 = Color.White;
                    if (animCount > 75)
                    {
                        mask3.R = (byte)(mask3.R - ((100 - animCount) * (200 / 25)));
                    }
                    else if (animCount > 50)
                    {
                        mask3.R = (byte)(mask3.R + ((75 - animCount) * (200 / 25)));
                    }
                    else if (animCount > 25)
                    {
                        mask3.G = (byte)(mask3.G - ((50 - animCount) * (200 /25)));
                    }
                    else
                    {
                        mask3.G = (byte)(mask3.G + ((25 - animCount) * (200 /25)));
                    }
                    currentMap.Draw(spriteBatch, mask3);
                    break;
                case GameState.DeathAnim:
                    Color mask = Color.White;
                    Color mask2 = Color.White;
                    mask.G = (byte)(animCount / 2);
                    mask.B = (byte)(animCount / 2);
                    mask.R = (byte)(animCount);
                    mask2.R = (byte)(animCount / 2);
                    mask2.G = (byte)(animCount / 2);
                    mask2.B = (byte)(animCount / 2);
                    currentMap.Draw(spriteBatch, mask);
                    player.Draw(spriteBatch, mask2);
                    foreach (Enemy i in enemyList)
                        i.Draw(spriteBatch, mask2);
                    break;
                default:
                    currentMap.Draw(spriteBatch);
                    player.Draw(spriteBatch);
                    foreach (Enemy i in enemyList)
                        i.Draw(spriteBatch);
                    foreach (Bullet i in bulletList)
                        i.Draw(spriteBatch, Game1.texCollection.texBullet);
                    // Draw lives
                    spriteBatch.Begin();
                    for (int i = this.lives; i>0; i--)
                    {
                        Rectangle sourceRectangle = new Rectangle(0, 32 * (int)(player.aspect), 32, 32);
                        Rectangle destRectangle = new Rectangle((800 - (i * 32)), (480 - 32), 32, 32);
                        spriteBatch.Draw(Game1.texCollection.texNadine, destRectangle, sourceRectangle, Color.White);
                    }
                    spriteBatch.End();
                    break;
            }
        }

        // Check functions

        public bool enemyOverlap(Vector2 target, Enemy identity)
        {
            bool check = false;
            foreach (Enemy e in enemyList)
            {
                if ((e != identity) && (isCircle(target, e.location)))
                {
                    check = true;
                    break;
                }
            }
            return check;
        }

        private bool isCircle(Vector2 loc1, Vector2 loc2)
        {
            return (( Math.Pow(loc1.X - loc2.X, 2) + Math.Pow(loc1.Y - loc2.Y,2) ) < Math.Pow(24,2));
        }

        // Search predicates

        private static bool isInertEnemy(Enemy e)
        {
            return e.inert;
        }

        private static bool isInertBullet(Bullet b)
        {
            return b.inert;
        }
    }
}
