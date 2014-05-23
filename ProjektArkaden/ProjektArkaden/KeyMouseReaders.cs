using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace ProjektArkaden
{
     static class KeyMouseReaders
    {
        public static KeyboardState keyState, oldKeyState = Keyboard.GetState();
     
        public static bool KeyPressed(Keys key)
        {
            return keyState.IsKeyDown(key) && oldKeyState.IsKeyUp(key);
        }
  
      
        public static void Update()
        {
            oldKeyState = keyState;
            keyState = Keyboard.GetState();
           
        }
    }
    }

