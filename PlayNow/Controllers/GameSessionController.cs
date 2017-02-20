using PlayNow.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PlayNow.Helpers;

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
            var restList = _context.GameSessionModel;
            var gameList = _context.GameModel.ToList();
            var viewModel = new GameSessionViewModel()
            {
                Game = new Game(),
                GameSessionModels = restList,
                GameModels = gameList
            };
            return View(viewModel);
        }

        public ActionResult NewGameSessionResult(GameSessionViewModel model)
        {
            var currentUserName = User.Identity.Name;
            var currentUser = _context.Users.FirstOrDefault(m => m.UserName == currentUserName);
            int GameId = model.Game.GameId;
            string GameName = _context.GameModel.Find(GameId).Name;
            Game Game = model.Game;
            string Name = model.Name;
            string Time = model.Time;
            string Day = model.Day;
            string Month = model.Month;
            string Year = model.Year;
            int MinimumPlayers = model.MinimumPlayers;
            int MaximumPlayers = model.MaximumPlayers;
            double MinimumRating = model.MinimumRating;
            bool ApprovalNeeded = model.ApprovalNeeded;

            var GameSession = new GameSessionModel()
            {
                Creator = currentUser.Email,
                Game = Game,
                GameId = GameId,
                Name = Name,
                Time = Time,
                Day = Day,
                Month = Month,
                Year = Year,
                MinimumPlayers = MinimumPlayers,
                MaximumPlayers = MaximumPlayers,
                MinimumRating = MinimumRating,
                GameName = GameName,
                ApprovalNeeded = ApprovalNeeded
            };
            _context.GameSessionModel.Add(GameSession);
            var currentUserModel = _context.UserModel.FirstOrDefault(m => m.Email == currentUserName);
            GameSession.Users.Add(currentUserModel);
            _context.SaveChanges();
            return RedirectToAction("GameSessionIndex", "GameSession");
        }
    }
}