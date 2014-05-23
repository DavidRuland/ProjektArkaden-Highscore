using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace ProjektArkaden
{
    class StartScreen
    {
       
       private Game1 game;
       private KeyboardState lastState;
       private int x, y;
       private  Rectangle startButtonRect;
       private Rectangle exitButtonRect;
       private Rectangle highScoreRect;
       private Rectangle creditsBurronRect;
       private Vector2 pos, pos2,pos3, pos4;
       private Rectangle mouseClickRect;
       private MouseState mousState,prevMousState;
       private Thread thread;
       private int state = 1;
     
        public StartScreen(Game1 game)
        {
            this.game = game;
            pos = new Vector2((game.GraphicsDevice.Viewport.Width / 2) - TextureManager.startButton.Width / 2, 400);
            pos2 = new Vector2((game.GraphicsDevice.Viewport.Width / 2) - TextureManager.startButton.Width / 2, 500);
            pos3 = new Vector2((game.GraphicsDevice.Viewport.Width / 2) - TextureManager.startButton.Width / 2, 600);
            pos4 = new Vector2((game.GraphicsDevice.Viewport.Width / 2) - TextureManager.startButton.Width / 2, 700);

            lastState = Keyboard.GetState();
        }
        public void MouseClicked(int x,int y)
        {
            this.x = x;
            this.y = y;
            mouseClickRect = new Rectangle(x, y, 10, 10);
            startButtonRect = new Rectangle((int)pos.X, (int)pos.Y, 300, 60);
            highScoreRect = new Rectangle((int)pos2.X, (int)pos2.Y, 300, 60);
            creditsBurronRect = new Rectangle((int)pos3.X, (int)pos3.Y, 300, 60);
            exitButtonRect = new Rectangle((int)pos4.X, (int)pos4.Y, 300, 60);

            //if (KeyMouseReaders.KeyPressed(Keys.Up) && state != 1)
            //    state--;
            //if (KeyMouseReaders.KeyPressed(Keys.Down) && state != 3)
            //    state++;
            //if(mouseClickRect.Intersects(startButtonRect))
            //{
            //if (state == 1 && KeyMouseReaders.KeyPressed(Keys.Enter))
            //{
            //    game.Loading();
            //    if (game.isLoading)
            //    {
            //        Thread.Sleep(1);
            //        thread = new Thread(game.StartGame);
            //        thread.Start();
            //    }
            //}
         //else if (mouseClickRect.Intersects(exitButtonRect))
            //{
                //if (state == 2 && KeyMouseReaders.KeyPressed(Keys.Enter))
                //game.Exit();
               
            //}
          //else  if (mouseClickRect.Intersects(highScoreRect))
          //  {
          //    if(state == 3 && KeyMouseReaders.KeyPressed(Keys.E))
          //      game.HighScore();
          //  }
           
            
        }

        public void Update()
        {
            mousState = Mouse.GetState();
            if (prevMousState.LeftButton==ButtonState.Pressed &&mousState.LeftButton==ButtonState.Released)
            {
                MouseClicked(mousState.X, mousState.Y);
                
            }
            if (KeyMouseReaders.KeyPressed(Keys.Up) && state != 1)
                state--;
            if (KeyMouseReaders.KeyPressed(Keys.Down) && state != 4)
                state++;
            if (state == 1 && KeyMouseReaders.KeyPressed(Keys.Enter))
            {
                game.Loading();
                if (game.isLoading)
                {
                    Thread.Sleep(1);
                    thread = new Thread(game.StartGame);
                    thread.Start();
                //game.StartGame();
                }
            }
            if (state == 2 && KeyMouseReaders.KeyPressed(Keys.Enter))
                game.HighScore();
            if (state == 3 && KeyMouseReaders.KeyPressed(Keys.Enter))
                game.Credits();
           if (state == 4 && KeyMouseReaders.KeyPressed(Keys.Enter))
                game.Exit();

            prevMousState = mousState;

           

        }

        public void Draw(SpriteBatch spriteBatch)
        {

           
                spriteBatch.Draw(TextureManager.startButton,pos,Color.White);
            if (state == 1)
                spriteBatch.Draw(TextureManager.startButton, pos, Color.Red);
                spriteBatch.Draw(TextureManager.highScoreButton, pos2, Color.White);
            if (state == 2)
                spriteBatch.Draw(TextureManager.highScoreButton, pos2, Color.Red);
            spriteBatch.Draw(TextureManager.creditsButton, pos3, Color.White);
            if (state == 3)
                spriteBatch.Draw(TextureManager.creditsButton, pos3, Color.Red);
            spriteBatch.Draw(TextureManager.exitButton, pos4, Color.White);
            if (state == 4)
                spriteBatch.Draw(TextureManager.exitButton, pos4, Color.Red);

        }

    }

}


 