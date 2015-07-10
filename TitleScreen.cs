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

        string label;
        Vector2 pos;
        Texture2D font;

        public TitleScreen(Game1 game, string label, Texture2D font, Vector2 pos)
        {
            this.game = game;
            this.label = label;
            this.font = font;
            this.pos = pos;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            int asc;
            Rectangle sourceRect;
            Rectangle destRect;

            spriteBatch.Begin();
            for (int i = 0; i < label.Length ; i++)
            {
                destRect = new Rectangle((int)pos.X + i*16, (int)pos.Y, 16, 16);

                asc = (int)(label[i]);
                if ((asc >= 48) && (asc <= 57))
                {
                    asc = asc - 48;
                    sourceRect = new Rectangle(16 * asc, 0, 16, 16);
                    spriteBatch.Draw(font, destRect, sourceRect, Color.White);
                }
                else if ((asc >= 65) && (asc <= 90))
                {
                    asc = (asc - 65) + 10;
                    sourceRect = new Rectangle(16 * asc, 0, 16, 16);
                    spriteBatch.Draw(font, destRect, sourceRect, Color.White);
                }
            }
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
