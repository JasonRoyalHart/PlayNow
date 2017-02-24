using PlayNow.Helpers;
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
            var currentUserModel = _context.UserModel.FirstOrDefault(m => m.Email == currentUserName);
            var gameList = currentUserModel.GamesIWantToPlay.ToList();
            var AllGameList = _context.GameModel.ToList();
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
                UserId = currentUserModel.UserId,
                Email = currentUser.Email,
                GameModels = gameList,
                AllGameModels = AllGameList,
                Game = new Game()
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
        public ActionResult UserList()
        {
            var restList = _context.UserModel;
            var viewModel = new UserViewModel()
            {
                UserModels = restList
            };
            return View(viewModel);
        }
        public ActionResult UserDetails(int UserId)
        {
            var UserToRate = _context.UserModel.Find(UserId);
            var currentUserName = User.Identity.Name;
            var currentUser = _context.Users.FirstOrDefault(m => m.UserName == currentUserName);
            var currentUserModel = _context.UserModel.FirstOrDefault(m => m.Email == currentUserName);
            int MyRating = 0;
            if (_context.UserRatingModel.FirstOrDefault(m => m.User.UserId == currentUserModel.UserId) == null)
            {
                MyRating = 5;
            }
            else
            {
                MyRating = _context.UserRatingModel.FirstOrDefault(m => m.User.UserId == currentUserModel.UserId).Rating;
            }


            var viewModel = new UserViewModel
            {
                DisplayName = UserToRate.DisplayName,
                Rating = UserToRate.Rating,
            };
            return View(viewModel);
        }
        public ActionResult DetailsResult(UserViewModel model)
        {
            var currentUserName = User.Identity.Name;
            var currentUser = _context.Users.FirstOrDefault(m => m.UserName == currentUserName);
            var currentUserModel = _context.UserModel.FirstOrDefault(m => m.Email == currentUserName);
            int UserToRateId = model.UserId;
            var UserToRate = _context.UserModel.Find(UserToRateId);
            var ChangeRating = model.MyRating;
            if (UserToRate.Ratings.FirstOrDefault(m => m.User == currentUserModel) != null)
            {
                UserToRate.Ratings.FirstOrDefault(m => m.User == currentUserModel).Rating = ChangeRating;
            }
            else
            {
                var FirstRating = new UserRatingModel()
                {
                    Rating = ChangeRating,
                    User = UserToRate,
                    RatingUser = currentUserModel
                };
                UserToRate.Ratings.Add(FirstRating);
                _context.SaveChanges();
            }
            double NewAverage = CalculateAverageRating(UserToRate);
            UserToRate.Rating = NewAverage;

            _context.SaveChanges();
            var viewModel = new UserViewModel()
            {
                DisplayName = UserToRate.DisplayName,
                Rating = UserToRate.Rating,
                MyRating = ChangeRating
            };
            return View("UserDetails", viewModel);
        }
        public ActionResult AddGame(UserViewModel model)
        {
            int GameId = model.Game.GameId;
            int UserId = model.UserId;
            var User = _context.UserModel.Find(UserId);
            var Game = _context.GameModel.Find(GameId);
            User.GamesIWantToPlay.Add(Game);
            _context.SaveChanges();
            var gameList = User.GamesIWantToPlay.ToList();
            var AllGameList = _context.GameModel.ToList();
            var viewModel = new UserViewModel()
            {
                UserId = UserId,
                Email = User.Email,
                GameModels = gameList,
                AllGameModels = AllGameList,
                Game = new Game()
            };
            ViewBag.Address = User.Address;
            ViewBag.DisplayName = User.DisplayName;
            ViewBag.City = User.City;
            ViewBag.Email = User.Email;
            ViewBag.Zipcode = User.Zipcode;
            ViewBag.Rating = User.Rating;
            ViewBag.State = User.State;
            ViewBag.Status = true;
            return View("UserIndex", viewModel);
        }
        public Double CalculateAverageRating(UserModel User)
        {
            int NumberOfRatings = User.Ratings.Count();
            int TotalOfRatings = 0;
            for (int i = 0; i < NumberOfRatings; i++)
            {
                TotalOfRatings += User.Ratings.ElementAt(i).Rating;
            }
            double NewRating = TotalOfRatings / NumberOfRatings;
            return NewRating;
        }
    }
}