using Layout_and_views.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Layout_and_views.Controllers
{
    public class GuessingController : Controller
    {
        private static Random rng = new Random();

        [HttpGet]
        public ActionResult Index()
        {
            this.Session["Answer"] = rng.Next(1, 101);
            this.Session["GuessCount"] = 0;
            Guess guess = new Guess
            {
                Answer = (int)this.Session["Answer"],
                IsVictorious = false,
            };
      
            if(Request.Cookies["GuessingGame"] == null)
            {
                Response.Cookies["GuessingGame"]["HighScore"] = "500";
                Response.Cookies["GuessingGame"].Expires = DateTime.Now.AddYears(1);
                guess.HighScore = Convert.ToInt32(Response.Cookies["GuessingGame"]["HighScore"]);
            }
            else
            {
                guess.HighScore = Convert.ToInt32(Request.Cookies["GuessingGame"]["HighScore"]);
            }
            return View(guess);
        }
        [HttpPost]
        public ActionResult Index(Guess guessPost)
        {
            if (ModelState.IsValid && !this.Session.IsNewSession)
            {
                guessPost.Result = Guess.HighOrLow((int)this.Session["Answer"], guessPost.UserGuess);
                this.Session["GuessCount"] = (int)this.Session["GuessCount"] + 1;
                guessPost.GuessCount = (int)this.Session["GuessCount"];
                
                guessPost.HighScore = Convert.ToInt32(Request.Cookies["GuessingGame"]["HighScore"]);
                //highscore check
                if(guessPost.Result == GuessResult.CORRECT)
                {
                    if (Convert.ToInt32(Convert.ToInt32(Request.Cookies["GuessingGame"]["HighScore"])) > (int)this.Session["GuessCount"])
                    {
                        Response.Cookies["GuessingGame"]["HighScore"] = ((int)this.Session["GuessCount"]).ToString();
                        Response.Cookies["GuessingGame"].Expires = DateTime.Now.AddYears(1);
                    }
                    return RedirectToAction("Index");
                }
                return View(guessPost);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
            
        }
    }
}