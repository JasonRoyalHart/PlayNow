using PlayNow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayNow.Controllers
{
    public class GameListController : Controller
    {
        private ApplicationDbContext _context;
        // GET: GameSession

        public GameListController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: GameList
        public ActionResult GameListIndex()
        {
            var restList = _context.GameSessionModel;
            var currentUserName = User.Identity.Name;
            var currentUser = _context.UserModel.FirstOrDefault(m => m.Email == currentUserName);
            var viewModel = new GameListViewModel()
            {
                GameSessionModels = restList,
                CurrentUserId = currentUser.UserId
            };
        return View(viewModel);

        }


        public ActionResult Join(int GameSessionToJoin)
        {
            var GameSessionToAdd = _context.GameSessionModel.Find(GameSessionToJoin);
            var currentUserName = User.Identity.Name;
            var currentUser = _context.UserModel.FirstOrDefault(m => m.Email == currentUserName);
            if (GameSessionToAdd.ApprovalNeeded)
            {
                GameSessionToAdd.UsersNeedingApproval.Add(currentUser);
                currentUser.GameSessionsApprovalNeeded.Add(GameSessionToAdd);
                ViewBag.Message = "You require the creator's approval to join this game session. You have been added to the waiting list.";
            }
            else
            {
                GameSessionToAdd.Users.Add(currentUser);
                currentUser.GameSessions.Add(GameSessionToAdd);
                ViewBag.Message = "You have been added to the game session.";
            }
            _context.SaveChanges();
            
            var restList = _context.GameSessionModel;
            var viewModel = new GameListViewModel()
            {
                GameSessionModels = restList,
                CurrentUserId = currentUser.UserId
            };
            return View("GameListIndex", viewModel);

        }
    }
}