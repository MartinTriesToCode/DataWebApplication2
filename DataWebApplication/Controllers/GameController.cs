using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DataWebApplication.Controllers
{
    public class GameController : Controller
    {
        public IActionResult GuessingGame()
        {
            //Debugging code to delete highscore list
            //Response.Cookies.Delete("highscoreCookie",
            //new CookieOptions { MaxAge = TimeSpan.FromDays(-1) });

            if (HttpContext.Session.GetInt32("guess") != null)
            {
                HttpContext.Session.Remove("guess");
            }
            if (HttpContext.Session.GetInt32("counter") != null)
            {
                ViewBag.final = "You had " + HttpContext.Session.GetInt32("counter")
                    + " failed guesses.";
            }
            Random rand = new Random();
            HttpContext.Session.SetInt32("rand_number", rand.Next(1, 100));
            HttpContext.Session.SetInt32("counter", 0);

            return View();
        }

        [HttpPost]
        public IActionResult GuessingGame(string number)
        {
            string message;
            List<int> highscoreList = new List<int>();
            int guess = Convert.ToInt32(number);
            ViewBag.highscore_header = null;
            ModelState.Clear();
            int rd = (int)HttpContext.Session.GetInt32("rand_number");
            int ct = (int)HttpContext.Session.GetInt32("counter");

            if (guess < rd)
            {
                message = "Your guess was too low. Make another guess.";
                HttpContext.Session.SetInt32("counter", ++ct);
            }
            else if (guess > rd)
            {
                message = "Your guess was too high. Make another guess.";
                HttpContext.Session.SetInt32("counter", ++ct);
            }
            else
            {
                message = " Congratulations! You guessed the right number.";
                ViewBag.Guesses = null;
                ViewBag.highscore_header = "Highscore";

                //Handle highscore cookie
                if (Request.Cookies.ContainsKey("highscoreCookie"))
                {
                    highscoreList = Request.Cookies["highscoreCookie"].Split(',').
                        Select(x => Convert.ToInt32(x)).ToList();
                    highscoreList.Add(ct);
                    highscoreList.Sort();
                    var highscoreListString = String.Join(",", highscoreList);
                    Response.Cookies.Append("highscoreCookie", highscoreListString,
                        new CookieOptions { MaxAge = TimeSpan.FromDays(1) });
                }
                else
                {
                    highscoreList.Add(ct);
                    var highscoreListString = String.Join(",", highscoreList);
                    Response.Cookies.Append("highscoreCookie", highscoreListString,
                        new CookieOptions { MaxAge = TimeSpan.FromDays(1) });
                }

                GuessingGame();
            }
            ct = (int)HttpContext.Session.GetInt32("counter");
            ViewBag.Message = message;
            ViewBag.Guesses = "Wrong guesses: " + ct.ToString();
            ViewBag.highscore = highscoreList;
            return View();
        }
    }
}
