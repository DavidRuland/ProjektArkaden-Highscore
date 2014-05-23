using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace ProjektArkaden
{
    class WaveManager
    {
        private int antalNivåer;
        private float timeSinceLastWave;
        private bool done = false;
        private Queue<Wave> waves = new Queue<Wave>();
        Game1 game;
        Splineclass spline;
        Player1 player1;
        List<Bullet1> bullets1 = new List<Bullet1>();
        List<Bullet2> bullets2 = new List<Bullet2>();
        Bullet1 bullet1;
        Bullet2 bullet2;
        private float bulletTimer2;
        private float bulletTimer;
        KeyboardState ks;
        KeyboardState oldKS;
        Player2 player2;
        public static int masterSwitch;
        bool player2Active = false;
        private bool ha;
        private bool ho;
        private bool hi;
        bool powerUpActive = false;
        bool powerUpActive2 = false;
        public bool respawnProtection;
        public bool respawnProtection2;
        public double respawnProtectionTimer;
        public double respawnProtectionTimer2;
        public int UnitedScore;
        public double player2Timer = 10;
        public double powerupTimer, powerupTimer2;
        public List<PowerUp> powerUps = new List<PowerUp>();
        PowerUp powerUp;
        private bool powerup = false;
        private bool powerup2 = false;
        PowerUp lifeUp;
        public Wave CurrentWave
        {
            get { return waves.Peek(); }

        }
        public List<EnemyBase> enemy2
        {
            get { return CurrentWave.enemies; }

        }
        public List<EnemyBullet> enemyBullets2
        {
            get { return CurrentWave.enemyBullets; }

        }

        public int Round
        {
            get { return CurrentWave.RoundNumber + 1; }
        }

        public void LoadContent(ContentManager contentManager)
        {
            spline = new Splineclass();
            spline.LoadContent(contentManager);
        }
        public Player1 Player1
        {
            get { return player1; }
        }
        public Player2 Player2
        {
            get { return player2; }
        }


        public WaveManager(Game1 game, int antalNivåer)
        {

            this.game = game;
            this.antalNivåer = antalNivåer;
            player1 = new Player1(TextureManager.playerTex, new Vector2(300, 1000), new Vector2(0, 0), 10, 0, 3, 3);
            player2 = new Player2(TextureManager.player2Tex, new Vector2(5000, 5000), new Vector2(0, 0), 10, 0, 5, 3);
            powerupTimer = powerupTimer2 = 8;

            for (int i = 0; i < antalNivåer; i++)
            {
                int antalFiender = 5;
                int number = (i * 7) + 42;
                if (number == 63)
                    number = 300;

                //int antalFiender = 120;

                Wave wave1 = new Wave(i, antalFiender * number, TextureManager.enemyTex, TextureManager.rocketTex, TextureManager.robotTex);
                waves.Enqueue(wave1);


            }

            StartNewWave();

        }



        private void StartNewWave()
        {
            if (waves.Count > 0)
            {
                waves.Peek().Start();
                timeSinceLastWave = 0;
                done = false;
            }

        }


        public void Update(GameTime gameTime)
        {
            if (KeyMouseReaders.KeyPressed(Keys.O) && player2Timer >= 0)
            {
                player2.pos = new Vector2(200, 1000);
                player2Active = true;
            }
            if (KeyMouseReaders.KeyPressed(Keys.F) && powerup)
            {
                powerUpActive = true;
                powerup = false;
            }
            if (KeyMouseReaders.KeyPressed(Keys.K) && powerup2)
            {
                powerUpActive2 = true;
                powerup2 = false;
            }
            player2Timer -= gameTime.ElapsedGameTime.TotalSeconds;

            UnitedScore = player2.currentScore + player1.currentScore;
            player1.IsVisble = true;
            player2.IsVisble = true;
            if (player1.p1Dead == false)
            {
                player1.Update(gameTime);
            }

            if (player2Active && player2.p2Dead == false)
            {
                player2.Update(gameTime);
            }

            for (int i = 0; i < CurrentWave.enemies.Count; i++)
            {
                if (player1.CirkelCollition(CurrentWave.enemies[i]))
                {
                    if (!respawnProtection)
                    {
                        respawnProtection = true;
                        player1.HandleCollision();
                    }


                }
                if (player2.CirkelCollition(CurrentWave.enemies[i]))
                {
                    if (!respawnProtection2)
                    {
                        respawnProtection2 = true;
                        player2.HandleCollision();
                    }
                }
            }

            oldKS = ks;
            ks = Keyboard.GetState();
            bulletTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            bulletTimer2 += (float)gameTime.ElapsedGameTime.TotalSeconds;

            for (int i = 0; i < powerUps.Count; i++)
            {
                powerUps[i].Update(gameTime);

                if (player1.CirkelCollition(powerUps[i]))
                {
                    if (powerUps[i] == lifeUp)
                    {
                        if (player1.p1CurrentHealth != 3)
                        player1.p1CurrentHealth++;

                        player1.currentScore += 200;
                        powerUps.Remove(powerUps[i]);
                        break;
                    }
                    else
                    {
                    powerup = true;
                    powerUps.Remove(powerUps[i]);
                    player1.currentScore += 200;
                    break;
                    }
                }
                if (player2.CirkelCollition(powerUps[i]) && player2Active)
                {
                    if (powerUps[i] == lifeUp)
                    {
                        if (player2.p2CurrentHealth != 3)
                            player2.p2CurrentHealth++;

                        player2.currentScore += 200;
                        powerUps.Remove(powerUps[i]);
                        break;
                    }
                    else
                    {
                        powerup2 = true;
                        powerUps.Remove(powerUps[i]);
                        player2.currentScore += 200;
                        break;
                    }

                }
                if (powerUps[i].pos.X > 1940)
                {
                    powerUps.Remove(powerUps[i]);
                }


            }

            if (powerUpActive)
            {
                powerupTimer -= gameTime.ElapsedGameTime.TotalSeconds;
                if (powerupTimer <= 0)
                {
                    powerupTimer = 8;
                    powerUpActive = false;
                }

            }
            if (powerUpActive2)
            {
                powerupTimer2 -= gameTime.ElapsedGameTime.TotalSeconds;
                if (powerupTimer2 <= 0)
                {
                    powerupTimer2 = 8;
                    powerUpActive2 = false;
                }

            }
            if (ks.IsKeyDown(Keys.Space) && bulletTimer >= 0.17f && player1.p1Dead == false)
            {
                bullet1 = new Bullet1(TextureManager.bulletTex, player1.pos, new Vector2(0, 0), 1, 1, 1, 1, 3, 0);
                bullet1.Fire(player1.pos);
                bullets1.Add(bullet1);

                if (powerUpActive == true)
                {
                    bullet1 = new Bullet1(TextureManager.bulletTex, player1.pos, new Vector2(0, 0), 1, 1, 1, 1, 3, 1);
                    bullet1.Fire(player1.pos);
                    bullets1.Add(bullet1);
                    bullet1 = new Bullet1(TextureManager.bulletTex, player1.pos, new Vector2(0, 0), 1, 1, 1, 1, 3, 2);
                    bullet1.Fire(player1.pos);
                    bullets1.Add(bullet1);
                }
                bulletTimer = 0;
            }
            if (ks.IsKeyDown(Keys.L) && bulletTimer2 >= 0.17f && player2.p2Dead == false)
            {
                bullet2 = new Bullet2(TextureManager.bulletTex, player2.pos, new Vector2(0, 0), 1, 1, 1, 1, 3, 0);
                bullet2.Fire(player2.pos);
                bullets2.Add(bullet2);
                bulletTimer2 = 0;

                if (powerUpActive2 == true)
                {
                    bullet2 = new Bullet2(TextureManager.bulletTex, player2.pos, new Vector2(0, 0), 1, 1, 1, 1, 3, 1);
                    bullet2.Fire(player2.pos);
                    bullets2.Add(bullet2);
                    bullet2 = new Bullet2(TextureManager.bulletTex, player2.pos, new Vector2(0, 0), 1, 1, 1, 1, 3, 2);
                    bullet2.Fire(player2.pos);
                    bullets2.Add(bullet2);
                }
            }


            for (int i = 0; i < bullets1.Count; i++)
            {
                bullet1 = bullets1[i];
                bullet1.Update(gameTime);
                if (bullet1.Posi.X >= Game1.width)
                {
                    bullets1.Remove(bullet1);
                }
            }
            for (int i = 0; i < bullets2.Count; i++)
            {
                bullet2 = bullets2[i];
                bullet2.Update(gameTime);
                if (bullet2.Posi.X >= Game1.width)
                {
                    bullets2.Remove(bullet2);
                }
            }



            for (int i = 0; i < CurrentWave.enemies.Count; i++)
            {
                for (int w = 0; w < bullets1.Count; w++)
                {
                    EnemyBase enemy = CurrentWave.enemies[i];
                    if (enemy.CirkelCollition(bullets1[w]))
                    {
                        enemy.CurrentHealth -= bullet1.damageDone;
                        if (enemy is EnemyBoss)
                        {
                            player1.currentScore += 10;
                        }
                        

                        if (enemy.CurrentHealth == 0)
                        {
                            if (enemy is EnemyDrone)
                                player1.currentScore += 100;
                            if (enemy is EnemyRocket)
                                player1.currentScore += 120;
                            if (enemy is EnemyRobot)
                                player1.currentScore += 150;

                            Random rand = new Random();
                            int upValue = rand.Next(0, 15);
                            if (upValue == 0)
                            {
                                powerUp = new PowerUp(TextureManager.PowerUpTex, enemy.pos, 1, 1, 12);
                                powerUps.Add(powerUp);
                            }

                            int lifeValue = rand.Next(0, 30);
                            if (lifeValue == 0)
                            {
                                lifeUp = new PowerUp(TextureManager.lifeUpTex, enemy.pos, 3, 1, 1);
                                powerUps.Add(lifeUp);
                            }

                        }
                        bullets1.Remove(bullets1[w]);
                    }
                }
                for (int w = 0; w < bullets2.Count; w++)
                {
                    EnemyBase enemy = CurrentWave.enemies[i];
                    if (enemy.CirkelCollition(bullets2[w]))
                    {
                        if (enemy is EnemyBoss && player2Active)
                            player2.currentScore += 10;

                        enemy.CurrentHealth -= bullet2.damageDone;
                        if (enemy.CurrentHealth == 0)
                        {
                            if (enemy is EnemyDrone)
                                player2.currentScore += 100;
                            if (enemy is EnemyRocket)
                                player2.currentScore += 120;
                            if (enemy is EnemyRobot)
                                player2.currentScore += 150;

                            Random rand = new Random();
                            int upValue = rand.Next(0, 15);
                            if (upValue == 0)
                            {
                                powerUp = new PowerUp(TextureManager.PowerUpTex, enemy.pos, 2, 1, 12);
                                powerUps.Add(powerUp);
                            }

                            int lifeValue = rand.Next(0, 30);
                            if (lifeValue == 0)
                            {
                                lifeUp = new PowerUp(TextureManager.lifeUpTex, enemy.pos, 3, 1, 1);
                                powerUps.Add(lifeUp);
                            }
                        }
                        bullets2.Remove(bullets2[w]);
                    }
                }
            }

            if (respawnProtection)
            {
                respawnProtectionTimer += gameTime.ElapsedGameTime.TotalSeconds;
                if (respawnProtection && respawnProtectionTimer >= 2)
                {
                    respawnProtection = false;
                    respawnProtectionTimer = 0;
                }
            }
            if (respawnProtection2)
            {
                respawnProtectionTimer2 += gameTime.ElapsedGameTime.TotalSeconds;
                if (respawnProtection2 && respawnProtectionTimer2 >= 2)
                {
                    respawnProtection2 = false;
                    respawnProtectionTimer2 = 0;
                }
            }

            for (int w = 0; w < CurrentWave.enemyBullets.Count; w++)
            {
                if (player1.CirkelCollition(enemyBullets2[w]))
                {
                    if (!respawnProtection)
                    {
                        player1.pos = new Vector2(100, 1000);
                        player1.p1CurrentHealth--;
                        respawnProtection = true;
                    }

                    enemyBullets2.Remove(enemyBullets2[w]);
                }
            }

            for (int x = 0; x < CurrentWave.enemyBullets.Count; x++)
            {
                if (player2.CirkelCollition(enemyBullets2[x]))
                {
                    if (!respawnProtection2)
                    {
                        player2.pos = new Vector2(300, 300);
                        player2.p2CurrentHealth--;
                        respawnProtection2 = true;
                    }
                    enemyBullets2.Remove(enemyBullets2[x]);
                }
            }

            // robot get P-pos
            foreach (EnemyRobot en in CurrentWave.enemies.OfType<EnemyRobot>())
            {
                en.getClosestPosition(player1, player2);
                en.Update(gameTime);
            }

            // boss get P-pos
            foreach (EnemyBoss en in CurrentWave.enemies.OfType<EnemyBoss>())
            {
                en.getClosestPosition(player1, player2);
                en.Update(gameTime);
            }

            if (player1.p1CurrentHealth <= 0)
            {
                if (player2.p2CurrentHealth <= 0 || !player2Active)
                {
                    game.EndGame();
                    masterSwitch = 0;
                }


            }

            CurrentWave.Update(gameTime);

            if (CurrentWave.NextWave)
            {
                done = true;
            }
            if (done)
            {
                timeSinceLastWave += (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (timeSinceLastWave > 2f)
            {
                waves.Dequeue();

                StartNewWave();

            }


            if (Round == 2)
            {
                if (!ha)
                {
                    game.StartLevelScreen();
                    player1.IsVisble = false;
                    player2.IsVisble = false;
                    ha = true;
                    player1.pos = new Vector2(100, 100);
                    if (player2Active)
                    player2.pos = new Vector2(100, 200);
                }



            }
            if (Round == 3)
            {
                if (!ho)
                {
                    game.StartLevelScreen();
                    player1.IsVisble = false;
                    player2.IsVisble = false;
                    player1.pos = new Vector2(100, 100);
                    if (player2Active)
                    player2.pos = new Vector2(100, 200);
                    ho = true;
                }
            }
            if (Round == 4)
            {
                if (!hi)
                {
                    game.StartLevelScreen();
                    player1.IsVisble = false;
                    player2.IsVisble = false;
                    player1.pos = new Vector2(100, 100);
                    if (player2Active)
                    player2.pos = new Vector2(100, 200);
                    hi = true;
                }
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            if (player1.p1Dead == false)
            {
                player1.Draw(spriteBatch);
            }

            if (player2Active && player2.p2Dead == false)
            {
                player2.Draw(spriteBatch);
            }
            CurrentWave.Draw(spriteBatch);
            foreach (Bullet1 b in bullets1)
            {
                b.Draw(spriteBatch);
            }
            foreach (Bullet2 b in bullets2)
            {
                b.Draw(spriteBatch);
            }

            #region Spelare Liv och PowerUp
            if (player1.p1CurrentHealth == 3)
            {
                spriteBatch.Draw(TextureManager.hjartTex, new Vector2(10, 10), Color.White);
                spriteBatch.Draw(TextureManager.hjartTex, new Vector2(50, 10), Color.White);
                spriteBatch.Draw(TextureManager.hjartTex, new Vector2(90, 10), Color.White);
            }
            if (player1.p1CurrentHealth == 2)
            {
                spriteBatch.Draw(TextureManager.hjartTex, new Vector2(10, 10), Color.White);
                spriteBatch.Draw(TextureManager.hjartTex, new Vector2(50, 10), Color.White);
            }
            if (player1.p1CurrentHealth == 1)
            {
                spriteBatch.Draw(TextureManager.hjartTex, new Vector2(10, 10), Color.White);
            }

            if (player2.p2CurrentHealth == 3 && player2Active)
            {
                spriteBatch.Draw(TextureManager.hjartTex, new Vector2(1850, 10), Color.White);
                spriteBatch.Draw(TextureManager.hjartTex, new Vector2(1810, 10), Color.White);
                spriteBatch.Draw(TextureManager.hjartTex, new Vector2(1770, 10), Color.White);
            }
            if (player2.p2CurrentHealth == 2 && player2Active)
            {
                spriteBatch.Draw(TextureManager.hjartTex, new Vector2(1850, 10), Color.White);
                spriteBatch.Draw(TextureManager.hjartTex, new Vector2(1810, 10), Color.White);
            }
            if (player2.p2CurrentHealth == 1 && player2Active)
            {
                spriteBatch.Draw(TextureManager.hjartTex, new Vector2(1850, 10), Color.White);
            }
            if (powerup && !player1.p1Dead)
                spriteBatch.Draw(TextureManager.PowerUpTex2, new Vector2(150, 10), Color.White);
            if (powerup2 && !player2.p2Dead)
                spriteBatch.Draw(TextureManager.PowerUpTex2, new Vector2(1730, 10), Color.White);
            #endregion

            //spline.Draw(spriteBatch);

            spriteBatch.DrawString(TextureManager.font, "Enemies: " + CurrentWave.enemies.Count(), new Vector2(0, 60), Color.Red, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            spriteBatch.DrawString(TextureManager.font, "Level: " + Round, new Vector2(0, 70), Color.Red, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            spriteBatch.DrawString(TextureManager.ScoreFont, "Player1 Score: " + player1.currentScore, new Vector2(0, 80), Color.Green, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            if (player2Active)
                spriteBatch.DrawString(TextureManager.ScoreFont, "Player2 Score: " + player2.currentScore, new Vector2(1500, 80), Color.Red, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            string unitedScore = "United Score: ";
            spriteBatch.DrawString(TextureManager.ScoreFont, unitedScore + UnitedScore, new Vector2((game.Window.ClientBounds.Width / 2) -
                    (TextureManager.ScoreFont.MeasureString(unitedScore).X / 2), 80), Color.Blue, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
            foreach (PowerUp pUp in powerUps)
            {
                pUp.Draw(spriteBatch);
            }

            if (player2Timer >= 0)
            {
                string begin = "Get ready to begin";
                spriteBatch.DrawString(TextureManager.ExtraBigFont, begin, new Vector2((game.Window.ClientBounds.Width / 2) -
                    (TextureManager.ExtraBigFont.MeasureString(begin).X / 2), (game.Window.ClientBounds.Height / 2) + 50), Color.Sienna);
                string time = "Time to begin: ";
                spriteBatch.DrawString(TextureManager.ExtraBigFont, time + (int)player2Timer, new Vector2((game.Window.ClientBounds.Width / 2) -
                                        (TextureManager.ExtraBigFont.MeasureString(time).X / 2), (game.Window.ClientBounds.Height / 2) + 150), Color.Sienna);
                if (!player2Active && player2Timer >= 0)
                {
                    string activate = "Press p2 to activate player 2";

                    spriteBatch.DrawString(TextureManager.ExtraBigFont, activate, new Vector2((game.Window.ClientBounds.Width / 2) -
                        (TextureManager.ExtraBigFont.MeasureString(activate).X / 2), (game.Window.ClientBounds.Height / 2) + 100), Color.Sienna);
                }
            }

        }
    }
}
