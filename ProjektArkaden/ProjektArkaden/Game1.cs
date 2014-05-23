using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;

namespace ProjektArkaden
{
    enum Screen
    {

        Layer,
        Layer2,
        Layer3,
        Layer4,
        GameOverScreen,
        LevelScreen,
        Loading,
        StartScreen,
        CreditsScreen,
        HighScoreScreen,
        WriteName,
       


    }
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public static GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Layer layer;
        Layer2 layer2;
        Layer3 layer3;
        Layer4 layer4;
        GameOverScreen gameOver;
        HighScoreScreen highScoreScreen;
        WriteName writeName;
     public static int width = 1920;
        int height = 1080;
        WaveManager waveManager;
        Screen currentScreen;
        public bool isLoading = false;
        StartScreen screen;
       public string name;
        double levelTimer = 0;
        public static List<int> scoreList;
        public static List<int> BestPlayerScoreList;
        
  
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            TextureManager.LoadContent(Content);
            //waveManager = new WaveManager(this, 4);
            //waveManager.LoadContent(Content);
            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            //layer = new Layer(this);
            //currentScreen = Screen.Layer;
            screen = new StartScreen(this);
            currentScreen = Screen.StartScreen;
            IsMouseVisible = true;
            scoreList = new List<int>();
            BestPlayerScoreList = new List<int>();
          


        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
            KeyMouseReaders.Update();
            //waveManager.Update(gameTime);
            switch (currentScreen)
            {
                case Screen.StartScreen:
                    screen.Update();
                    if (KeyMouseReaders.KeyPressed(Keys.Q))
                        StartWave2();
                    break;
                case Screen.Layer:

                    layer.Update(gameTime);
                    waveManager.Update(gameTime);


                    break;

                case Screen.Layer2:

                    layer2.Update();
                    waveManager.Update(gameTime);
                    break;

                case Screen.Layer3:


                    layer3.Update();
                    waveManager.Update(gameTime);
                    break;

                case Screen.Layer4:


                    layer4.Update();
                    waveManager.Update(gameTime);
                    break;

                case Screen.LevelScreen:
                    levelTimer += gameTime.ElapsedGameTime.TotalSeconds;
                    if (levelTimer > 5 && waveManager.CurrentWave.RoundNumber == 1)
                    {
                        levelTimer = 0;
                        StartWave2();
                    }
                    if (levelTimer > 5 && waveManager.CurrentWave.RoundNumber == 2)
                    {
                        levelTimer = 0;
                        StartWave3();
                    }
                    if (levelTimer > 5 && waveManager.CurrentWave.RoundNumber == 3)
                    {
                        levelTimer = 0;
                        StartWave4();
                    }
                    break;

                case Screen.GameOverScreen:

                    gameOver.Update();

                    break;
                case Screen.Loading:


                    isLoading = true;

                    break;
                case Screen.CreditsScreen:
                    if (KeyMouseReaders.KeyPressed(Keys.X))
                        ToMenu();
                    break;
                case Screen.HighScoreScreen:
                    if (KeyMouseReaders.KeyPressed(Keys.X))
                        ToMenu();
                    break;
                case Screen.WriteName:
                    //if (KeyMouseReaders.KeyPressed(Keys.X))
                    //    ToMenu();
                    writeName.Update();
                   
                    break;
                

            }

