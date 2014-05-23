using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ProjektArkaden
{
    class EnemyDrone : EnemyBase
    {

        public override Vector2 Position
        { get { return pos; } }

        public EnemyDrone(Texture2D tex, Vector2 pos, int splineNr, Rectangle srcRec, int speed, int frame, int nrFrame,int health)
            : base(tex, pos, splineNr, srcRec, speed, frame, nrFrame,health)
        {

        }
        public override void Update(GameTime gameTime)
        {
         
            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {

            base.Draw(spriteBatch);
        }
    }
}
