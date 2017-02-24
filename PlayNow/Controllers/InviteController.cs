using PlayNow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayNow.Controllers
{
    public class InviteController : Controller
    {
        private ApplicationDbContext _context;
        public InviteController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Invite
        public ActionResult InviteIndex()
        {
            return View();
        }
        public ActionResult GameInvites()
        {
            var currentUserName = User.Identity.Name;
            var currentUser = _context.UserModel.FirstOrDefault(m => m.Email == currentUserName);
            var currentUserModel = _context.UserModel.FirstOrDefault(m => m.Email == currentUserName);
            var AllGameList = _context.GameSessionModel;
            List<GameSessionModel> InvitedList = new List<GameSessionModel>();
            foreach (var game in AllGameList)
            {
                if (game.InvitedUsers.Count() != 0)
                {
                    foreach (var invited in game.InvitedUsers)
                    {
                        if (invited.UserId == currentUserModel.UserId)
                        {
                            InvitedList.Add(game);
                        }
                    }
                }
            }

            var viewModel = new GameListViewModel()
            {
                GameSessionModels = InvitedList,
                CurrentUserId = currentUser.UserId
            };
            return PartialView("GameInvitePartial", viewModel);
        }

        public ActionResult RPGInvites()
        {
            var currentUserName = User.Identity.Name;
            var currentUser = _context.UserModel.FirstOrDefault(m => m.Email == currentUserName);
            var currentUserModel = _context.UserModel.FirstOrDefault(m => m.Email == currentUserName);
            var AllGameList = _context.RPGSessionModel;
            List<RPGSessionModel> InvitedList = new List<RPGSessionModel>();

            foreach (var game in AllGameList)
            {
                var InvitedUsers = game.InvitedUsers;
                if (InvitedUsers.Count() != 0)
                {
                    foreach (var invited in InvitedUsers)
                    {
                        if (invited.UserId == currentUserModel.UserId)
                        {
                            InvitedList.Add(game);
                        }
                    }
                }
            }

            var viewModel = new RPGListViewModel()
            {
                RPGSessionModels = InvitedList,
                CurrentUserId = currentUser.UserId
            };
            return PartialView("GameInvitePartial", viewModel);
        }
    }
}