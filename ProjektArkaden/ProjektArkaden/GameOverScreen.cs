using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.Threading;

namespace ProjektArkaden
{
    class GameOverScreen
    {
      
        private Game1 game;
        private KeyboardState lastState;
        private Thread thread;
        public GameOverScreen(Game1 game)
        {
            this.game = game;
           lastState = Keyboard.GetState();
        }

        public void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            if (keyboardState.IsKeyDown(Keys.Escape) && lastState.IsKeyUp(Keys.Escape))
            {

                game.Exit();
            }


            if (keyboardState.IsKeyDown(Keys.Enter) && lastState.IsKeyUp(Keys.Enter))
            {
                //game.Loading();
                //if (game.isLoading)
                //{
                //    Thread.Sleep(1);
                //    thread = new Thread(game.StartGame);
                //    thread.Start();
                //}
                game.WriteName();


            }
            if (keyboardState.IsKeyDown(Keys.X) && lastState.IsKeyUp(Keys.X))
            {

                game.ToMenu();
            }


            lastState = keyboardState;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
        
                spriteBatch.Draw(TextureManager.gameOverTex, new Rectangle(0, 0, 1920, 1080), Color.White);
           
        }

    }

}


  