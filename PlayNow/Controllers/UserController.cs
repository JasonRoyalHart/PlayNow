using PlayNow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayNow.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext _context;
        public UserController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: User
        public ActionResult UserIndex()
        {
            var currentUserName = User.Identity.Name;
            var currentUser = _context.Users.FirstOrDefault(m => m.UserName == currentUserName);
            ViewBag.Email = currentUser.Email;
            if ((_context.UserModel.FirstOrDefault(m => m.Email == currentUser.Email)) != null)
            {
                var userDetails = _context.UserModel.FirstOrDefault(m => m.Email == currentUser.Email);
                ViewBag.Address = userDetails.Address;
                ViewBag.DisplayName = userDetails.DisplayName;
                ViewBag.City = userDetails.City;
                ViewBag.Email = userDetails.Email;
                ViewBag.Zipcode = userDetails.Zipcode;
                ViewBag.Rating = userDetails.Rating;
                ViewBag.State = userDetails.State;
                ViewBag.Status = true;
            }
            else
            {
                ViewBag.Status = false;
            }
            var viewModel = new UserViewModel()
            {
                Email = currentUser.Email,
            };

            return View(viewModel);
        }
        public ActionResult UpdateUserResult(UserViewModel model)
        {
            string DisplayName = model.DisplayName;
            string Address = model.Address;
            string City = model.City;
            string State = model.State;
            string Zipcode = model.Zipcode;
            string Email = model.Email;
            var User = new UserModel()
            {
                DisplayName = DisplayName,
                Address = Address,
                Email = Email,
                City = City,
                Zipcode = Zipcode
            };
            int entry = _context.UserModel.FirstOrDefault(i => i.Email == Email).UserId;
            _context.UserModel.Find(entry).DisplayName = DisplayName;
            _context.UserModel.Find(entry).Address = Address;
            _context.UserModel.Find(entry).City = City;
            _context.UserModel.Find(entry).State = State;
            _context.UserModel.Find(entry).Zipcode = Zipcode;
            _context.SaveChanges();
            return RedirectToAction("UserIndex", "User");
        }
    }
}