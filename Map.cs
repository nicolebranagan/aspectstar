using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AspectStar
{
    public class Map
    {
        public const int rows = 15; // 480 pixels divided into 15 32x32 tiles
        public const int columns = 25; // 800 pixels divided into 25 32x32 tiles
        const int square = 32; // tile size

        enum Type
        {
            Empty = 0,
            Solid = 1,
            AspBlue = 2,
            AspGreen = 3,
            AspRed = 4
        }

        Texture2D texture;
        int[] key;
        int[] tileMap;

        public Map(Texture2D tex, int[] key, int[] map)
        {
            this.texture = tex;
            this.key = key;
            this.tileMap = map;
        }

        public void Draw(SpriteBatch spriteBatch, Color filter)
        {
            Rectangle source;
            Rectangle dest;
            spriteBatch.Begin();
            for (int i = 0; i < (rows*columns); i++)
            {
                source = new Rectangle(tileMap[i]*square,0,square,square);
                dest = new Rectangle((i % columns)*square, (i / columns)*square, square, square);
                spriteBatch.Draw(texture, dest, source, filter);
            }
            spriteBatch.End();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.Draw(spriteBatch, Color.White);
        }

        public bool isSolid(Vector2 loc)
        {
            // If something is solid, it is completely solid, i.e., you can not go there under any circumstances.
            return getTile(loc) == Type.Solid;
        }

        public bool squareSolid(Vector2 loc)
        {
            // Checks whether a square centered at loc is at all solid
            return isSolid(new Vector2(loc.X, loc.Y - 10)) || isSolid(new Vector2(loc.X, loc.Y + 10)) ||
                isSolid(new Vector2(loc.X - 10, loc.Y)) || isSolid(new Vector2(loc.X + 10, loc.Y)) ||
                isSolid(new Vector2(loc.X - 10, loc.Y - 10)) || isSolid(new Vector2(loc.X - 10, loc.Y + 10)) ||
                isSolid(new Vector2(loc.X + 10, loc.Y - 10)) || isSolid(new Vector2(loc.X + 10, loc.Y + 10)) ||
                isSolid(loc);
        }

        public Game1.Aspects isAspect(Vector2 loc)
        {
            Type testType = getTile(loc);
            Game1.Aspects ret = Game1.Aspects.None;
            switch (testType)
            {
                case Type.AspBlue:
                    ret = Game1.Aspects.Blue;
                    break;
                case Type.AspGreen:
                    ret = Game1.Aspects.Green;
                    break;
                case Type.AspRed:
                    ret = Game1.Aspects.Red;
                    break;
                default:
                    break;
            }
            if (ret != Game1.Aspects.None)
            {
                int x = (int)Math.Floor(loc.X / square) * square + (square/2);
                int y = (int)Math.Floor(loc.Y / square) * square + (square/2);
                if ((Math.Pow((x - loc.X),2) + Math.Pow((y - loc.Y), 2)) > Math.Pow((square / 2),2))
                    ret = Game1.Aspects.None;
            }

            return ret;
        }

        private Type getTile(int x, int y)
        {
            int point = y * columns + x;
            return (Type)key[tileMap[point]];
        }

        private Type getTile(Vector2 loc)
        {
            int x = (int)Math.Floor(loc.X / square);
            int y = (int)Math.Floor(loc.Y / square);
            return getTile(x, y);
        }
    }
}