            base.Update(gameTime);


        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            switch (currentScreen)
            {

                case Screen.StartScreen:
                    spriteBatch.Draw(TextureManager.LoadingScreenTex, new Rectangle(0, 0, 1920, 1080), Color.White);
                    screen.Draw(spriteBatch);
                    break;
           
                case Screen.Layer:

                    layer.Draw(spriteBatch);
                    waveManager.Draw(spriteBatch);
                    break;


                case Screen.Layer2:

                    layer2.Draw(spriteBatch);

                    waveManager.Draw(spriteBatch);
                    break;

                case Screen.Layer3:

                    layer3.Draw(spriteBatch);
                    waveManager.Draw(spriteBatch);

                    break;

                case Screen.Layer4:

                    layer4.Draw(spriteBatch);
                    waveManager.Draw(spriteBatch);

                    break;
                case Screen.LevelScreen:
                    spriteBatch.Draw(TextureManager.LoadingScreenTex, new Rectangle(0, 0, 1920, 1080), Color.White);
                    spriteBatch.DrawString(TextureManager.BigTexFont, "Player 1 Score: " + waveManager.Player1.currentScore, new Vector2(400, 400), Color.Green);
                    spriteBatch.DrawString(TextureManager.BigTexFont, "Player 1 Health: " + waveManager.Player1.p1CurrentHealth, new Vector2(400, 450), Color.Green);
                    spriteBatch.DrawString(TextureManager.BigTexFont, "Player 2 Score: " + waveManager.Player2.currentScore, new Vector2(1200, 400), Color.Red);
                    spriteBatch.DrawString(TextureManager.BigTexFont, "Player 2 Health: " + waveManager.Player2.p2CurrentHealth, new Vector2(1200, 450), Color.Red);
                    spriteBatch.DrawString(TextureManager.BigTexFont, "United Score: " + (waveManager.Player1.currentScore + waveManager.Player2.currentScore), new Vector2(800, 425), Color.Blue);
                    spriteBatch.DrawString(TextureManager.BigTexFont, "Time to next level: " + (5 - (int)levelTimer), new Vector2(800, 600), Color.White);

                    break;
                case Screen.GameOverScreen:
                    gameOver.Draw(spriteBatch);
                    spriteBatch.DrawString(TextureManager.BigTexFont, "Player 1 score: " + waveManager.Player1.currentScore, new Vector2(50, 150), Color.Green);
                    spriteBatch.DrawString(TextureManager.BigTexFont, "Player 2 score: " + waveManager.Player2.currentScore, new Vector2(50, 250), Color.Red);
                    spriteBatch.DrawString(TextureManager.BigTexFont, "United score: " + waveManager.UnitedScore, new Vector2(50, 350), Color.Blue);
                    spriteBatch.DrawString(TextureManager.ExtraBigFont, "Press X for main menu", new Vector2(50, 700), Color.White);
                    break;
                case Screen.Loading:
                    spriteBatch.Draw(TextureManager.LoadingScreenTex, new Rectangle(0, 0, 1920, 1080), Color.White);
                    string loading = "LOADING, PLEASE WAIT ";
                    spriteBatch.DrawString(TextureManager.BigTexFont, loading, new Vector2((GraphicsDevice.Viewport.Width / 2) - (TextureManager.BigTexFont.MeasureString(loading).X / 2), GraphicsDevice.Viewport.Height / 2), Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 1);


                    break;
                case Screen.CreditsScreen:
                    spriteBatch.Draw(TextureManager.CreditsScreenTex, new Rectangle(0, 0, 1920, 1080), Color.White);
                    string ToMenu = "Press X to go to menu";
                    spriteBatch.DrawString(TextureManager.ExtraBigFont, ToMenu , new Vector2((GraphicsDevice.Viewport.Width / 2 - 550) - (TextureManager.ExtraBigFont.MeasureString(ToMenu).X / 2), 800), Color.White);
                        break;
                case Screen.HighScoreScreen:
                        highScoreScreen.Draw(spriteBatch);
                        break;
                case Screen.WriteName:
                        writeName.Draw(spriteBatch);
                        break;
               
                 
                
            }
            //waveManager.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void StartWave2()
        {

            layer2 = new Layer2(this);
            currentScreen = Screen.Layer2;
            layer = null;
            layer3 = null;
            layer4 = null;

        }
        public void StartWave3()
        {

            layer3 = new Layer3(this);
            currentScreen = Screen.Layer3;
            layer = null;
            layer2 = null;
            layer4 = null;

        }
        public void StartWave4()
        {

            layer4 = new Layer4(this);
            currentScreen = Screen.Layer4;
            layer = null;
            layer2 = null;
            layer3 = null;

        }
        public void StartLevelScreen()
        {
            currentScreen = Screen.LevelScreen;
            layer = null;
            layer2 = null;
            layer3 = null;
            layer4 = null;
        }
        public void ToMenu()
        {
            currentScreen = Screen.StartScreen;
            layer = null;
            layer2 = null;
            layer3 = null;
            layer4 = null;
        }
        public void StartGame()
        {
            TextureManager.LoadContent(Content);
            waveManager = new WaveManager(this, 4);
            waveManager.LoadContent(Content);
            layer = new Layer(this);
            currentScreen = Screen.Layer;
            gameOver = null;
            isLoading = false;
           
        }

