using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ProjektArkaden
{
    class PowerUp : GameObjects
    {
        float timer;
        public Vector2 dir;
        public PowerUp(Texture2D tex, Vector2 pos, int speed, int frame, int nrFrame)
            : base(tex, pos, speed, frame, nrFrame)
        {
            dir = new Vector2(1, 0);
        }
        public override void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer >= 3)
                pos += dir * speed;

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

    }
}
