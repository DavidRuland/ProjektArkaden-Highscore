using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ProjektArkaden
{
    class EnemyBoss : EnemyBase
    {
        float healthPrecentage;
        public EnemyBoss(Texture2D tex, Vector2 pos, int splineNr, Rectangle srcRec, int speed, int frame, int nrFrame, int health)
            : base(tex, pos, splineNr, srcRec, speed, frame, nrFrame, health)
        {
            this.radius = tex.Width / nrFrame / 4;
        }

        // The % of health that an enemy has left
        public float HealthPercentage
        {

            get { return healthPrecentage; }
            
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            healthPrecentage = currentHealth / startHealth;
            Console.WriteLine(HealthPercentage);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {

            base.Draw(spriteBatch);
        }
    }
}
