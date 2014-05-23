using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
namespace ProjektArkaden
{
    class Player1 : GameObjects
    {
        KeyboardState keyState;
        KeyboardState oldKeyState;
        Vector2 dir;
        private float timer;
        protected float player1StartHealth;
        protected float player1CurrentHealth;
        public bool p1Dead = false;
        int score;
        public bool IsVisble = true;

        public Vector2 Position
        { get { return pos; } }

        public void SetSplineNr(Vector2 pos)
        {
            this.pos = pos;
        }
        
        public void HandleCollision()
        {
            player1CurrentHealth--;
            pos = new Vector2(100, 500);
        }
        public Player1(Texture2D tex, Vector2 pos, Vector2 dir, int speed, int frame, int nrFrame, int player1Health)
            : base(tex, pos, speed, frame, nrFrame)
        {
            this.player1StartHealth = player1Health;
            this.player1CurrentHealth = player1StartHealth;
            this.speed = speed;
            this.dir = dir;


        }
        public float p1CurrentHealth
        {
            get { return player1CurrentHealth; }
            set { player1CurrentHealth = value; }
        }
        public int currentScore
        {
            get { return score; }
            set { score = value; }
        }

        public override void Update(GameTime gameTime)
        {

            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            oldKeyState = keyState;
            keyState = Keyboard.GetState();
            dir = Vector2.Zero;


            if (keyState.IsKeyDown(Keys.W) && pos.Y > 40)
                dir.Y = -speed;
            if (keyState.IsKeyDown(Keys.S) && pos.Y < 1000)
                dir.Y = speed;
            if (keyState.IsKeyDown(Keys.A) && pos.X > 40)
                dir.X = -speed;
            if (keyState.IsKeyDown(Keys.D) && pos.X < 1880)
                dir.X = speed;

            pos += dir;
            if (player1CurrentHealth <= 0)
            {
                p1Dead = true;
                pos = new Vector2(4000, 4000);
            }
            if (player1CurrentHealth < 0)
                player1CurrentHealth = 0;
            base.Update(gameTime);
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            if (IsVisble)
            base.Draw(spriteBatch);
        }
    }
}

