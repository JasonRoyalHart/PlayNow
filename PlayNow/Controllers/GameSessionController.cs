using PlayNow.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PlayNow.Controllers
{
    public class GameSessionController : Controller
    {
        private ApplicationDbContext _context;
        // GET: GameSession

        public GameSessionController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult GameSessionIndex()
        {
            return View();
        }

        public ActionResult NewGameSessionResult(GameSessionViewModel model)
        {
            var currentUserName = User.Identity.Name;
            var currentUser = _context.Users.FirstOrDefault(m => m.UserName == currentUserName);

            string Game = model.Game;
            string Time = model.Time;
            string Day = model.Day;
            string Month = model.Month;
            string Year = model.Year;
            int MinimumPlayers = model.MinimumPlayers;
            int MaximumPlayers = model.MaximumPlayers;
            double MinimumRating = model.MinimumRating;
            var GameSession = new GameSessionModel()
            {
                Creator = currentUser.Email,
                Game = Game,
                Time = Time,
                Day = Day,
                Month = Month,
                Year = Year,
                MinimumPlayers = MinimumPlayers,
                MaximumPlayers = MaximumPlayers,
                MinimumRating = MinimumRating
            };
            _context.GameSessionModel.Add(GameSession);
            _context.SaveChanges();
            return RedirectToAction("GameSessionIndex", "Game");
        }
    }
}