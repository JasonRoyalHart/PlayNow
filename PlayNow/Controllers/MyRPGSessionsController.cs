using PlayNow.Helpers;
using PlayNow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayNow.Controllers
{
    public class MyRPGSessionsController : Controller
    {
        private ApplicationDbContext _context;
        // GET: GameSession

        public MyRPGSessionsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: MyRPGSessions
        public ActionResult MyRPGSessionsIndex()
        {
            var viewModel = CreateViewModel();
            return View(viewModel);
        }
        public ActionResult Edit(int RPGSessionToEdit)
        {
            var restList = _context.RPGSessionModel;
            var ThisRPGSession = restList.Find(RPGSessionToEdit);
            var UsersInList = CreateInviteList(RPGSessionToEdit);
            var RPGSession = new RPGSession();
            var viewModel = CreateViewModel();
            viewModel.RPGSessionToEdit = ThisRPGSession;
            viewModel.InvitableUsers = UsersInList;
            viewModel.NumberOfCurrentUsers = ThisRPGSession.Users.Count;
            viewModel.RPGSessionId = RPGSessionToEdit;
            return View(viewModel);

        }
        public ActionResult EditRPGResult(RPGSessionViewModel model)
        {
            int entry = model.RPGSessionId;
            _context.RPGSessionModel.Find(entry).Time = model.Time;
            _context.RPGSessionModel.Find(entry).Day = model.Day;
            _context.RPGSessionModel.Find(entry).Month = model.Month;
            _context.RPGSessionModel.Find(entry).Year = model.Year;
            _context.RPGSessionModel.Find(entry).Repeats = model.Repeats;
            _context.SaveChanges();
            var viewModel = CreateViewModel();
            var restList = _context.RPGSessionModel;
            var ThisRPGSession = restList.Find(entry);
            var UsersInList = CreateInviteList(entry);
            viewModel.RPGSessionToEdit = ThisRPGSession;
            viewModel.InvitableUsers = UsersInList;
            viewModel.NumberOfCurrentUsers = ThisRPGSession.Users.Count;
            viewModel.RPGSessionId = entry;
            return View("Edit", viewModel);
        }
        public ActionResult Invite(int RPGSessionToInvite)
        {
            var RPGList = _context.RPGSessionModel;
            var ThisRPGSession = RPGList.Find(RPGSessionToInvite);
            var UsersInList = CreateInviteList(RPGSessionToInvite);
            var RPGSession = new RPGSession();
            var viewModel = CreateViewModel();
            viewModel.RPGSessionToEdit = ThisRPGSession;
            viewModel.InvitableUsers = UsersInList;
            viewModel.RPGSession = RPGSession;
            viewModel.NumberOfCurrentUsers = ThisRPGSession.Users.Count;
            viewModel.RPGSessionId = ThisRPGSession.RPGSessionId;
            return View("Invite", viewModel);
        }
        public ActionResult InviteResult(RPGSessionViewModel model)
        {
            var currentUserName = User.Identity.Name;
            var currentUser = _context.Users.FirstOrDefault(m => m.UserName == currentUserName);
            var RPGList = _context.RPGSessionModel;
            int RPGSessionId = model.RPGSessionId;
            var ThisRPGSession = RPGList.Find(RPGSessionId);
            var UsersInList = CreateInviteList(RPGSessionId);
            var RPGSession = new RPGSession();
            int UserId = model.RPGSession.UserId;
            var UserToInvite = _context.UserModel.Find(UserId);
            _context.RPGSessionModel.Find(RPGSessionId).InvitedUsers.Add(UserToInvite);
            _context.SaveChanges();
            var viewModel = CreateViewModel();
            viewModel.RPGSessionToEdit = ThisRPGSession;
            viewModel.InvitableUsers = UsersInList;
            viewModel.RPGSession = RPGSession;
            viewModel.NumberOfCurrentUsers = ThisRPGSession.Users.Count;
            return View("Invite", viewModel);
        }
        public List<UserModel> CreateInviteList(int RPGSessionToEdit)
        {
            var restList = _context.RPGSessionModel;
            var ThisRPGSession = restList.Find(RPGSessionToEdit);
            var UsersNeedingApproval = ThisRPGSession.UsersNeedingApproval;
            var Users = _context.UserModel;
            var InvitedUsers = ThisRPGSession.InvitedUsers;
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
        public ActionResult Approve(int ApprovedRPGSession, int ApprovedId)
        {
            var UserToAdd = _context.UserModel.Find(ApprovedId);
            var RPGSessionToAddTo = _context.RPGSessionModel.Find(ApprovedRPGSession);
            RPGSessionToAddTo.UsersNeedingApproval.Remove(UserToAdd);
            RPGSessionToAddTo.Users.Add(UserToAdd);
            _context.SaveChanges();
            ViewBag.Message = UserToAdd.DisplayName + " was accepted into game " + RPGSessionToAddTo.RPGId;

            var viewModel = CreateViewModel();

            return View("MyRPGSessionsIndex", viewModel);
        }
        public ActionResult Deny(int DeniedRPGSession, int DeniedId)
        {
            var UserToDeny = _context.UserModel.Find(DeniedId);
            var RPGSessionToDeny = _context.RPGSessionModel.Find(DeniedRPGSession);
            RPGSessionToDeny.UsersNeedingApproval.Remove(UserToDeny);
            _context.SaveChanges();
            ViewBag.Message = UserToDeny.DisplayName + " was denied entry to game " + RPGSessionToDeny.RPGId;

            var viewModel = CreateViewModel();

            return View("MyRPGSessionsIndex", viewModel);
        }
        public RPGSessionViewModel CreateViewModel()
        {
            var currentUserName = User.Identity.Name;
            var currentUser = _context.Users.FirstOrDefault(m => m.UserName == currentUserName);
            var currentUserModel = _context.UserModel.FirstOrDefault(m => m.Email == currentUserName);
            var currentUserId = currentUserModel.UserId;
            var restList = _context.RPGSessionModel;
            List<RPGSessionModel> MySessionList = new List<RPGSessionModel>();
            for (int i = 1; i <= restList.Count(); i++)
            {
                var Session = restList.Find(i);
                if (Session.InvitedUsers != null)
                {
                    for (int j = 0; j < Session.InvitedUsers.Count; j++)
                    {
                        var User = Session.InvitedUsers.ElementAt(j).UserId;
                        if (currentUserId == User)
                        {
                            MySessionList.Add(Session);
                        }
                    }
                }
                if (Session.Users != null)
                {
                    for (int j = 0; j < Session.Users.Count; j++)
                    {
                        var User = Session.Users.ElementAt(j).UserId;
                        if (currentUserId == User)
                        {
                            MySessionList.Add(Session);
                        }
                    }
                }
                if (Session.UsersNeedingApproval != null)
                {
                    for (int j = 0; j < Session.UsersNeedingApproval.Count; j++)
                    {
                        var User = Session.UsersNeedingApproval.ElementAt(j).UserId;
                        if (currentUserId == User)
                        {
                            MySessionList.Add(Session);
                        }
                    }
                }
            }
            var viewModel = new RPGSessionViewModel()
            {
                RPG = new RPG(),
                RPGSessionModels = MySessionList,
                CurrentUserModel = currentUserModel
            };
            return viewModel;
        }
    }
}