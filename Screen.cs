using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspectStar
{
    public abstract class Screen
    {
        protected Game1 game;

        abstract public void Update(GameTime gameTime);
        abstract public void Draw(SpriteBatch spriteBatch, GameTime gameTime);
    }
}
