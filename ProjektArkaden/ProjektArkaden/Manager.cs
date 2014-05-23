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

namespace ProjektArkaden
{
    class Manager
    {

        Splineclass spline;


        public void LoadContent(ContentManager contentManager)
        {

            spline = new Splineclass();
            spline.LoadContent(contentManager);



        }
        public void Update(GameTime gameTime)
        {




            spline.Update(gameTime);


        }
        public void Draw(SpriteBatch spriteBatch)
        {

            spline.Draw(spriteBatch);
        }
    }
}
