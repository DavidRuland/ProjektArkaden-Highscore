using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ProjektArkaden
{
    class EnemyBullet : EnemyDrone
    {
        private int damage;
        public bool isActivated;
        Vector2 velocity;
        float scale;


        public Vector2 Posi
        { get { return pos; } }

        public void setPosi(Vector2 pos)
        {
            this.pos = pos;
        }
        public int damageDone
        {
            get { return damage; }
        }

        public EnemyBullet(Texture2D tex, Vector2 pos, int splineNr, Rectangle srcRec, int speed, float rotation, float scale, int frame, int nrFrame, int health, int damage)
            : base(tex, pos, splineNr, srcRec, speed, frame, nrFrame, health)
        {
            this.speed = speed;
            this.rotation = rotation;
            this.scale = scale;
            this.damage = damage;
        }
        public override void Update(GameTime gameTime)
        {
            if (isActivated && rotation == 0)
            {
                pos.X -= speed;
            }
            else if (isActivated)
            {
                pos += velocity;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, pos, srcRec, Color.White, 0, new Vector2(tex.Width / 2, tex.Height / 2), scale, SpriteEffects.None, 1);
        }

        public void Fire(Vector2 pos)
        {
            isActivated = true;
        }

        public void Rotaution(float value)
        {
            rotation = value;
            velocity = Vector2.Transform(new Vector2(0, -speed),
                Matrix.CreateRotationZ(rotation));
        }

    }
}
