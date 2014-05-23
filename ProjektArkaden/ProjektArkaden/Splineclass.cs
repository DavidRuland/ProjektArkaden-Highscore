using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;
using Spline;

namespace ProjektArkaden
{
    public class Splineclass
    {
        GraphicsDeviceManager graphics;
        public static SimplePath path1, path2, path3, path4, path5, path6, path7, path8, path9, path10, path11, path12, path13, path14, path15, path16;
        float texPos1;
        List<SimplePath> pathList;
        public static SimplePath[] pathArray;


        public void LoadContent(ContentManager Content)
        {
            graphics = Game1.graphics;
            pathList = new List<SimplePath>();
            path1 = new SimplePath(graphics.GraphicsDevice);
            path1.generateDefaultPath();
            pathList.Add(path1);
            path2 = new SimplePath(graphics.GraphicsDevice);
            path2.generateDefaultPath();
            pathList.Add(path2);
            path3 = new SimplePath(graphics.GraphicsDevice);
            path3.generateDefaultPath();
            pathList.Add(path3);
            path4 = new SimplePath(graphics.GraphicsDevice);
            path4.generateDefaultPath();
            pathList.Add(path4);
            path5 = new SimplePath(graphics.GraphicsDevice);
            path5.generateDefaultPath();
            pathList.Add(path5);
            path6 = new SimplePath(graphics.GraphicsDevice);
            path6.generateDefaultPath();
            pathList.Add(path6);
            path7 = new SimplePath(graphics.GraphicsDevice);
            path7.generateDefaultPath();
            pathList.Add(path7);
            path8 = new SimplePath(graphics.GraphicsDevice);
            path8.generateDefaultPath();
            pathList.Add(path8);
            path9 = new SimplePath(graphics.GraphicsDevice);
            path9.generateDefaultPath();
            pathList.Add(path9); path10 = new SimplePath(graphics.GraphicsDevice);
            path10.generateDefaultPath();
            pathList.Add(path10);
            path11 = new SimplePath(graphics.GraphicsDevice);
            path11.generateDefaultPath();
            pathList.Add(path11);
            path12 = new SimplePath(graphics.GraphicsDevice);
            path12.generateDefaultPath();
            pathList.Add(path12);
            path13 = new SimplePath(graphics.GraphicsDevice);
            path13.generateDefaultPath();
            pathList.Add(path13);
            path14 = new SimplePath(graphics.GraphicsDevice);
            path14.generateDefaultPath();
            pathList.Add(path14);
            path15 = new SimplePath(graphics.GraphicsDevice);
            path15.generateDefaultPath();
            pathList.Add(path15);
            path16 = new SimplePath(graphics.GraphicsDevice);
            path16.generateDefaultPath();
            pathList.Add(path16);

            pathArray = new SimplePath[16];
            for (int i = 0; i < pathArray.Length; i++)
            {
                pathArray[i] = new SimplePath(graphics.GraphicsDevice);
                pathArray[i].generateDefaultPath();
                path1 = pathArray[0];
                path2 = pathArray[1];
                path3 = pathArray[2];
                path4 = pathArray[3];
                path5 = pathArray[4];
                path6 = pathArray[5];
                path7 = pathArray[6];
                path8 = pathArray[7];
                path9 = pathArray[8];
                path10 = pathArray[9];
                path11 = pathArray[10];
                path12 = pathArray[11];
                path13 = pathArray[12];
                path14 = pathArray[13];
                path15 = pathArray[14];
                path16 = pathArray[15];
            }


            //path1
            #region
            texPos1 = path1.beginT;
            path1.Clean();
            path1.AddPoint(new Vector2(1960, 0));
            path1.AddPoint(new Vector2(1700, 200));
            path1.AddPoint(new Vector2(1500, 100));
            path1.AddPoint(new Vector2(1200, 400));
            path1.AddPoint(new Vector2(900, 300));
            path1.AddPoint(new Vector2(600, 300));
            path1.AddPoint(new Vector2(300, 350));
            path1.AddPoint(new Vector2(100, 300));
            path1.AddPoint(new Vector2(0, 350));
            #endregion

            //path2
            #region
            texPos1 = path2.beginT;
            path2.Clean();
            path2.AddPoint(new Vector2(1960, 1080));
            path2.AddPoint(new Vector2(1700, 1080 - 200));
            path2.AddPoint(new Vector2(1500, 1080 - 100));
            path2.AddPoint(new Vector2(1200, 1080 - 400));
            path2.AddPoint(new Vector2(900, 1080 - 300));
            path2.AddPoint(new Vector2(600, 1080 - 300));
            path2.AddPoint(new Vector2(300, 1080 - 350));
            path2.AddPoint(new Vector2(100, 1080 - 300));
            path2.AddPoint(new Vector2(0, 1080 - 350));
            #endregion

            //path3
            #region
            texPos1 = path3.beginT;
            path3.Clean();
            path3.AddPoint(new Vector2(1960, 450));
            path3.AddPoint(new Vector2(1500, 880));
            path3.AddPoint(new Vector2(1150, 200));
            path3.AddPoint(new Vector2(800, 780));
            path3.AddPoint(new Vector2(500, 400));
            path3.AddPoint(new Vector2(250, 600));
            path3.AddPoint(new Vector2(0, 540));
            #endregion

            //path4
            #region
            texPos1 = path4.beginT;
            path4.Clean();
            path4.AddPoint(new Vector2(1960, 150));
            path4.AddPoint(new Vector2(1000, 100));
            path4.AddPoint(new Vector2(0, 100));
            #endregion

            //path5
            #region
            texPos1 = path5.beginT;
            path5.Clean();
            path5.AddPoint(new Vector2(1960, 300));
            path5.AddPoint(new Vector2(1000, 250));
            path5.AddPoint(new Vector2(0, 250));
            #endregion

            //path6
            #region
            texPos1 = path6.beginT;
            path6.Clean();
            path6.AddPoint(new Vector2(1960, 400));
            path6.AddPoint(new Vector2(1000, 370));
            path6.AddPoint(new Vector2(0, 400));
            #endregion

            //path7
            #region
            texPos1 = path7.beginT;
            path7.Clean();
            path7.AddPoint(new Vector2(1960, 1080 - 400));
            path7.AddPoint(new Vector2(1000, 1080 - 370));
            path7.AddPoint(new Vector2(0, 1080 - 400));
            #endregion

            //path8
            #region
            texPos1 = path8.beginT;
            path8.Clean();
            path8.AddPoint(new Vector2(1960, 1080 - 300));
            path8.AddPoint(new Vector2(1000, 1080 - 250));
            path8.AddPoint(new Vector2(0, 1080 - 250));
            #endregion

            //path9
            #region
            texPos1 = path9.beginT;
            path9.Clean();
            path9.AddPoint(new Vector2(1960, 1080 - 150));
            path9.AddPoint(new Vector2(1000, 1080 - 100));
            path9.AddPoint(new Vector2(0, 1080 - 100));
            #endregion

            //path10
            #region
            texPos1 = path10.beginT;
            path10.Clean();
            path10.AddPoint(new Vector2(1960, 520));
            path10.AddPoint(new Vector2(1000, 542));
            path10.AddPoint(new Vector2(0, 520));
            #endregion

            //path11
            #region
            texPos1 = path11.beginT;
            path11.Clean();
            path11.AddPoint(new Vector2(1400, -50));
            path11.AddPoint(new Vector2(1080, 540));
            path11.AddPoint(new Vector2(0, 900));
            #endregion

            //path12
            #region
            texPos1 = path12.beginT;
            path12.Clean();
            path12.AddPoint(new Vector2(1400, 1130));
            path12.AddPoint(new Vector2(1080, 540));
            path12.AddPoint(new Vector2(0, 180));
            #endregion

            //path13
            #region
            texPos1 = path13.beginT;
            path13.Clean();
            path13.AddPoint(new Vector2(1000, -50));
            path13.AddPoint(new Vector2(900, 540));
            path13.AddPoint(new Vector2(1000, 1080));
            #endregion

            //path14
            #region
            texPos1 = path14.beginT;
            path14.Clean();
            path14.AddPoint(new Vector2(1160, 1130));
            path14.AddPoint(new Vector2(1250, 540));
            path14.AddPoint(new Vector2(1160, 0));
            #endregion

            //path15
            #region
            texPos1 = path15.beginT;
            path15.Clean();
            path15.AddPoint(new Vector2(800, -50));
            path15.AddPoint(new Vector2(700, 540));
            path15.AddPoint(new Vector2(800, 1080));
            #endregion

            //path16
            #region
            texPos1 = path16.beginT;
            path16.Clean();
            path16.AddPoint(new Vector2(2400, 200));
            path16.AddPoint(new Vector2(1700, 800));
            for (int i = 0; i < 20; i++)
            {
                path16.AddPoint(new Vector2(1500, 520));
                path16.AddPoint(new Vector2(1400, 320));
                path16.AddPoint(new Vector2(1200, 920));
            }


            #endregion
        }

        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < pathArray.Length; i++)
            {
                pathArray[i].Draw(spriteBatch);
                pathArray[i].DrawPoints(spriteBatch);
            }
        }
    }
}
