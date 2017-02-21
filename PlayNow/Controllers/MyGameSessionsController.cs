using PlayNow.Helpers;
using PlayNow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayNow.Controllers
{
    public class MyGameSessionsController : Controller
    {

        private ApplicationDbContext _context;
        // GET: GameSession

        public MyGameSessionsController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult MyGameSessionsIndex()
        {
            var viewModel = CreateViewModel();
            return View(viewModel);
        }
        public ActionResult EditGameResult(GameSessionViewModel model, FormCollection collection)
        {

            var viewModel = new GameListViewModel()
            {
//                GameSessionModels = restList
            };
            return View(viewModel);
        }
        public ActionResult Approve(int ApprovedGameSession, int ApprovedId)
        {
            var UserToAdd = _context.UserModel.Find(ApprovedId);
            var GameSessionToAddTo = _context.GameSessionModel.Find(ApprovedGameSession);
            GameSessionToAddTo.UsersNeedingApproval.Remove(UserToAdd);
            GameSessionToAddTo.Users.Add(UserToAdd);
            _context.SaveChanges();
            ViewBag.Message = UserToAdd.DisplayName + " was accepted into game " + GameSessionToAddTo.GameId;

            var viewModel = CreateViewModel();

            return View("MyGameSessionsIndex", viewModel);
        }
        public ActionResult Deny(int DeniedGameSession, int DeniedId)
        {
            var UserToDeny = _context.UserModel.Find(DeniedId);
            var GameSessionToDeny = _context.GameSessionModel.Find(DeniedGameSession);
            GameSessionToDeny.UsersNeedingApproval.Remove(UserToDeny);
            _context.SaveChanges();
            ViewBag.Message = UserToDeny.DisplayName + " was denied entry to game " + GameSessionToDeny.GameId;

            var viewModel = CreateViewModel();

            return View("MyGameSessionsIndex", viewModel);
        }
        public ActionResult Edit(int GameSessionToEdit)
        {
            var restList = _context.GameSessionModel;
            var ThisGameSession = restList.Find(GameSessionToEdit);
            var UsersInList = CreateInviteList(GameSessionToEdit);
            var GameSession = new GameSession();
            var viewModel = CreateViewModel();
            viewModel.GameSessionToEdit = ThisGameSession;
            viewModel.InvitableUsers = UsersInList;
            viewModel.NumberOfCurrentUsers = ThisGameSession.Users.Count;
            return View(viewModel);

        }

        public ActionResult Remove(int GameSessionToRemoveFrom, int UserNumberToRemove)
        {
            var GameList = _context.GameSessionModel;
            var ThisGameSession = GameList.Find(GameSessionToRemoveFrom);
            var UserList = ThisGameSession.Users;
            var UserToRemove = UserList.ElementAt(UserNumberToRemove);
            _context.GameSessionModel.Find(GameSessionToRemoveFrom).Users.Remove(UserToRemove);
            var UsersInList = CreateInviteList(GameSessionToRemoveFrom);
            var GameSession = new GameSession();
            _context.SaveChanges();
            var viewModel = CreateViewModel();
            viewModel.GameSessionToEdit = ThisGameSession;
            viewModel.InvitableUsers = UsersInList;
            viewModel.GameSession = GameSession;
            viewModel.NumberOfCurrentUsers = ThisGameSession.Users.Count;

            return View("Edit", viewModel);
        }

        public ActionResult Invite(int GameSessionToInvite)
        {
            var GameList = _context.GameSessionModel;
            var ThisGameSession = GameList.Find(GameSessionToInvite);
            var UsersInList = CreateInviteList(GameSessionToInvite);
            var GameSession = new GameSession();
            var viewModel = CreateViewModel();
            viewModel.GameSessionToEdit = ThisGameSession;
            viewModel.InvitableUsers = UsersInList;
            viewModel.GameSession = GameSession;
            viewModel.NumberOfCurrentUsers = ThisGameSession.Users.Count;
            viewModel.GameSessionId = ThisGameSession.GameSessionId;
            return View("Invite", viewModel);
        }
        public ActionResult InviteResult(GameSessionViewModel model)
        {
            var currentUserName = User.Identity.Name;
            var currentUser = _context.Users.FirstOrDefault(m => m.UserName == currentUserName);
            var GameList = _context.GameSessionModel;
            int GameSessionId = model.GameSessionId;
            var ThisGameSession = GameList.Find(GameSessionId);
            var UsersInList = CreateInviteList(GameSessionId);
            var GameSession = new GameSession();
            int UserId = model.GameSession.UserId;
            var UserToInvite = _context.UserModel.Find(UserId);
            _context.GameSessionModel.Find(GameSessionId).InvitedUsers.Add(UserToInvite);
            _context.SaveChanges();
            var viewModel = CreateViewModel();
            viewModel.GameSessionToEdit = ThisGameSession;
            viewModel.InvitableUsers = UsersInList;
            viewModel.GameSession = GameSession;
            viewModel.NumberOfCurrentUsers = ThisGameSession.Users.Count;
            return View("Invite", viewModel);
        }
        public List<UserModel> CreateInviteList(int GameSessionToEdit)
        {
            var restList = _context.GameSessionModel;
            var ThisGameSession = restList.Find(GameSessionToEdit);
            var UsersNeedingApproval = ThisGameSession.UsersNeedingApproval;
            var Users = _context.UserModel;
            var InvitedUsers = ThisGameSession.InvitedUsers;
            List<UserModel> UsersInList = new List<UserModel>();
            var currentUserName = User.Identity.Name;
            var currentUser = _context.UserModel.FirstOrDefault(m => m.Email == currentUserName);
            foreach (var i in Users)
            {
                bool Add = true;
                if (i.Email == currentUser.Email)
                {
                    Add = false;
                }
                if (UsersNeedingApproval.Count > 0)
                {
                    foreach (var j in UsersNeedingApproval)
                    {
                        if (i.Email == j.Email)
                        {
                            Add = false;
                        }
                    }
                }
                if (InvitedUsers.Count > 0)
                {
                    foreach (var k in InvitedUsers)
                    {
                        if (i.Email == k.Email)
                        {
                            Add = false;
                        }
                    }
                }
                if (Add)
                {
                    UsersInList.Add(i);
                }
            }
            return UsersInList;

        }
        public GameSessionViewModel CreateViewModel()
        {
            var currentUserName = User.Identity.Name;
            var currentUser = _context.Users.FirstOrDefault(m => m.UserName == currentUserName);
            var currentUserModel = _context.UserModel.FirstOrDefault(m => m.Email == currentUserName);
            var restList = _context.GameSessionModel;
            List<GameSessionModel> MySessionList = new List<GameSessionModel>();
            for (int i = 1; i < restList.Count(); i++)
            {
                string Creator = restList.Find(i).Creator;
                if (Creator == currentUserName)
                {
                    MySessionList.Add(restList.Find(i));
                }
            }
            var viewModel = new GameSessionViewModel()
            {
                Game = new Game(),
                GameSessionModels = MySessionList,
                CurrentUserModel = currentUserModel
            };
            return viewModel;
        }
    }
}

