using PlayNow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayNow.Controllers
{
    public class RPGListController : Controller
    {
        private ApplicationDbContext _context;
        // GET: GameSession
        public RPGListController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: RPGLIst
        public ActionResult RPGListIndex()
        {
            var restList = _context.RPGSessionModel;
            var currentUserName = User.Identity.Name;
            var currentUser = _context.UserModel.FirstOrDefault(m => m.Email == currentUserName);
            var viewModel = new RPGListViewModel()
            {
                RPGSessionModels = restList,
                CurrentUserId = currentUser.UserId
            };
            return View(viewModel);

        }
        public ActionResult Join(int RPGSessionToJoin)
        {
            var RPGSessionToAdd = _context.RPGSessionModel.Find(RPGSessionToJoin);
            var currentUserName = User.Identity.Name;
            var currentUser = _context.UserModel.FirstOrDefault(m => m.Email == currentUserName);
            if (RPGSessionToAdd.ApprovalNeeded)
            {
                RPGSessionToAdd.UsersNeedingApproval.Add(currentUser);
                currentUser.RPGSessionsApprovalNeeded.Add(RPGSessionToAdd);
                ViewBag.Message = "You require the creator's approval to join this RPG session. You have been added to the waiting list.";
            }
            else
            {
                RPGSessionToAdd.Users.Add(currentUser);
                currentUser.RPGSessions.Add(RPGSessionToAdd);
                ViewBag.Message = "You have been added to the RPG session.";
            }
            _context.SaveChanges();

            var restList = _context.RPGSessionModel;
            var viewModel = new RPGListViewModel()
            {
                RPGSessionModels = restList,
                CurrentUserId = currentUser.UserId
            };
            return View("RPGListIndex", viewModel);

        }
    }
}