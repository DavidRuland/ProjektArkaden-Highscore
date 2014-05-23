using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjektArkaden
{
    public class Highscore
    {
        
         string PlayerName;
      
         List<int> UnitedScore;
         List<int> BestPlayerScore;
         private string name;
         private int p;
         private List<int> scoreList;
         private List<int> BestPlayerScoreList;

         public Highscore(string PlayerName, List<int> UnitedScore, List<int> BestPlayerScore)
        {
            this.PlayerName = PlayerName;
           
           this.UnitedScore = new List<int>();
           this.BestPlayerScore = new List<int>();

        }

    
        public override string ToString()
        {
            return PlayerName + "," + UnitedScore + "," +BestPlayerScore;
        }
    }
    }

