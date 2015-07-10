using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspectStar
{
    public class Enemy
    {
        GameScreen currentScreen;

        EnemyDef identity;
        public Vector2 location;
        Map currentMap;
        public bool inert;

        public Game1.Directions faceDir;

        int currentFrame;
        int stallCount;

        Game1.Aspects aspect;

        static Random r = new Random();

        public Enemy(EnemyDef ident, Vector2 loc, Map map, GameScreen screen, Game1.Aspects aspect = Game1.Aspects.None)
        {
            this.identity = ident;
            this.location = loc;
            this.currentMap = map;
            this.currentScreen = screen;

            this.faceDir = Game1.Directions.Down;
            this.currentFrame = 0;
            this.stallCount = 0;

            if (aspect == Game1.Aspects.None)
                this.aspect = (Game1.Aspects)r.Next(0, 3);
            else
                this.aspect = aspect;
        }

        public void Update(Vector2 target)
        {
            if (stallCount % identity.beSlow == 0) // Slowness
            {
                if (r.Next(10) > identity.beIndecisive) // Indecisive
                    this.Move(faceDir);
                else
                {
                    if (r.Next(10)>identity.beWanderer)
                    {
                        // Move towards the target
                        int x_tar = (int)(location.X - target.X);
                        int y_tar = (int)(location.Y - target.Y);
                        Game1.Directions targetDir;
                        if (Math.Abs(x_tar) > Math.Abs(y_tar))
                        {
                            if (x_tar > 0)
                                targetDir = Game1.Directions.Left;
                            else
                                targetDir = Game1.Directions.Right;
                        }
                        else
                        {
                            if (y_tar > 0)
                                targetDir = Game1.Directions.Up;
                            else
                                targetDir = Game1.Directions.Down;
                        }
                        this.faceDir = targetDir;
                    }
                    else
                        faceDir = (Game1.Directions)r.Next(0, 4);
                }
            }

            stallCount++;
            if (stallCount == 10)
            {
                currentFrame++;
                stallCount = 0;
            }
            if (currentFrame == 2)
                currentFrame = 0;
        }

        public bool Overlap(Vector2 loc)
        {
            return (((location.X + 16) > loc.X) && ((location.X - 16) < loc.X) && ((location.Y - 16) < loc.Y) && ((location.Y + 16) > loc.Y));
        }

        public bool takeDamage(Game1.Aspects asp)
        {
            // Returns true if enemy is killed
            if (asp == this.aspect)
                return true;
            else
                return false;
        }

        private void Move(Game1.Directions move_dir)
        {
            Vector2 move_vec = new Vector2(0, 0);
            switch (move_dir)
            {
                case Game1.Directions.Down:
                    move_vec = new Vector2(0, 2);
                    break;
                case Game1.Directions.Up:
                    move_vec = new Vector2(0, -2);
                    break;
                case Game1.Directions.Left:
                    move_vec = new Vector2(-2, 0);
                    break;
                case Game1.Directions.Right:
                    move_vec = new Vector2(2, 0);
                    break;
                default:
                    break; // Something has gone wrong
            }

            this.Move(move_vec);
        }

        private void Move(Vector2 move_vec)
        {
            Vector2 dest = location + move_vec;
            if (currentMap.squareSolid(dest))
            {
                if (!this.identity.light) PlaySound.Thud();
            }
            else
            {
                if (currentScreen.enemyOverlap(dest, this))
                    return;
                location = dest;
                Game1.Aspects test = currentMap.isAspect(location);
                if ((test != Game1.Aspects.None) && (test != this.aspect))
                {
                    this.aspect = test;
                    PlaySound.Aspect();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Color mask)
        {
            int dim = 32;
            int column = ((int)faceDir * 2) + currentFrame;
            int row = (int)aspect;
            Vector2 screen_loc = location - new Vector2(dim / 2, dim / 2);

            Rectangle sourceRectangle = new Rectangle(dim * column, dim * row, dim, dim);
            Rectangle destinationRectangle = new Rectangle((int)screen_loc.X, (int)screen_loc.Y, dim, dim);

            spriteBatch.Begin();
            spriteBatch.Draw(identity.texture, destinationRectangle, sourceRectangle, mask);
            spriteBatch.End();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.Draw(spriteBatch, Color.White);
        }
    }

    public struct EnemyDef
    {
        public Texture2D texture;
        // All intelligence definitions range from 0 to 10, except beSlow, this is minimized at 1
        public int beIndecisive; // Greater, more likely to change direction
        public int beWanderer; // Greater, more likely to not chase player
        public int beSlow; // greater, moves less often
        public bool light; // true, doesn't thud when hits wall
    }

    public static class EnemyDict
    {
        public static EnemyDef bird;
        public static EnemyDef mouse;
        public static EnemyDef smartmouse;
        public static EnemyDef dog;

        public static void build()
        {
            bird.texture = Game1.texCollection.texBirdie;
            bird.beIndecisive = 2; // bird-brain
            bird.beWanderer = 4;
            bird.beSlow = 1;
            bird.light = true;

            mouse.texture = Game1.texCollection.texMouse;
            mouse.beIndecisive = 1;
            mouse.beWanderer = 1;
            mouse.beSlow = 3;
            mouse.light = false;

            smartmouse.texture = Game1.texCollection.texMouse;
            smartmouse.beIndecisive = 1;
            smartmouse.beWanderer = 0;
            smartmouse.beSlow = 2;
            smartmouse.light = false;

            dog.texture = Game1.texCollection.texBaddog;
            dog.beIndecisive = 0;
            dog.beWanderer = 0;
            dog.beSlow = 1;
            dog.light = false;
        }
    }
}
