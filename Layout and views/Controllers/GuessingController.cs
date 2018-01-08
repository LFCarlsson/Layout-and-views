using Layout_and_views.Helpers;
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
            this.Session["GuessList"] = new List<int>();
            Guess guess = new Guess
            {
                Answer = (int)this.Session["Answer"],
            };
            HighScore highScore;
            
            var requestCookie = Request.Cookies["GuessingGame"];
            if (!CookieHelper.CookieExists(requestCookie))
            {
                highScore = new HighScore();
                var responseCookie = Response.Cookies["GuessingGame"];
                CookieHelper.WriteCookie(responseCookie,"HighScore", highScore, DateTime.Now.AddYears(1));
            }
            else
            {
                try
                {
                    highScore = CookieHelper.ReadCookie<HighScore>(requestCookie, "HighScore");
                    if(highScore == null)
                    {
                        throw (new Exception("Trash data in cookie"));
                    }
                }
                catch
                {
                    highScore = new HighScore();
                    var responseCookie = Response.Cookies["GuessingGame"];
                    CookieHelper.WriteCookie(responseCookie, "HighScore", highScore, DateTime.Now.AddYears(1));
                }
            }
            return View(new GuessAndHighScore(highScore,guess));
        }
        [HttpPost]
        public ActionResult Index(GuessAndHighScore model)
        {
            if (ModelState.IsValid && !this.Session.IsNewSession)
            {
                model.Guess.Result = Guess.HighOrLow((int)this.Session["Answer"], model.Guess.UserGuess);
                (this.Session["GuessList"] as List<int>).Add(model.Guess.UserGuess);
                model.Guess.GuessCount = (this.Session["GuessList"] as List<int>).Count();

                HttpCookie requestCookie = Request.Cookies["GuessingGame"];
                try
                {
                    model.HighScore = CookieHelper.ReadCookie<HighScore>(requestCookie, "HighScore");
                    if(model.HighScore == null)
                    {
                        throw (new Exception("HighScore was null!"));
                    }
                }
                catch(Exception e)
                {
                    model.HighScore = new HighScore();
                }
                //highscore check
                if(model.Guess.Result == GuessResult.CORRECT)
                {
                    model.HighScore.InsertScore((this.Session["GuessList"] as List<int>).Count());
                    HttpCookie responseCookie = Response.Cookies["GuessingGame"];
                    CookieHelper.WriteCookie(responseCookie, "HighScore", model.HighScore, DateTime.Now.AddYears(1));
                    //return RedirectToAction("Index");
                }
                return View(model);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
            
        }
    }
}