        public void Loading()
        {
            currentScreen = Screen.Loading;
            isLoading = true;
            waveManager = null;
            gameOver = null;
            
        }
     
        public void EndGame()
        {

            gameOver = new GameOverScreen(this);
            currentScreen = Screen.GameOverScreen;
            //waveManager = null;
            layer = null;
            layer2 = null;
            layer3 = null;
            layer4 = null;
            //SaveHighscore();

        }
        public void WriteName()
        {
            writeName = new WriteName(this);
            currentScreen = Screen.WriteName;
            gameOver = null;
            //waveManager = null;
            layer = null;
            layer2 = null;
            layer3 = null;
            layer4 = null;
            SaveHighscore();
        }
        private const string HighscoreFilename = "HighScore.txt";
        private const string HighscoreFilename2 = "HighScore2.txt";
        // loads Highscore
        public  void loadHighscore()
        {
            StreamReader sr2 = new StreamReader(HighscoreFilename);
            StreamReader sr3 = new StreamReader(HighscoreFilename2);
            string line;
            string line2;
            while (!sr2.EndOfStream)
            {

                line = sr2.ReadLine();
                line2 = sr3.ReadLine();
                scoreList.Add(Convert.ToInt32(line));
                BestPlayerScoreList.Add(Convert.ToInt32(line2));
             
             
             

             

            }

            sr2.Close();
            sr3.Close();
         
        }
        public void SaveHighscore()
        {
            scoreList.Clear();
            BestPlayerScoreList.Clear();
            loadHighscore();
            scoreList.Add(waveManager.UnitedScore);
            scoreList.Sort();
            scoreList.Reverse();


            if (waveManager.Player1.currentScore > waveManager.Player2.currentScore)
            {
                BestPlayerScoreList.Add(waveManager.Player1.currentScore);
            }
            else
            {
                BestPlayerScoreList.Add(waveManager.Player2.currentScore);
            }


            BestPlayerScoreList.Sort();
            BestPlayerScoreList.Reverse();



            StreamWriter sw = new StreamWriter(HighscoreFilename);
            StreamWriter sw2 = new StreamWriter(HighscoreFilename2);
            name = writeName.HighScoreName;
            for (int i = 0; i < scoreList.Count; i++)
            {
               
                string result =Convert.ToString(scoreList[i]);
                sw.WriteLine(result);
                if (scoreList.Count > 10)
                {
                    int remove = Math.Max(0, scoreList.Count - 10);
                    scoreList.RemoveRange(0, remove);
                }
            }
            for (int a = 0; a < BestPlayerScoreList.Count; a++)
            {
                string result2 = Convert.ToString(BestPlayerScoreList[a]);
                sw2.WriteLine(result2);

                if (BestPlayerScoreList.Count > 10)
                {
                    int remove2 = Math.Max(0, BestPlayerScoreList.Count - 10);
                    BestPlayerScoreList.RemoveRange(0, remove2);

                }
            }
            sw.Close();
            sw2.Close();

        }

      

           
        public void HighScore()
        {
            highScoreScreen = new HighScoreScreen(this);
            currentScreen = Screen.HighScoreScreen;
            scoreList.Clear();
            BestPlayerScoreList.Clear();
            loadHighscore();
     
      
           
        }
        public void Credits()
        { currentScreen = Screen.CreditsScreen; }
        
    }
}

