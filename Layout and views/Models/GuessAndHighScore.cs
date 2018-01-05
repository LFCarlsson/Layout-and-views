using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Layout_and_views.Models
{
    public class GuessAndHighScore
    {
        public HighScore HighScore { get; set; }
        public Guess Guess { get; set; }
        public GuessAndHighScore()
        {
            HighScore = new HighScore();
            Guess = new Guess();
        }
        public GuessAndHighScore(HighScore highScore, Guess guess)
        {
            HighScore = highScore;
            Guess = guess;
        }
    }
}