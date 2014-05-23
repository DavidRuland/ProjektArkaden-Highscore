using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ProjektArkaden
{
    class Layer
    {
        private Game1 game;
       
        private float backSpeed;
        private float middleSpeed;
        private float firstSpeed;
        private Vector2 position1;
        private Vector2 position2;
        private Vector2 position3;
        private double beginTimer = 10;
        public Layer(Game1 game)
        {
            this.game = game;
            backSpeed = 0.2f;
            middleSpeed = 0.5f;
            firstSpeed = 1f;
            position1 = position2 = position3 = Vector2.Zero;

           
        }

        public void Update(GameTime gameTime)
        {
            beginTimer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (position3.X < -TextureManager.frontTex3.Width * 3 + 1940) // stanna bilderna när sista bilden är klar
            {
                position1.X -= 0;
                position2.X -= 0;
                position3.X -= 0;
            }
            else
            {
                if (beginTimer <= 0)
                {
                    // rörelse bakrebilen
                    position1.X -= backSpeed;
                    // rita om bild
                    if (position1.X < -TextureManager.backgroundTex.Width)
                        position1.X += TextureManager.backgroundTex.Width;

                    // rörelse mittenbilen
                    position2.X -= middleSpeed;
                    // rita om bild
                    if (position2.X < -TextureManager.middleTex.Width)
                        position2.X += TextureManager.middleTex.Width;

                    // rörelse främrebilen
                    position3.X -= firstSpeed;
                }
            }      
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(TextureManager.backgroundTex, position1, Color.White);
            if (position1.X + TextureManager.backgroundTex.Width < game.GraphicsDevice.Viewport.Width)
                spriteBatch.Draw(TextureManager.backgroundTex, position1 + new Vector2(TextureManager.backgroundTex.Width, 0), Color.White);

            spriteBatch.Draw(TextureManager.middleTex, position2, Color.White);
            if (position2.X + TextureManager.middleTex.Width < game.GraphicsDevice.Viewport.Width)
                spriteBatch.Draw(TextureManager.middleTex, position2 + new Vector2(TextureManager.middleTex.Width, 0), Color.White);
            
            spriteBatch.Draw(TextureManager.frontTex, position3, Color.White);
            if (position3.X + TextureManager.frontTex.Width < game.GraphicsDevice.Viewport.Width)
                spriteBatch.Draw(TextureManager.frontTex2, position3 + new Vector2(TextureManager.frontTex2.Width, 0), Color.White);
            if (position3.X + TextureManager.frontTex2.Width * 2 < game.GraphicsDevice.Viewport.Width)
                spriteBatch.Draw(TextureManager.frontTex3, position3 + new Vector2(TextureManager.frontTex3.Width * 2, 0), Color.White);

        }

    }

}


