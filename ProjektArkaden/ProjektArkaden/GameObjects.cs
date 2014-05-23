using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace ProjektArkaden
{
    class GameObjects
    {
        protected Texture2D tex;
        public Vector2 pos;
        protected int speed;
        protected Rectangle srcRec;
        protected int frame;
        protected int nrFrame;
        private double frameIntervall = 300, frameTimer = 300;
       public float radius;
       
        public GameObjects(Texture2D tex, Vector2 pos, int speed, int frame, int nrFrame)
        {
            this.tex = tex;
            this.pos = pos;
            this.speed = speed;
            this.frame = frame;
            this.nrFrame = nrFrame;
            this.srcRec = new Rectangle(0, 0, tex.Width / nrFrame, tex.Height);
            this.radius = tex.Width / nrFrame / 6;
                        
        }

        public virtual bool CirkelCollition(GameObjects gameObjects)
        {
            return Vector2.Distance(pos, gameObjects.pos) < (2 * radius + 2 * gameObjects.radius);
        }
        //public void HandleCollision()
        //{
        //    pos = new Vector2(50, 400);
        //}

        public virtual void Update(GameTime gameTime){
             frameTimer -= gameTime.ElapsedGameTime.TotalMilliseconds;

            if (frameTimer <= 0)
            {
                frame++;
                srcRec.X = (frame % nrFrame) * tex.Width / nrFrame;
                frameTimer = frameIntervall;

            }
        }
        
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, pos, srcRec, Color.White, 0f, new Vector2(tex.Width / nrFrame / 2, tex.Height / 2), 1f, SpriteEffects.None, 0f);
        }
    }
}

