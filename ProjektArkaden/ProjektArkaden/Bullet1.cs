using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ProjektArkaden
{
    class Bullet1 : Player1
    {
        private int damage;
        public bool isActivated;
        int splitshot;
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

        public Bullet1(Texture2D tex, Vector2 pos, Vector2 dir, int speed, int frame, int nrFrame, int damage, int player1Health, int splitshot)
            : base(tex, pos, dir, speed, frame, nrFrame, player1Health)
        {
            this.speed = 15;
            this.damage = damage;
            this.splitshot = splitshot;
        }
        public override void Update(GameTime gameTime)
        {
            if (isActivated && splitshot == 0)
            {
                pos.X += speed;
            }
            else if (isActivated && splitshot == 1)
            {
                pos.X += speed;
                pos.Y += 2f;
            }
            else if (isActivated && splitshot == 2)
            {
                pos.X += speed;
                pos.Y -= 2f;
            }
        }



        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(tex, pos, srcRec, Color.White, 0, new Vector2(tex.Width / nrFrame / 2 - 40, tex.Height / 2 + 20), 1, SpriteEffects.None, 1);
        }

        public void Fire(Vector2 pos)
        {
            isActivated = true;

        }
    }
}
