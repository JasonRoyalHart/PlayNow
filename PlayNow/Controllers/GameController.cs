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
    public class GameController : Controller
    {
        private ApplicationDbContext _context;
        // GET: GameSession

        public GameController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult GameIndex()
        {
            var restList = _context.GameModel;
            var viewModel = new GameViewModel()
            {
                GameModels = restList
            };
            return View(viewModel);
        }

        public ActionResult NewGameResult(GameViewModel model)
        {
            var currentUserName = User.Identity.Name;
            var currentUser = _context.Users.FirstOrDefault(m => m.UserName == currentUserName);

            string Name = model.Name;
            int MinimumPlayers = model.MinimumPlayers;
            int MaximumPlayers = model.MaximumPlayers;
            var Game = new GameModel()
            {
                Name = Name,
                MinimumPlayers = MinimumPlayers,
                MaximumPlayers = MaximumPlayers,
            };
            _context.GameModel.Add(Game);
            _context.SaveChanges();
            return RedirectToAction("GameIndex", "Game");
        }

    }
}