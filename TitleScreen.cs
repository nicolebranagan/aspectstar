using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AspectStar
{
    class TitleScreen : Screen
    {

        SpriteFont currentFont;
        string label;

        public TitleScreen(Game1 game, SpriteFont font, string label)
        {
            this.game = game;
            this.currentFont = font;
            this.label = label;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(currentFont, label, new Vector2(10, 10), Color.White);
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Enter))
            {
                PlaySound.Aspect();
                this.game.Start();
            }
                
        }
    }
}
