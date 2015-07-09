using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AspectStar
{
    class Bullet
    {
        Map currentMap;

        public Vector2 location { get; set; }
        Game1.Directions moveDir;
        public Game1.Aspects aspect;
        Rectangle texture;
        public bool inert;

        public Bullet(Map map, Vector2 loc, Game1.Directions dir, Game1.Aspects asp)
        {
            currentMap = map;
            location = loc;
            moveDir = dir;
            aspect = asp;
            inert = false;

            texture = new Rectangle(0, (int)asp * 6, 6, 6);
        }

        public void Update()
        {
            if (!inert)
            {
                Vector2 move_dist = new Vector2(0, 0);
                switch (moveDir)
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
                if (currentMap.isSolid(this.location + move_dist))
                    this.inert = true;
                else
                    this.location = this.location + move_dist;

                if (this.location.X < 0 || this.location.Y < 0 || this.location.X > 800 || this.location.Y > 480)
                    this.inert = true; // kill bullets that go offscreen
            }
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D texBullet)
        {
            if (!inert)
            {
                Rectangle rect = new Rectangle((int)location.X -3 , (int)location.Y - 3, 6, 6);
                spriteBatch.Begin();
                spriteBatch.Draw(texBullet, rect, texture, Color.White);
                spriteBatch.End();
            }
        }
    }
}
