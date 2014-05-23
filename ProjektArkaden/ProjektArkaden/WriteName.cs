using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ProjektArkaden
{
    class WriteName
    {
           private Game1 game;
        private KeyboardState lastState;
        string name;
        bool first = true;
        bool second = false;
        bool theerd = false;
        bool fourth = false;
        bool done = false;
        string firstLetter;
        string secondLetter;
        string theredLetter;
        string fourhtLetter;
        public static string highScoreName;
     char[] chars = new char[26];
        int state = 0;

        public string HighScoreName
        {
            get { return highScoreName; }
        }

        public WriteName(Game1 game)
        {
            this.game = game;
            lastState = Keyboard.GetState();
            first = true;

            name = "_ _ _ _";
            chars[0] = 'Q';
            chars[1] = 'W';
            chars[2] = 'E';
            chars[3] = 'R';
            chars[4] = 'T';
            chars[5] = 'Y';
            chars[6] = 'U';
            chars[7] = 'I';
            chars[8] = 'O';
            chars[9] = 'P';
            chars[10] = 'A';
            chars[11] = 'S';
            chars[12] = 'D';
            chars[13] = 'F';
            chars[14] = 'G';
            chars[15] = 'H';
            chars[16] = 'J';
            chars[17] = 'K';
            chars[18] = 'L';
            chars[19] = 'Z';
            chars[20] = 'X';
            chars[21] = 'C';
            chars[22] = 'V';
            chars[23] = 'B';
            chars[24] = 'N';
            chars[25] = 'M';
        }

        public void Update()
        {
            Console.WriteLine(first);
            KeyboardState keyboardState = Keyboard.GetState();
            if (KeyMouseReaders.KeyPressed(Keys.Right) && state != 25)
            {
                state++;
            }
            if (KeyMouseReaders.KeyPressed(Keys.Left) && state != 0)
            {
                state--;
            }
            if (KeyMouseReaders.KeyPressed(Keys.Enter) && first)
            {
                firstLetter = Convert.ToString(chars[state]);
                name = firstLetter + " _ _ _";
                second = true;
                first = false;

            }
            else
                if (KeyMouseReaders.KeyPressed(Keys.Enter) && second)
                {
                    secondLetter = "" + (chars[state]);
                    name = firstLetter + secondLetter + " _ _";
                    theerd = true;
                    second = false;

                }
                else
                    if (KeyMouseReaders.KeyPressed(Keys.Enter) && theerd)
                    {
                        theredLetter = "" + chars[state];
                        name = firstLetter + secondLetter + theredLetter + " _";
                        theerd = false;
                        fourth = true;
                    }
                    else
                        if (KeyMouseReaders.KeyPressed(Keys.Enter) && fourth)
                        {
                            fourhtLetter = "" + chars[state];
                            name = firstLetter + secondLetter + theredLetter + fourhtLetter;
                            done = true;
                            fourth = false;
                        }
                        else
                            if (KeyMouseReaders.KeyPressed(Keys.Enter) && done)
                            {
                                first = true;
                                done = false;
                                highScoreName = name;
                                game.HighScore();
                            }
                            else
                                if (KeyMouseReaders.KeyPressed(Keys.X) && done)
                                {

                                    name = firstLetter + secondLetter + theredLetter + " _";
                                    fourth = true;
                                    done = false;
                                }
                                else
                                    if (KeyMouseReaders.KeyPressed(Keys.X) && fourth)
                                    {
                                        theredLetter = null;
                                        name = firstLetter + secondLetter + " _ _";
                                        theerd = true;
                                        fourth = false;
                                    }
                                    else
                                        if (KeyMouseReaders.KeyPressed(Keys.X) && theerd)
                                        {
                                            secondLetter = null;
                                            name = firstLetter + " _ _ _";
                                            theerd = false;
                                            second = true;
                                        }
                                        else
                                            if (KeyMouseReaders.KeyPressed(Keys.X) && second)
                                            {
                                                firstLetter = null;
                                                name = " _ _ _ _";
                                                first = true;
                                                second = false;
                                            }
            if (keyboardState.IsKeyDown(Keys.Escape) && lastState.IsKeyUp(Keys.Escape))
            {
                game.Exit();
            }
            //if (keyboardState.IsKeyDown(Keys.X) && lastState.IsKeyUp(Keys.X))
            //{
            //    game.ToMenu();
            //}
            //lastState = keyboardState;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureManager.LoadingScreenTex, new Rectangle(0, 0, 1920, 1080), Color.White);

            for (int i = 0; i < chars.Length; i++)
            {
                spriteBatch.DrawString(TextureManager.ExtraBigFont, Convert.ToString(chars[i]), new Vector2(400 + 50 * i, 500), Color.White);

            }
            spriteBatch.DrawString(TextureManager.ExtraBigFont, Convert.ToString(chars[state]), new Vector2(400 + 50 * state, 500), Color.Red);
            if (name != null)
                spriteBatch.DrawString(TextureManager.ExtraBigFont, name, new Vector2((game.Window.ClientBounds.Width / 2) - (TextureManager.ExtraBigFont.MeasureString(name).X) / 2, 700), Color.White);
            if (done)
            {
                spriteBatch.DrawString(TextureManager.ExtraBigFont, "Press Enter to confirm name", new Vector2((game.Window.ClientBounds.Width / 2) - (TextureManager.ExtraBigFont.MeasureString("Press Enter to confirm name").X / 2), 750), Color.White);
            }

        }

    }

}
  
