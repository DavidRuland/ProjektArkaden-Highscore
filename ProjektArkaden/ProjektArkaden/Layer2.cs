using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ProjektArkaden
{
   class Layer2
    {

        private Game1 game;
        private float backSpeed;
        private float middleSpeed;
        private float firstSpeed;
        private Vector2 position1;
        private Vector2 position2;
        private Vector2 position3;
        public Layer2(Game1 game)
        {
            this.game = game;
            backSpeed = 0.2f;
            middleSpeed = 0.5f;
            firstSpeed = 1f;
            position1 = position2 = position3 = Vector2.Zero;

           
        }

        public void Update()
        {
          
            if (position3.X < -TextureManager.frrontTex.Width * 3 + 1940) // stanna bilderna när sista bilden är klar
            {
                position1.X -= 0;
                position2.X -= 0;
                position3.X -= 0;
            }
            else
            {
                // rörelse bakrebilen
                position1.X -= backSpeed;
                // rita om bild
                if (position1.X < -TextureManager.baackgroundTex.Width)
                    position1.X += TextureManager.baackgroundTex.Width;

                // rörelse mittenbilen
                position2.X -= middleSpeed;
                // rita om bild
                if (position2.X < -TextureManager.miiddleTex.Width)
                    position2.X += TextureManager.miiddleTex.Width;

                // rörelse främrebilen
                position3.X -= firstSpeed;
            }      
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(TextureManager.baackgroundTex, position1, Color.White);
            if (position1.X + TextureManager.baackgroundTex.Width < game.GraphicsDevice.Viewport.Width)
                spriteBatch.Draw(TextureManager.baackgroundTex, position1 + new Vector2(TextureManager.baackgroundTex.Width, 0), Color.White);

            spriteBatch.Draw(TextureManager.miiddleTex, position2, Color.White);
            if (position2.X + TextureManager.miiddleTex.Width < game.GraphicsDevice.Viewport.Width)
                spriteBatch.Draw(TextureManager.miiddleTex, position2 + new Vector2(TextureManager.miiddleTex.Width, 0), Color.White);
            
            spriteBatch.Draw(TextureManager.frrontTex, position3, Color.White);
            if (position3.X + TextureManager.frrontTex.Width < game.GraphicsDevice.Viewport.Width)
                spriteBatch.Draw(TextureManager.frrontTex, position3 + new Vector2(TextureManager.frrontTex.Width, 0), Color.White);
           
        }

    }

}



   
