using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Layout_and_views.Models
{
    [Serializable]
    public class HighScore
    {
        const int HIGHSCORELEN = 10;
        public List<int> HighScoreList { get; set; }
        public HighScore()
        {
            HighScoreList = new List<int>();
        }
        public void InsertScore(int score)
        {
            //sanity check
            if (score > 1)
            {
                HighScoreList.Add(score);
                HighScoreList.Sort();
                HighScoreList = HighScoreList.GetRange(0, Math.Min(HighScoreList.Count(),HIGHSCORELEN) );
            }
        }
    }
}