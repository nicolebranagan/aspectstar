using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AspectStar
{
    class Player
    {
        public Texture2D Texture { get; set; }
        private int currentFrame;
        private int stallCount;

        public Vector2 location;
        public bool moving;
        public Game1.Directions faceDir;

        public Game1.Aspects aspect { get; set; }

        Map currentMap;

        public Player(Texture2D texture, Vector2 loc, Map map)
        {
            currentMap = map;

            Texture = texture;
            location = loc;
            currentFrame = 0;
            stallCount = 0;

            faceDir = Game1.Directions.Down;
            moving = false;

            aspect = Game1.Aspects.Blue;
        }

        public void Update()
        {
            stallCount++;
            if (stallCount == 10)
            {
                currentFrame++;
                stallCount = 0;
            }
            if (currentFrame == 2)
                currentFrame = 0;

            if (moving == false)
                currentFrame = 0;
            if ((stallCount % 4 != 0) && (moving))
            {
                Vector2 move_dist = new Vector2(0, 0);
                switch (faceDir)
                {
                    case Game1.Directions.Down:
                        move_dist = new Vector2(0, 2);
                        break;
                    case Game1.Directions.Up:
                        move_dist = new Vector2(0, -2);
                        break;
                    case Game1.Directions.Left:
                        move_dist = new Vector2(-2, 0);
                        break;
                    case Game1.Directions.Right:
                        move_dist = new Vector2(2, 0);
                        break;
                    default:
                        break; // Something has gone wrong
                }
                this.Move(move_dist);
            }
        }

        public Bullet Fire()
        {
            PlaySound.Pew();
            Vector2 fire_dist = new Vector2(0, 0);
            switch (faceDir)
            {
                case Game1.Directions.Down:
                    fire_dist = new Vector2(0, 16);
                    break;
                case Game1.Directions.Up:
                    fire_dist = new Vector2(0, -16);
                    break;
                case Game1.Directions.Left:
                    fire_dist = new Vector2(-16, 0);
                    break;
                case Game1.Directions.Right:
                    fire_dist = new Vector2(16, 0);
                    break;
                default:
                    break; // Something has gone wrong
            }

            return new Bullet(currentMap, this.location + fire_dist, this.faceDir, this.aspect);
        }

        private void Move(Vector2 move_vec)
        {
            Vector2 dest = location + move_vec;
            //if (currentMap.isSolid(location + (move_vec * 8)))
            if (currentMap.squareSolid(dest))
            {
                PlaySound.Thud();
            }
            else
            {
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
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, mask);
            spriteBatch.End();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.Draw(spriteBatch, Color.White);
        }
    }
}
