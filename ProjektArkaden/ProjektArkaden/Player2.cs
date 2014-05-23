using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace ProjektArkaden
{
    class Player2 : GameObjects
    {
        private KeyboardState keyState;
        private KeyboardState oldKeyState;
        private Vector2 dir;
        protected float player2StartHealth;
        protected float player2CurrentHealth;
        public bool p2Dead = false;
        int score;
        public bool IsVisble = true;

        public Vector2 Position2
        { get { return pos; } }

        public void SetSplineNr2(Vector2 pos)
        {
            this.pos = pos;
        }

        public void HandleCollision()
        {
            player2CurrentHealth--;
            pos = new Vector2(300, 500);
        }

        public Player2(Texture2D tex, Vector2 pos, Vector2 dir, int speed, int frame, int nrFrame, int player2Health)
            : base(tex, pos, speed, frame, nrFrame)
        {
            this.player2StartHealth = player2Health;
            this.player2CurrentHealth = player2StartHealth;
            this.speed = speed;
            this.dir = dir;
        }
        public float p2CurrentHealth
        {
            get { return player2CurrentHealth; }
            set { player2CurrentHealth = value; }
        }
        public int currentScore
        {
            get { return score; }
            set { score = value; }
        }

        public override void Update(GameTime gameTime)
        {
            oldKeyState = keyState;
            keyState = Keyboard.GetState();
            dir = Vector2.Zero;


            if (keyState.IsKeyDown(Keys.Up) && pos.Y > 40)
                dir.Y = -speed;
            if (keyState.IsKeyDown(Keys.Down) && pos.Y < 1000)
                dir.Y = speed;
            if (keyState.IsKeyDown(Keys.Left) && pos.X > 40)
                dir.X = -speed;
            if (keyState.IsKeyDown(Keys.Right) && pos.X < 1880)
                dir.X = speed;

            pos += dir;
            if (player2CurrentHealth <= 0)
            {
                pos = new Vector2(4000, 4000);
                p2Dead = true;
            }
            if (player2CurrentHealth < 0)
                player2CurrentHealth = 0;
            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (IsVisble)
            base.Draw(spriteBatch);
        }
    }
}


