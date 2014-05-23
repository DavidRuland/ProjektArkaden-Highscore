using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace ProjektArkaden
{
    class TextureManager
    {
        //Level 1
        public static Texture2D backgroundTex { get; private set; }
        public static Texture2D middleTex { get; private set; }
        public static Texture2D frontTex { get; private set; }
        public static Texture2D frontTex2 { get; private set; }
        public static Texture2D frontTex3 { get; private set; }

        //Level 2
        public static Texture2D baackgroundTex { get; private set; }
        public static Texture2D miiddleTex { get; private set; }
        public static Texture2D frrontTex { get; private set; }

        //Level 3
        public static Texture2D baaackgroundTex { get; private set; }
        public static Texture2D miiiddleTex { get; private set; }
        public static Texture2D frrrontTex { get; private set; }

        //Level4
        public static Texture2D baaaackgroundTex { get; private set; }
        public static Texture2D miiiiddleTex { get; private set; }
        public static Texture2D frrrrontTex { get; private set; }

        //Misc
        public static Texture2D playerTex { get; private set; }
        public static Texture2D player2Tex { get; private set; }
        public static Texture2D enemyTex { get; private set; }
        public static Texture2D rocketTex { get; private set; }
        public static Texture2D robotTex { get; private set; }
        public static Texture2D bulletTex { get; private set; }
        public static Texture2D ebulletTex { get; private set; }
        public static Texture2D ebulletTex2 { get; private set; }
        public static Texture2D miniRocketsTex { get; private set; }
        public static Texture2D hjartTex { get; private set; }
        public static SpriteFont loading { get; private set; }
        public static Texture2D miniBaws { get; private set; }
        public static Texture2D gameOverTex { get; private set; }
        public static Texture2D LoadingScreenTex { get; private set; }
        public static Texture2D CreditsScreenTex { get; private set; }
        public static Texture2D PowerUpTex { get; private set; }
        public static Texture2D PowerUpTex2 { get; private set; }
        public static Texture2D lifeUpTex { get; private set; }
        public static Texture2D bossTex { get; private set; }
        public static Texture2D healthTexture { get; private set; }
        
        //Fonts
        public static SpriteFont font { get; private set; }
        public static SpriteFont BigTexFont { get; private set; }
        public static SpriteFont ExtraBigFont { get; private set; }
        public static SpriteFont ScoreFont { get; private set; }

        //Knappar
        public static Texture2D startButton { get; private set; }
        public static Texture2D exitButton { get; private set; }
        public static Texture2D highScoreButton { get; private set; }
        public static Texture2D creditsButton { get; private set; }

        public static void LoadContent(ContentManager Content)
        {
            //Level 1
            backgroundTex = Content.Load<Texture2D>(@"Images/Background_images/Bakrebakgrund1080");
            middleTex = Content.Load<Texture2D>(@"Images/Background_images/Mittenbakgrund1080");
            frontTex = Content.Load<Texture2D>(@"Images/Background_images/Främrebakgrund1080");
            frontTex2 = Content.Load<Texture2D>(@"Images/Background_images/2Främrebakgrund1080");
            frontTex3 = Content.Load<Texture2D>(@"Images/Background_images/3Främrebakgrund1080");

            //Level 2
            baackgroundTex = Content.Load<Texture2D>(@"Images/Background_images/Nivå2Bakre");
            miiddleTex = Content.Load<Texture2D>(@"Images/Background_images/Nivå2Mitten");
            frrontTex = Content.Load<Texture2D>(@"Images/Background_images/Nivå2Främre");

            //Level 3
            baaackgroundTex = Content.Load<Texture2D>(@"Images/Background_images/Nivå3Bakre");
            miiiddleTex = Content.Load<Texture2D>(@"Images/Background_images/Nivå3Mitten");
            frrrontTex = Content.Load<Texture2D>(@"Images/Background_images/Nivå3Främre");

            //Level4
            baaaackgroundTex = Content.Load<Texture2D>(@"Images/Background_images/Nivå4Bakre");
            miiiiddleTex = Content.Load<Texture2D>(@"Images/Background_images/Nivå4Mitten");
            frrrrontTex = Content.Load<Texture2D>(@"Images/Background_images/Nivå4Främre");

            //Misc
            playerTex = Content.Load<Texture2D>(@"Images/Objects/Sp1Spritesheet");
            player2Tex = Content.Load<Texture2D>(@"Images/Objects/Sp2Spritesheet");
            enemyTex = Content.Load<Texture2D>(@"Images/Objects/EnemyUavSpritesheet");
            rocketTex = Content.Load<Texture2D>(@"Images/Objects/EnemyRocketSheet");
            robotTex = Content.Load<Texture2D>(@"Images/Objects/EnemyRobotSheet");
            //bulletTex = Content.Load<Texture2D>(@"Images/Objects/shot");
            bulletTex = Content.Load<Texture2D>(@"Images/Objects/Lazer");
            ebulletTex = Content.Load<Texture2D>(@"Images/Objects/Eshot");
            ebulletTex2 = Content.Load<Texture2D>(@"Images/Objects/bullet");
            miniRocketsTex = Content.Load<Texture2D>(@"Images/Objects/miniRockets");
            hjartTex = Content.Load<Texture2D>(@"Images/Objects/hjarta");
            gameOverTex = Content.Load<Texture2D>(@"Images/Background_images/GameOver");
            LoadingScreenTex = Content.Load<Texture2D>(@"Images/Background_images/backscreen");
            CreditsScreenTex = Content.Load<Texture2D>(@"Images/Background_images/Credits");
            miniBaws = Content.Load<Texture2D>(@"Images/Objects/RobotBoss");
            PowerUpTex = Content.Load<Texture2D>(@"Images/Objects/PupSheet");
            PowerUpTex2 = Content.Load<Texture2D>(@"Images/Objects/pUp");
            lifeUpTex = Content.Load<Texture2D>(@"Images/Objects/lifeUp");
            bossTex = Content.Load<Texture2D>(@"Images/Objects/BossSpriteSheet");
            healthTexture = Content.Load<Texture2D>(@"Images/Objects/healthBar");

            //Fonts
            font = Content.Load<SpriteFont>(@"Fots/SpriteFont1");
            BigTexFont = Content.Load<SpriteFont>(@"Fots/BigTexFont");
            ExtraBigFont = Content.Load<SpriteFont>(@"Fots/ExtraBigFont");
            ScoreFont = Content.Load<SpriteFont>(@"Fots/ScoreFont");

            //Knappar
            startButton = Content.Load<Texture2D>(@"Images/Objects/StartKnapp");
            exitButton = Content.Load<Texture2D>(@"Images/Objects/ExitKnapp");
            highScoreButton = Content.Load<Texture2D>(@"Images/Objects/HighScoreKnapp");
            creditsButton = Content.Load<Texture2D>(@"Images/Objects/CreditsKnapp");

        }
    }
}
