using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ProjektArkaden
{
    class HighScoreScreen
    {
      
        private Game1 game;
        private string text;
        
        public HighScoreScreen(Game1 game)
        {

            this.game = game;
         
          
        
         
        }
       
   
     
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(TextureManager.LoadingScreenTex, new Rectangle(0, 0, 1920, 1080), Color.White);
            string highscore = "HIGHSCORE";
            spriteBatch.DrawString(TextureManager.ExtraBigFont, highscore, new Vector2((game.Window.ClientBounds.Width / 2) -
                        (TextureManager.ExtraBigFont.MeasureString(highscore).X / 2), 100), Color.White);

      
            for (int i = 0; i < Game1.scoreList.Count; i++)
            {
                spriteBatch.DrawString(TextureManager.BigTexFont,  game.name + Game1.scoreList[i] + "\n", new Vector2((game.Window.ClientBounds.Width / 2) -
                            (TextureManager.BigTexFont.MeasureString(game.name + Game1.scoreList[i] + "\n").X / 2), 200 + 50 * i), Color.Red);

            }
            for (int a = 0; a < Game1.BestPlayerScoreList.Count; a++)
            {
                spriteBatch.DrawString(TextureManager.BigTexFont, "" + Game1.BestPlayerScoreList[a], new Vector2((1200) -
                            (TextureManager.BigTexFont.MeasureString("" + Game1.BestPlayerScoreList[a]).X / 2), 200 + 50 * a), Color.Red);
            }
            string toMenu = "Press x to return to menu";
            spriteBatch.DrawString(TextureManager.ExtraBigFont, toMenu, new Vector2((game.Window.ClientBounds.Width / 2) -
                        (TextureManager.ExtraBigFont.MeasureString(toMenu).X / 2), 800), Color.White);
            

        }
    }
}
