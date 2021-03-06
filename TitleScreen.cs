﻿using System;
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
        Vector2 posi;
        Texture2D font;

        enum TitleState
        {
            DisplayText,
            TitleScreen,
            Options
        }

        TitleState runState;

        int selection = 0;
        int controlLag = 0;

        public TitleScreen(Game1 game, string label, Texture2D font, Vector2 pos)
        {
            this.game = game;
            this.label = label;
            this.font = font;
            this.posi = pos;

            this.runState = TitleState.DisplayText;
        }

        public TitleScreen(Game1 game)
        {
            this.runState = TitleState.TitleScreen;
            this.game = game;
            this.font = Game1.texCollection.arcadeFont;
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            switch (runState)
            {
                case TitleState.Options:
                    int optOffset = -3; // Counter for vertical lines
                    WriteText(spriteBatch, "ASPECT STAR OPTIONS", new Vector2((800 / 2) - (19 * 8), 64 + optOffset*16), Color.White);

                    optOffset = optOffset + 4;
                    WriteText(spriteBatch, "SET CONTROLS", new Vector2(128, 64 + optOffset * 16), Color.White);
                    optOffset = optOffset + 2;
                    WriteText(spriteBatch, "UP", new Vector2(256, 64 + optOffset * 16), (selection == 101) ? Color.Red : Color.DarkGray);
                    optOffset = optOffset + 2;
                    WriteText(spriteBatch, "DOWN", new Vector2(256, 64 + optOffset * 16), (selection == 102) ? Color.Red : Color.DarkGray);
                    optOffset = optOffset + 2;
                    WriteText(spriteBatch, "LEFT", new Vector2(256, 64 + optOffset * 16), (selection == 103) ? Color.Red : Color.DarkGray);
                    optOffset = optOffset + 2;
                    WriteText(spriteBatch, "RIGHT", new Vector2(256, 64 + optOffset * 16), (selection == 104) ? Color.Red : Color.DarkGray);
                    optOffset = optOffset + 2;
                    WriteText(spriteBatch, "SHOOT", new Vector2(256, 64 + optOffset * 16), (selection == 105) ? Color.Red : Color.DarkGray);

                    optOffset = optOffset + 4;
                    if (PlaySound.Enabled)
                        WriteText(spriteBatch, "SOUND EFFECTS ON", new Vector2(128, 64 + optOffset * 16), Color.White);
                    else
                        WriteText(spriteBatch, "SOUND EFFECTS OFF", new Vector2(128, 64 + optOffset * 16), Color.White);

                    optOffset = optOffset + 4;
                    WriteText(spriteBatch, "FULL SCREEN MODE", new Vector2(128, 64 + optOffset * 16), Color.White);

                    optOffset = optOffset + 4;
                    WriteText(spriteBatch, "RETURN TO TITLE", new Vector2(128, 64 + optOffset * 16), Color.White);

                    if (this.selection == 0)
                    {
                        // RETURN TO TITLE
                        drawCursor(spriteBatch, new Vector2(128 - (4*16), 64 + optOffset * 16 - 8));
                    }
                    else if (this.selection == 1)
                    {
                        // SET CONTROLS
                        drawCursor(spriteBatch, new Vector2(128 - (4 * 16), 64 + 1 * 16 - 8));
                    }
                    else if (this.selection == 2)
                    {
                        // SOUND EFFECTS
                        drawCursor(spriteBatch, new Vector2(128 - (4 * 16), 64 + (optOffset - 8) * 16 - 8));
                    }
                    else if (this.selection == 3)
                    {
                        // FULL SCREEN MODE
                        drawCursor(spriteBatch, new Vector2(128 - (4 * 16), 64 + (optOffset - 4) * 16 - 8));
                    }

                    break;
                case TitleState.TitleScreen:
                    WriteText(spriteBatch, "ASPECT STAR", new Vector2((800 / 2) - (11 * 8), 128), Color.White);
                    WriteText(spriteBatch, "PLAY", new Vector2(376, (128 + 4 * 16)), Color.White);
                    WriteText(spriteBatch, "OPTIONS", new Vector2(376, (128 + 7 * 16)), Color.White);
                    WriteText(spriteBatch, "2015 NICOLE", new Vector2(376 - (4*16), (128 + 10 * 16)), Color.White);

                    if (this.selection == 0)
                        drawCursor(spriteBatch, new Vector2(376 - (4 * 16), 128 + 4 * 16 - 8));
                    else
                        drawCursor(spriteBatch, new Vector2(376 - (4 * 16), 128 + 7 * 16 - 8));
                    break;
                case TitleState.DisplayText:
                    WriteText(spriteBatch, label, posi, Color.White);
                    break;
            }
        }

        void drawCursor(SpriteBatch spriteBatch, Vector2 pos)
        {
            Rectangle source = new Rectangle(32 * selection, 0, 32, 32);
            if (runState != TitleState.TitleScreen)
                source = new Rectangle(0, 0, 32, 32);
            Rectangle dest = new Rectangle((int)pos.X, (int)pos.Y, 32, 32);

            spriteBatch.Begin();
            spriteBatch.Draw(Game1.texCollection.texNadine, dest, source, Color.White);
            spriteBatch.End();
        }

        void WriteText(SpriteBatch spriteBatch, string text, Vector2 pos, Color textColor)
        {
            Rectangle destRect;
            Rectangle sourceRect;
            int asc;

            spriteBatch.Begin();
            for (int i = 0; i < text.Length; i++)
            {
                destRect = new Rectangle((int)pos.X + i * 16, (int)pos.Y, 16, 16);

                asc = (int)(text[i]);
                if ((asc >= 48) && (asc <= 57))
                {
                    asc = asc - 48;
                    sourceRect = new Rectangle(16 * asc, 0, 16, 16);
                    spriteBatch.Draw(font, destRect, sourceRect, textColor);
                }
                else if ((asc >= 65) && (asc <= 90))
                {
                    asc = (asc - 65) + 10;
                    sourceRect = new Rectangle(16 * asc, 0, 16, 16);
                    spriteBatch.Draw(font, destRect, sourceRect, textColor);
                }
            }
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            Keys[] downKeys = state.GetPressedKeys();

            switch (runState)
            {
                case TitleState.Options:
                    if (this.controlLag == 0)
                    {
                        if (this.selection < 100)
                        {
                            // Not setting controls
                            if (state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.Down) || 
                                state.IsKeyDown(Game1.controls.Up) || state.IsKeyDown(Game1.controls.Down))
                            {
                                // If you add more than two options, make sure that this is changed appropriately
                                this.controlLag = 16;
                                if (state.IsKeyDown(Keys.Up) || state.IsKeyDown(Game1.controls.Up))
                                    this.selection--;
                                if (state.IsKeyDown(Keys.Down) || state.IsKeyDown(Game1.controls.Down))
                                    this.selection++;
                                if (this.selection > 3)
                                    this.selection = 0;
                                if (this.selection < 0)
                                    this.selection = 3;
                            }
                            else if (state.IsKeyDown(Keys.Enter) || state.IsKeyDown(Game1.controls.Shoot))
                            {
                                PlaySound.Pause();
                                this.controlLag = 16;
                                if (this.selection == 0)
                                {
                                    // Return to title screen
                                    this.selection = 0;
                                    this.runState = TitleState.TitleScreen;
                                }
                                else if (this.selection == 1)
                                {
                                    // Go into control-setting mode
                                    this.selection = 101;
                                }
                                else if (this.selection == 2)
                                {
                                    // Change sound effects
                                    PlaySound.Enabled = !(PlaySound.Enabled);
                                }
                                else if (this.selection == 3)
                                {
                                    // Enter/exit full screen
                                    this.game.ToggleFullScreen();
                                }
                            }
                        }
                        else if (downKeys.Any())
                        {
                            // Setting controls
                            // 101 - Up
                            // 102 - Down
                            // 103 - Left
                            // 104 - Right
                            // 105 - Shoot

                            Keys testKey = downKeys[0];
                            if (testKey != Keys.Enter)
                            {
                                switch (selection)
                                {
                                    case 101:
                                        Game1.controls.Up = testKey;
                                        break;
                                    case 102:
                                        Game1.controls.Down = testKey;
                                        break;
                                    case 103:
                                        Game1.controls.Left = testKey;
                                        break;
                                    case 104:
                                        Game1.controls.Right = testKey;
                                        break;
                                    case 105:
                                        Game1.controls.Shoot = testKey;
                                        break;
                                }
                                PlaySound.Pause();
                                controlLag = 16;
                                selection++;
                                if (selection == 106)
                                    selection = 0;
                            }
                        }
                    }
                    else
                    {
                        this.controlLag--;
                    }
                    break;
                case TitleState.TitleScreen:
                    if (this.controlLag == 0 && (state.IsKeyDown(Keys.Enter) || state.IsKeyDown(Game1.controls.Shoot)))
                    {
                        if (this.selection == 0)
                        {
                            PlaySound.Aspect();
                            this.game.Start();
                        }
                        else
                        {
                            PlaySound.Pause();
                            this.selection = 0;
                            this.runState = TitleState.Options;
                            this.controlLag = 16;
                        }
                    }
                    else if (this.controlLag == 0 && (state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.Down) ||
                        state.IsKeyDown(Game1.controls.Up) || state.IsKeyDown(Game1.controls.Down)))
                    {
                        this.controlLag = 16;
                        this.selection++;
                        if (this.selection > 1)
                            this.selection = 0;
                    }

                    if (this.controlLag > 0)
                        this.controlLag--;
                    break;
                default:
                    if (state.IsKeyDown(Keys.Enter))
                    {
                        PlaySound.Aspect();
                        this.game.Start();
                    }
                    break;
            }
                
        }
    }
}
