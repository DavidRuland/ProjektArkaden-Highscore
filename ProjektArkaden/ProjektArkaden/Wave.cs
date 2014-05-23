using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ProjektArkaden
{
    class Wave
    {
        private int antalfiender;
        private int nivå;
        private int spawn = 0;
        private float timer = 0;
        private bool hasSpawned;
        Random rnd1, rnd2;
        public List<EnemyBase> enemies = new List<EnemyBase>();
        public List<EnemyBullet> enemyBullets = new List<EnemyBullet>();
        EnemyBullet enemyBullet;
        private float enemyBulletTimer;
        int switchCount = 0;
        int randomNr = 0;
        float fourthLevelDoomTimer = 8.6f;

        EnemyDrone enemy1;
        EnemyRocket rocket1;
        EnemyRobot robot1;
        EnemyBoss boss1;

        public bool NextWave
        {
            get
            {
                return enemies.Count == 0 && spawn == antalfiender;
            }
        }
        public int RoundNumber
        {
            get { return nivå; }
        }

        public Wave(int nivå, int antalfiender, Texture2D eTex, Texture2D rocket, Texture2D robot)
        {
            this.nivå = nivå;
            this.antalfiender = antalfiender;
            rnd1 = new Random();
            rnd2 = new Random();

        }
        private void AddEnemies()
        {
            // /*EnemyDrone*/ enemy1 = new EnemyDrone(TextureManager.enemyTex, Vector2.Zero, rnd1.Next(0, 8), new Rectangle(0, 0, TextureManager.enemyTex.Width, TextureManager.enemyTex.Height), 12, 0, 3, 4);
            // /*EnemyRocket*/ rocket1 = new EnemyRocket(TextureManager.rocketTex, new Vector2(2100, 800), rnd1.Next(2, 8), new Rectangle(0, 0, TextureManager.rocketTex.Width, TextureManager.rocketTex.Height), 15, 0, 3, 7);
            // /*EnemyRobot*/ robot1 = new EnemyRobot(TextureManager.robotTex, new Vector2(2100, 800), rnd1.Next(2, 8), new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 2, 0, 5, 7);
            //enemies.Add(robot1);
            //enemies.Add(enemy1);
            //enemies.Add(rocket1);

            switch (WaveManager.masterSwitch)
            {

                #region Level one
                case 0:
                    switchCount++;
                    timer = 8;
                    if (switchCount == 4)
                    {
                        WaveManager.masterSwitch++;
                        switchCount = 0;
                        timer = 8f;
                    }

                    break;

                case 1:
                    rocket1 = new EnemyRocket(TextureManager.rocketTex, new Vector2(2100, 800), switchCount + 3, new Rectangle(0, 0, TextureManager.rocketTex.Width, TextureManager.rocketTex.Height), 8, 0, 3, 6);
                    enemies.Add(rocket1);
                    rocket1 = new EnemyRocket(TextureManager.rocketTex, new Vector2(2100, 800), 8 - switchCount, new Rectangle(0, 0, TextureManager.rocketTex.Width, TextureManager.rocketTex.Height), 8, 0, 3, 6);
                    enemies.Add(rocket1);
                    switchCount++;
                    timer = 9;
                    if (switchCount == 6)
                    {
                        WaveManager.masterSwitch++;
                        switchCount = 0;
                        timer = 7.6f;
                    }
                    break;

                case 2:
                    enemy1 = new EnemyDrone(TextureManager.enemyTex, new Vector2(2100, 800), 0, new Rectangle(0, 0, TextureManager.enemyTex.Width, TextureManager.enemyTex.Height), 5, 0, 3, 4);
                    enemies.Add(enemy1);
                    enemy1 = new EnemyDrone(TextureManager.enemyTex, new Vector2(2100, 800), 1, new Rectangle(0, 0, TextureManager.enemyTex.Width, TextureManager.enemyTex.Height), 5, 0, 3, 4);
                    enemies.Add(enemy1);
                    switchCount++;
                    timer = 9.2f;
                    if (switchCount == 3)
                    {
                        WaveManager.masterSwitch++;
                        switchCount = 0;
                        timer = 5f;
                    }
                    break;

                case 3:
                    enemy1 = new EnemyDrone(TextureManager.enemyTex, new Vector2(2100, 800), 10, new Rectangle(0, 0, TextureManager.enemyTex.Width, TextureManager.enemyTex.Height), 5, 0, 3, 4);
                    enemies.Add(enemy1);
                    enemy1 = new EnemyDrone(TextureManager.enemyTex, new Vector2(2100, 800), 11, new Rectangle(0, 0, TextureManager.enemyTex.Width, TextureManager.enemyTex.Height), 5, 0, 3, 4);
                    enemies.Add(enemy1);
                    switchCount++;
                    timer = 9f;
                    if (switchCount == 6)
                    {
                        WaveManager.masterSwitch++;
                        switchCount = 0;
                    }
                    break;

                case 4:
                    enemy1 = new EnemyDrone(TextureManager.enemyTex, new Vector2(2100, 800), 3, new Rectangle(0, 0, TextureManager.enemyTex.Width, TextureManager.enemyTex.Height), 5, 0, 3, 4);
                    enemies.Add(enemy1);
                    enemy1 = new EnemyDrone(TextureManager.enemyTex, new Vector2(2100, 800), 9, new Rectangle(0, 0, TextureManager.enemyTex.Width, TextureManager.enemyTex.Height), 5, 0, 3, 4);
                    enemies.Add(enemy1);
                    enemy1 = new EnemyDrone(TextureManager.enemyTex, new Vector2(2100, 800), 8, new Rectangle(0, 0, TextureManager.enemyTex.Width, TextureManager.enemyTex.Height), 5, 0, 3, 4);
                    enemies.Add(enemy1);
                    switchCount++;
                    timer = 9.4f;
                    if (switchCount == 3)
                    {
                        WaveManager.masterSwitch++;
                        switchCount = 0;
                        timer = 5f;
                    }
                    break;

                case 5:
                    rocket1 = new EnemyRocket(TextureManager.rocketTex, new Vector2(2100, 800), rnd2.Next(3, 10), new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 8, 0, 3, 6);
                    enemies.Add(rocket1);
                    switchCount++;
                    timer = 9.75f;
                    if (switchCount == 85)
                    {
                        WaveManager.masterSwitch++;
                        switchCount = 0;
                        timer = 7f;
                    }
                    break;

                case 6:
                    rocket1 = new EnemyRocket(TextureManager.rocketTex, new Vector2(2100, 800), 8 - switchCount, new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 8, 0, 3, 6);
                    enemies.Add(rocket1);
                    rocket1 = new EnemyRocket(TextureManager.rocketTex, new Vector2(2100, 800), switchCount + 3, new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 8, 0, 3, 6);
                    enemies.Add(rocket1);
                    rocket1 = new EnemyRocket(TextureManager.rocketTex, new Vector2(2100, 800), 9, new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 8, 0, 3, 7);
                    enemies.Add(rocket1);
                    switchCount++;
                    timer = 9f;
                    if (switchCount == 6)
                    {
                        WaveManager.masterSwitch++;
                        switchCount = 0;

                    }
                    break;

                case 7:
                    rocket1 = new EnemyRocket(TextureManager.rocketTex, new Vector2(2100, 800), 8 - switchCount, new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 8, 0, 3, 6);
                    enemies.Add(rocket1);
                    rocket1 = new EnemyRocket(TextureManager.rocketTex, new Vector2(2100, 800), switchCount + 3, new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 8, 0, 3, 6);
                    enemies.Add(rocket1);
                    rocket1 = new EnemyRocket(TextureManager.rocketTex, new Vector2(2100, 800), 9, new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 8, 0, 3, 7);
                    enemies.Add(rocket1);
                    switchCount++;
                    timer = 9f;
                    if (switchCount == 6)
                    {
                        WaveManager.masterSwitch++;
                        switchCount = 0;

                    }
                    break;

                case 8:
                    rocket1 = new EnemyRocket(TextureManager.rocketTex, new Vector2(2100, 800), 8 - switchCount, new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 8, 0, 3, 6);
                    enemies.Add(rocket1);
                    rocket1 = new EnemyRocket(TextureManager.rocketTex, new Vector2(2100, 800), switchCount + 3, new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 8, 0, 3, 6);
                    enemies.Add(rocket1);
                    rocket1 = new EnemyRocket(TextureManager.rocketTex, new Vector2(2100, 800), 9, new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 8, 0, 3, 7);
                    enemies.Add(rocket1);
                    switchCount++;
                    timer = 9f;
                    if (switchCount == 6)
                    {
                        WaveManager.masterSwitch++;
                        switchCount = 0;
                        timer = 5f;
                    }
                    break;

                case 9:
                    enemy1 = new EnemyDrone(TextureManager.enemyTex, new Vector2(2100, 800), 12, new Rectangle(0, 0, TextureManager.enemyTex.Width, TextureManager.enemyTex.Height), 5, 0, 3, 4);
                    enemies.Add(enemy1);
                    enemy1 = new EnemyDrone(TextureManager.enemyTex, new Vector2(2100, 800), 13, new Rectangle(0, 0, TextureManager.enemyTex.Width, TextureManager.enemyTex.Height), 5, 0, 3, 4);
                    enemies.Add(enemy1);
                    switchCount++;
                    timer = 9f;
                    if (switchCount == 16)
                    {
                        WaveManager.masterSwitch++;
                        switchCount = 0;
                        timer = 7f;
                    }
                    break;

                case 10:
                    enemy1 = new EnemyDrone(TextureManager.enemyTex, new Vector2(2100, 800), 0, new Rectangle(0, 0, TextureManager.enemyTex.Width, TextureManager.enemyTex.Height), 5, 0, 3, 4);
                    enemies.Add(enemy1);
                    enemy1 = new EnemyDrone(TextureManager.enemyTex, new Vector2(2100, 800), 1, new Rectangle(0, 0, TextureManager.enemyTex.Width, TextureManager.enemyTex.Height), 5, 0, 3, 4);
                    enemies.Add(enemy1);
                    rocket1 = new EnemyRocket(TextureManager.rocketTex, new Vector2(2100, 800), 5, new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 8, 0, 3, 7);
                    enemies.Add(rocket1);
                    rocket1 = new EnemyRocket(TextureManager.rocketTex, new Vector2(2100, 800), 9, new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 8, 0, 3, 7);
                    enemies.Add(rocket1);
                    rocket1 = new EnemyRocket(TextureManager.rocketTex, new Vector2(2100, 800), 6, new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 8, 0, 3, 7);
                    enemies.Add(rocket1);
                    switchCount++;
                    timer = 8.5f;
                    if (switchCount == 4)
                    {
                        WaveManager.masterSwitch++;
                        switchCount = 0;
                        timer = 5f;
                    }
                    break;

                case 11:
                    enemy1 = new EnemyDrone(TextureManager.enemyTex, new Vector2(2100, 800), 0, new Rectangle(0, 0, TextureManager.enemyTex.Width, TextureManager.enemyTex.Height), 5, 0, 3, 4);
                    enemies.Add(enemy1);
                    enemy1 = new EnemyDrone(TextureManager.enemyTex, new Vector2(2100, 800), 1, new Rectangle(0, 0, TextureManager.enemyTex.Width, TextureManager.enemyTex.Height), 5, 0, 3, 4);
                    enemies.Add(enemy1);
                    enemy1 = new EnemyDrone(TextureManager.enemyTex, new Vector2(2100, 800), 2, new Rectangle(0, 0, TextureManager.enemyTex.Width, TextureManager.enemyTex.Height), 5, 0, 3, 4);
                    enemies.Add(enemy1);
                    switchCount++;
                    timer = 8.5f;
                    if (switchCount == 14)
                    {
                        WaveManager.masterSwitch++;
                        switchCount = 0;
                        timer = 5f;
                    }
                    break;

                case 12:
                    enemy1 = new EnemyDrone(TextureManager.enemyTex, new Vector2(2100, 800), 3 + switchCount, new Rectangle(0, 0, TextureManager.enemyTex.Width, TextureManager.enemyTex.Height), 5, 0, 3, 4);
                    enemies.Add(enemy1);
                    switchCount++;
                    timer = 9.5f;
                    if (switchCount == 6)
                    {
                        WaveManager.masterSwitch++;
                        switchCount = 0;
                        timer = 9.5f;
                    }
                    break;

                case 13:
                    enemy1 = new EnemyDrone(TextureManager.enemyTex, new Vector2(2100, 800), 8 - switchCount, new Rectangle(0, 0, TextureManager.enemyTex.Width, TextureManager.enemyTex.Height), 5, 0, 3, 4);
                    enemies.Add(enemy1);
                    switchCount++;
                    timer = 9.5f;
                    if (switchCount == 6)
                    {
                        WaveManager.masterSwitch++;
                        switchCount = 0;
                        timer = 9.5f;
                    }
                    break;

                case 14:
                    enemy1 = new EnemyDrone(TextureManager.enemyTex, new Vector2(2100, 800), 3 + switchCount, new Rectangle(0, 0, TextureManager.enemyTex.Width, TextureManager.enemyTex.Height), 5, 0, 3, 4);
                    enemies.Add(enemy1);
                    switchCount++;
                    timer = 9.5f;
                    if (switchCount == 6)
                    {
                        WaveManager.masterSwitch++;
                        switchCount = 0;
                        timer = 9.5f;
                    }
                    break;

                case 15:
                    enemy1 = new EnemyDrone(TextureManager.enemyTex, new Vector2(2100, 800), 8 - switchCount, new Rectangle(0, 0, TextureManager.enemyTex.Width, TextureManager.enemyTex.Height), 5, 0, 3, 4);
                    enemies.Add(enemy1);
                    switchCount++;
                    timer = 9.5f;
                    if (switchCount == 6)
                    {
                        WaveManager.masterSwitch++;
                        switchCount = 0;
                        timer = 9.5f;
                    }
                    break;

                case 16:
                    enemy1 = new EnemyDrone(TextureManager.enemyTex, new Vector2(2100, 800), 3 + switchCount, new Rectangle(0, 0, TextureManager.enemyTex.Width, TextureManager.enemyTex.Height), 5, 0, 3, 4);
                    enemies.Add(enemy1);
                    switchCount++;
                    timer = 9.5f;
                    if (switchCount == 6)
                    {
                        WaveManager.masterSwitch++;
                        switchCount = 0;
                        timer = 5f;
                    }
                    break;

                case 17:
                    enemy1 = new EnemyDrone(TextureManager.enemyTex, new Vector2(2100, 800), 10 + (switchCount % 2), new Rectangle(0, 0, TextureManager.enemyTex.Width, TextureManager.enemyTex.Height), 5, 0, 3, 4);
                    enemies.Add(enemy1);
                    switchCount++;
                    timer = 9.5f;
                    if (switchCount == 20)
                    {
                        WaveManager.masterSwitch++;
                        switchCount = 0;
                        timer = 5f;
                    }
                    break;

                case 18:
                    robot1 = new EnemyRobot(TextureManager.miniBaws, new Vector2(2100, 800), 9, new Rectangle(0, 0, TextureManager.miniBaws.Width, TextureManager.miniBaws.Height), 1, 0, 5, 132);
                    enemies.Add(robot1);
                    switchCount++;
                    timer = 8.5f;
                    if (switchCount == 1)
                    {
                        WaveManager.masterSwitch++;
                        switchCount = 0;
                        timer = 0.1f;
                    }
                    break;

                #endregion

                #region Level two

                case 19:
                    enemy1 = new EnemyDrone(TextureManager.enemyTex, new Vector2(2100, 800), 3 + (switchCount % 2), new Rectangle(0, 0, TextureManager.enemyTex.Width, TextureManager.enemyTex.Height), 5, 0, 3, 4);
                    enemies.Add(enemy1);
                    switchCount++;
                    timer = 9.5f;
                    if (switchCount == 10)
                    {
                        WaveManager.masterSwitch++;
                        switchCount = 0;
                        timer = 8.5f;
                    }
                    break;

                case 20:
                    enemy1 = new EnemyDrone(TextureManager.enemyTex, new Vector2(2100, 800), 7 + (switchCount % 2), new Rectangle(0, 0, TextureManager.enemyTex.Width, TextureManager.enemyTex.Height), 5, 0, 3, 4);
                    enemies.Add(enemy1);
                    switchCount++;
                    timer = 9.5f;
                    if (switchCount == 10)
                    {
                        WaveManager.masterSwitch++;
                        switchCount = 0;
                        timer = 5f;
                    }
                    break;

                case 21:
                    rocket1 = new EnemyRocket(TextureManager.rocketTex, new Vector2(2100, 800), 3, new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 8, 0, 3, 6);
                    enemies.Add(rocket1);
                    rocket1 = new EnemyRocket(TextureManager.rocketTex, new Vector2(2100, 800), 4, new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 8, 0, 3, 6);
                    enemies.Add(rocket1);
                    rocket1 = new EnemyRocket(TextureManager.rocketTex, new Vector2(2100, 800), 5, new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 8, 0, 3, 6);
                    enemies.Add(rocket1);
                    rocket1 = new EnemyRocket(TextureManager.rocketTex, new Vector2(2100, 800), 9, new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 8, 0, 3, 6);
                    enemies.Add(rocket1);
                    rocket1 = new EnemyRocket(TextureManager.rocketTex, new Vector2(2100, 800), 6, new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 8, 0, 3, 6);
                    enemies.Add(rocket1);
                    rocket1 = new EnemyRocket(TextureManager.rocketTex, new Vector2(2100, 800), 7, new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 8, 0, 3, 6);
                    enemies.Add(rocket1);
                    rocket1 = new EnemyRocket(TextureManager.rocketTex, new Vector2(2100, 800), 8, new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 8, 0, 3, 6);
                    enemies.Add(rocket1);
                    switchCount++;
                    timer = 8;
                    if (switchCount == 2)
                    {
                        WaveManager.masterSwitch++;
                        switchCount = 0;
                        timer = 7.6f;
                    }
                    break;

                case 22:
                    robot1 = new EnemyRobot(TextureManager.robotTex, new Vector2(2100, 800), 9, new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 2, 0, 5, 7);
                    enemies.Add(robot1);
                    switchCount++;
                    timer = 8.5f;
                    if (switchCount == 2)
                    {
                        WaveManager.masterSwitch++;
                        switchCount = 0;
                        timer = 8.5f;
                    }
                    break;

                case 23:
                    robot1 = new EnemyRobot(TextureManager.robotTex, new Vector2(2100, 800), 5, new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 2, 0, 5, 7);
                    enemies.Add(robot1);
                    robot1 = new EnemyRobot(TextureManager.robotTex, new Vector2(2100, 800), 6, new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 2, 0, 5, 7);
                    enemies.Add(robot1);
                    switchCount++;
                    timer = 8.5f;
                    if (switchCount == 2)
                    {
                        WaveManager.masterSwitch++;
                        switchCount = 0;
                        timer = 8.5f;
                    }
                    break;

                case 24:
                    robot1 = new EnemyRobot(TextureManager.robotTex, new Vector2(2100, 800), 4, new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 2, 0, 5, 7);
                    enemies.Add(robot1);
                    robot1 = new EnemyRobot(TextureManager.robotTex, new Vector2(2100, 800), 7, new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 2, 0, 5, 7);
                    enemies.Add(robot1);
                    switchCount++;
                    timer = 8.5f;
                    if (switchCount == 2)
                    {
                        WaveManager.masterSwitch++;
                        switchCount = 0;
                        timer = 8.5f;
                    }
                    break;

                case 25:
                    robot1 = new EnemyRobot(TextureManager.robotTex, new Vector2(2100, 800), 3, new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 2, 0, 5, 7);
                    enemies.Add(robot1);
                    robot1 = new EnemyRobot(TextureManager.robotTex, new Vector2(2100, 800), 8, new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 2, 0, 5, 7);
                    enemies.Add(robot1);
                    switchCount++;
                    timer = 8.5f;
                    if (switchCount == 2)
                    {
                        WaveManager.masterSwitch++;
                        switchCount = 0;
                        timer = 5f;
                    }
                    break;

                case 26:
                    rocket1 = new EnemyRocket(TextureManager.rocketTex, new Vector2(2100, 800), rnd2.Next(3, 10), new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 10, 0, 3, 6);
                    enemies.Add(rocket1);
                    switchCount++;
                    timer = 9.75f;
                    if (switchCount == 101)
                    {
                        WaveManager.masterSwitch++;
                        switchCount = 0;
                        timer = 5f;
                    }
                    break;

                case 27:
                    robot1 = new EnemyRobot(TextureManager.robotTex, new Vector2(2100, 800), 12, new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 2, 0, 5, 7);
                    enemies.Add(robot1);
                    robot1 = new EnemyRobot(TextureManager.robotTex, new Vector2(2100, 800), 13, new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 2, 0, 5, 7);
                    enemies.Add(robot1);
                    switchCount++;
                    timer = 9f;
                    if (switchCount == 26)
                    {
                        WaveManager.masterSwitch++;
                        switchCount = 0;
                        timer = 5f;
                    }
                    break;

                case 28:
                    if (switchCount % 2 == 0)
                    {
                        enemy1 = new EnemyDrone(TextureManager.enemyTex, new Vector2(2100, 800), 2, new Rectangle(0, 0, TextureManager.enemyTex.Width, TextureManager.enemyTex.Height), 4, 0, 3, 4);
                        enemies.Add(enemy1);
                    }
                    else
                    {
                        robot1 = new EnemyRobot(TextureManager.robotTex, new Vector2(2100, 800), 2, new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 2, 0, 5, 7);
                        enemies.Add(robot1);
                    }
                    switchCount++;
                    timer = 8.5f;
                    if (switchCount == 30)
                    {
                        WaveManager.masterSwitch++;
                        switchCount = 0;
                        timer = 0.1f;
                    }
                    break;

                case 29:
                    rocket1 = new EnemyRocket(TextureManager.rocketTex, new Vector2(2100, 800), 9, new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 10, 0, 3, 6);
                    enemies.Add(rocket1);
                    robot1 = new EnemyRobot(TextureManager.robotTex, new Vector2(2100, 800), 10 + (switchCount % 2), new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 3, 0, 5, 7);
                    enemies.Add(robot1);
                    switchCount++;
                    timer = 9f;
                    if (switchCount == 30)
                    {
                        WaveManager.masterSwitch++;
                        switchCount = 0;
                        timer = 5f;
                    }
                    break;

                case 30:
                    robot1 = new EnemyRobot(TextureManager.robotTex, new Vector2(2100, 800), rnd2.Next(3, 10), new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 3, 0, 5, 7);
                    enemies.Add(robot1);
                    robot1 = new EnemyRobot(TextureManager.robotTex, new Vector2(2100, 800), rnd2.Next(3, 10), new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 3, 0, 5, 7);
                    enemies.Add(robot1);
                    switchCount++;
                    timer = 8.5f;
                    if (switchCount == 28)
                    {
                        WaveManager.masterSwitch++;
                        switchCount = 0;
                        timer = 7f;
                    }
                    break;

                #endregion

                #region Level three

                case 31:
                    randomNr = rnd2.Next(0, 4);

                    if (randomNr == 0)
                    {
                        robot1 = new EnemyRobot(TextureManager.robotTex, new Vector2(2100, 800), rnd2.Next(3, 10), new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 2, 0, 5, 7);
                        enemies.Add(robot1);
                    }
                    else if (randomNr == 1)
                    {
                        enemy1 = new EnemyDrone(TextureManager.enemyTex, new Vector2(2100, 800), rnd2.Next(3, 10), new Rectangle(0, 0, TextureManager.enemyTex.Width, TextureManager.enemyTex.Height), 5, 0, 3, 4);
                        enemies.Add(enemy1);
                    }
                    else if (randomNr == 2)
                    {
                        rocket1 = new EnemyRocket(TextureManager.rocketTex, new Vector2(2100, 800), rnd2.Next(3, 10), new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 8, 0, 3, 6);
                        enemies.Add(rocket1);
                    }
                    switchCount++;
                    timer = 9.59f;
                    if (switchCount == 279)
                    {
                        WaveManager.masterSwitch++;
                        switchCount = 0;
                        timer = 0.1f;
                    }
                    break;

                case 32:
                    boss1 = new EnemyBoss(TextureManager.bossTex, new Vector2(10, 1600), 15, new Rectangle(0, 0, TextureManager.bossTex.Width, TextureManager.bossTex.Height), 1, 0, 5, 600);
                    enemies.Add(boss1);
                    switchCount++;
                    timer = 0.1f;
                    if (switchCount == 1)
                    {
                        WaveManager.masterSwitch++;
                        switchCount = 0;
                        timer = 0.1f;
                    }
                    break;

                #endregion

                #region Level four

                case 33:
                    randomNr = rnd2.Next(0, 3);
                    if (randomNr == 0)
                    {
                        robot1 = new EnemyRobot(TextureManager.robotTex, new Vector2(2100, 800), rnd2.Next(0, 15), new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 2, 0, 5, 7);
                        enemies.Add(robot1);
                    }
                    else if (randomNr == 1)
                    {
                        enemy1 = new EnemyDrone(TextureManager.enemyTex, new Vector2(2100, 800), rnd2.Next(0, 15), new Rectangle(0, 0, TextureManager.enemyTex.Width, TextureManager.enemyTex.Height), 5, 0, 3, 4);
                        enemies.Add(enemy1);
                    }
                    else if (randomNr == 2)
                    {
                        rocket1 = new EnemyRocket(TextureManager.rocketTex, new Vector2(2100, 800), rnd2.Next(0, 15), new Rectangle(0, 0, TextureManager.robotTex.Width, TextureManager.robotTex.Height), 8, 0, 3, 6);
                        enemies.Add(rocket1);
                    }
                    fourthLevelDoomTimer += 0.015f;
                    //switchCount++;
                    timer = fourthLevelDoomTimer;
                    if (timer >= 10)
                    {
                        timer = 9.82f;
                    }
                    break;

                #endregion

            }

            spawn++;
        }
        public void Start()
        {
            hasSpawned = true;
        }
        public void Update(GameTime gameTime)
        {
            enemyBulletTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (spawn == antalfiender)
                hasSpawned = false;
            if (hasSpawned)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (timer >= 10)
                    AddEnemies();
            }

            if (enemyBulletTimer >= 1.4)
            {
                foreach (EnemyBase e in enemies)
                {
                    if (e is EnemyRobot)
                    {
                        if (e.Target != null)
                        {
                            e.hit();
                            enemyBullet = new EnemyBullet(TextureManager.ebulletTex2, e.Position + new Vector2(0, 40), 0, new Rectangle(0, 0, TextureManager.ebulletTex2.Width * 6, TextureManager.ebulletTex2.Height * 6), 11, e.Rotaaation, 1.4f, 0, 1, 1, 1);
                            enemyBullet.Fire(e.Position);
                            enemyBullets.Add(enemyBullet);
                            enemyBulletTimer = 0;
                        }
                        //if (e.Target != null && !e.canHit(e.Target.pos))            // If-sats konstig
                        //{
                        //    e.Target = null;
                        //    enemyBulletTimer = 0;
                        //}
                        //if (e.Target != null && Vector2.Distance(enemyBullet.pos, e.Target.pos) < 120)
                        //{
                        //    e.Target.p1CurrentHealth -= enemyBullet.damageDone;
                        //}
                    }
                    if (e is EnemyDrone)
                    {
                        enemyBullet = new EnemyBullet(TextureManager.ebulletTex, e.Position + new Vector2(0, 40), 0, new Rectangle(0, 0, TextureManager.ebulletTex.Width, TextureManager.ebulletTex.Height), 11, 0, 1.6f, 0, 1, 1, 1);
                        enemyBullet.Fire(e.Position);
                        enemyBullets.Add(enemyBullet);
                        enemyBulletTimer = 0;
                    }
                }
            }

            // boss shotfunction
            if (enemyBulletTimer >= 1.0)
            {
                foreach (EnemyBase e in enemies)
                {
                    if (e is EnemyBoss)
                    {
                        // redshot
                        enemyBullet = new EnemyBullet(TextureManager.ebulletTex, e.Position - new Vector2(420, 318), 0, new Rectangle(0, 0, TextureManager.ebulletTex.Width, TextureManager.ebulletTex.Height), 11, 0, 1.6f, 0, 1, 1, 1);
                        enemyBullet.Fire(e.Position);
                        enemyBullets.Add(enemyBullet);
                        enemyBulletTimer = 0;

                        // pos seekershot1
                        if (e.Target != null)
                        {
                            e.bossHit();
                            enemyBullet = new EnemyBullet(TextureManager.ebulletTex2, e.Position - new Vector2(370, 200), 0, new Rectangle(0, 0, TextureManager.ebulletTex2.Width * 6, TextureManager.ebulletTex2.Height * 6), 11, e.Rotaaation, 1.4f, 0, 1, 1, 1);
                            enemyBullet.Fire(e.Position);
                            enemyBullets.Add(enemyBullet);
                            enemyBulletTimer = 0;
                        }
                        // pos seekershot2
                        if (e.Target != null)
                        {
                            e.bossHit();
                            enemyBullet = new EnemyBullet(TextureManager.ebulletTex2, e.Position - new Vector2(370, 150), 0, new Rectangle(0, 0, TextureManager.ebulletTex2.Width * 6, TextureManager.ebulletTex2.Height * 6), 11, e.Rotaaation, 1.4f, 0, 1, 1, 1);
                            enemyBullet.Fire(e.Position);
                            enemyBullets.Add(enemyBullet);
                            enemyBulletTimer = 0;
                        }
                        // missilshot
                        if (e.Target != null)
                        {
                            e.bossHitR();
                            enemyBullet = new EnemyBullet(TextureManager.miniRocketsTex, e.Position - new Vector2(210, 80), 0, new Rectangle(0, 0, TextureManager.miniRocketsTex.Width, TextureManager.miniRocketsTex.Height), 5, e.Rotaaation, 1, 0, 3, 1, 1);
                            enemyBullet.Fire(e.Position);
                            enemyBullets.Add(enemyBullet);
                            enemyBulletTimer = 0;
                        }
                        //if (e.Target != null && !e.canHit(e.Target.pos))            // If-sats konstig
                        //{
                        //    e.Target = null;
                        //    enemyBulletTimer = 0;
                        //}
                        //if (e.Target != null && Vector2.Distance(enemyBullet.pos, e.Target.pos) < 120)
                        //{
                        //    e.Target.p1CurrentHealth -= enemyBullet.damageDone;
                        //}
                    }
                }
            }

            for (int i = 0; i < enemyBullets.Count; i++)
            {
                enemyBullet = enemyBullets[i];
                enemyBullet.Rotaution(enemyBullet.Rotaaation);
                enemyBullet.Update(gameTime);
                if (enemyBullet.Posi.X >= Game1.width)
                {
                    enemyBullets.Remove(enemyBullet);
                }
            }



            for (int i = 0; i < enemies.Count; i++)
            {
                EnemyBase enemy1 = enemies[i];
                enemy1.Update(gameTime);


                if (enemy1.Dead)
                {
                    enemies.Remove(enemy1);
                }
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (EnemyBase en in enemies)
            {

                en.Draw(spriteBatch);
            }
            foreach (EnemyBullet eB in enemyBullets)
            {
                eB.Draw(spriteBatch);
            }

            //foreach (EnemyBoss boss in enemies)
            //{
            if (boss1 != null)
            {
                boss1.Draw(spriteBatch);
                // Draw the health bar normally.
                Rectangle healthRectangle = new Rectangle(460,
                                                         20,
                                                         1000,
                                                         40);

                spriteBatch.Draw(TextureManager.healthTexture, healthRectangle, Color.Gold);

                float healthPercentage = boss1.HealthPercentage;
                float visibleWidth = (float)TextureManager.healthTexture.Width * healthPercentage;

                healthRectangle = new Rectangle(460,
                                               20,
                                               (int)(visibleWidth),
                                               40);

                spriteBatch.Draw(TextureManager.healthTexture, healthRectangle, Color.Red);
            }


        }
    }
}
