using PlayNow.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;

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
            var gameList = _context.GameModel;
            var viewModel = new GameViewModel()
            {
                GameModels = gameList
            };
            return View(viewModel);
        }

        public ActionResult NewGameResult(GameViewModel model)
        {
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