using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ProjektArkaden
{
    class EnemyBase : GameObjects
    {
        float texPos;
        int splineNr;
        protected float startHealth;
        protected float currentHealth;
        public bool Dead = false;
        protected float rotation;

        int targetIs;
        
        float radius;
        Player1 targetlol;
        Player2 targetlol2;

        public float Rotaaation
        {   get { return rotation;  }
            set { rotation = value; }}

        public float Radius
        { get { return radius; } }
        public Player1 Target
        { 
            get { return targetlol; }
            set { targetlol = value; }
        }

        public  virtual Vector2 Position
        { get { return pos; } }

        public EnemyBase(Texture2D tex, Vector2 pos, int splineNr, Rectangle srcRec, int speed, int frame, int nrFrame, float health)
            : base(tex, pos, speed, frame, nrFrame)
        {
            this.startHealth = health;
            this.currentHealth = startHealth;
            this.tex = tex;
            this.pos = pos;
            this.splineNr = splineNr;
            radius = 20;
        }

        public bool canHit(Vector2 position)
        {
            return Vector2.Distance(targetlol.pos, position) <= radius;
        }
        public void getClosestPosition(Player1 player1, Player2 player2)
        {
            targetlol = player1;
            targetlol2 = player2;
            float range = radius;

            if (player1 is Player1 && Vector2.Distance(targetlol.pos, pos) < Vector2.Distance(targetlol2.pos, pos))
            {
                range = Vector2.Distance(targetlol.pos, pos);
                targetlol = (Player1)player1;
                targetIs = 1;
            }
            else
            {
                targetlol2 = (Player2)player2;
                targetIs = 2;
            }
        }
        public void hit()
        {

            Vector2 dir = new Vector2(1, 0);                         //Fix

            if (targetIs == 1)
            {
                dir = pos - targetlol.pos + new Vector2(0, 40);
            }
            if (targetIs == 2)
            {
                dir = pos - targetlol2.pos + new Vector2(0, 40);
            }

            dir.Normalize();
            rotation = (float)Math.Atan2(-dir.X, dir.Y);
        }

        public void bossHit()
        {

            Vector2 dir = new Vector2(1, 0);                         //Fix

            if (targetIs == 1)
            {
                dir = pos - targetlol.pos - new Vector2(370, 150);
            }
            if (targetIs == 2)
            {
                dir = pos - targetlol2.pos - new Vector2(370, 150);
            }

            dir.Normalize();
            rotation = (float)Math.Atan2(-dir.X, dir.Y);
        }

        public void bossHitR()
        {

            Vector2 dir = new Vector2(1, 0);                         //Fix

            if (targetIs == 1)
            {
                dir = pos - targetlol.pos - new Vector2(210, 80);
            }
            if (targetIs == 2)
            {
                dir = pos - targetlol2.pos - new Vector2(210, 80);
            }

            dir.Normalize();
            rotation = (float)Math.Atan2(-dir.X, dir.Y);
        }

        public void SetSplineNr(int splineNr)
        {
            this.splineNr = splineNr;
        }
        public int GetSplineNr()
        {
            return splineNr;
        }
        public void SetSpeed(float texPos)
        {
            this.texPos = texPos;
        }
        public float GetSpeed()
        {
            return texPos;
        }
        public float CurrentHealth
        {
            get { return currentHealth; }
            set { currentHealth = value; }
        }

        public override void Update(GameTime gameTime)
        {
            pos = Splineclass.pathArray[splineNr].GetPos(texPos);
            base.Update(gameTime);

            if (currentHealth <= 0)
            {
                Dead = true;
            }

            texPos += speed;
            if (pos.X < -tex.Width / nrFrame / 2)
            {
                Dead = true;
            }
            if (pos.Y < -50 -tex.Height || pos.Y > 1130 + tex.Height)
            {
                Dead = true;
            }

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
