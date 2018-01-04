using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Layout_and_views.Models
{
    public enum GuessResult
    {
        UNDEFINED,
        HIGH,
        LOW,
        CORRECT
    }
    public class Guess
    {
        public int Answer { get; set; }
        public GuessResult Result { get; set; }
        public int UserGuess { get; set; }
        public int GuessCount { get; set; }
        public int HighScore { get; set; }
        public bool IsVictorious { get; set; }

        public static GuessResult HighOrLow(int answer, int guess)
        {
            if (guess > answer)
            {
                return GuessResult.HIGH;
            }
            else if(guess < answer)
            {
                return GuessResult.LOW;
            }
            else
            {
                return GuessResult.CORRECT;
            }
        }
    }
}