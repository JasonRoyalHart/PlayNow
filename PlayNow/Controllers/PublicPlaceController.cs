using PlayNow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayNow.Controllers
{
    public class PublicPlaceController : Controller
    {
        private ApplicationDbContext _context;
        // GET: GameSession

        public PublicPlaceController()
        {
            _context = new ApplicationDbContext();

        }
        // GET: PublicPlace
        public ActionResult PublicPlaceIndex()
        {
            var restList = _context.PublicPlaceModel;
            var viewModel = new PublicPlaceViewModel()
            {
                PublicPlaceModels = restList
            };
            return View(viewModel);
        }
        public ActionResult PublicPlaceList()
        {
            var restList = _context.PublicPlaceModel;
            var viewModel = new PublicPlaceViewModel()
            {
                PublicPlaceModels = restList
            };
            return View(viewModel);
        }

        public ActionResult NewPublicPlaceResult(PublicPlaceViewModel model)
        {
            var currentUserName = User.Identity.Name;
            var currentUser = _context.Users.FirstOrDefault(m => m.UserName == currentUserName);
            var currentUserModel = _context.UserModel.FirstOrDefault(m => m.Email == currentUserName);
            string Name = model.Name;
            string Address = model.Address;
            string City = model.City;
            string State = model.State;
            string Zipcode = model.Zipcode;
            string Phone = model.Phone;
            string Website = model.Website;
            int MyRating = model.MyRating;
            var PublicPlace = new PublicPlaceModel()
            {
                Name = Name,
                Address = Address,
                City = City,
                State = State,
                Zipcode = Zipcode,
                Phone = Phone,
                Website = Website,
                AverageRating = System.Convert.ToDouble(MyRating)
            };
            var FirstRating = new PublicPlaceRatingModel()
            {
                Rating = MyRating,
                User = currentUserModel,
                PublicPlace = PublicPlace
            };
            PublicPlace.Ratings.Add(FirstRating);
            _context.PublicPlaceModel.Add(PublicPlace);
            _context.SaveChanges();
            return RedirectToAction("PublicPlaceIndex", "PublicPlace");
        }
        public ActionResult Details(int PublicPlaceDetails)
        {
            var PublicPlace = _context.PublicPlaceModel.Find(PublicPlaceDetails);
            var currentUserName = User.Identity.Name;
            var currentUser = _context.Users.FirstOrDefault(m => m.UserName == currentUserName);
            var currentUserModel = _context.UserModel.FirstOrDefault(m => m.Email == currentUserName);
            var MyRating = _context.PublicPlaceRatingModel.FirstOrDefault(m => m.User.UserId == currentUserModel.UserId).Rating;
            //            var MyRating = _context.PublicPlaceRatingModel.ElementAt(MyRatingId);
            var PlaceGameModels = PublicPlace.Games;
            var AllGameModels = _context.GameModel;
            var viewModel = new PublicPlaceViewModel
            {
                Name = PublicPlace.Name,
                Address = PublicPlace.Address,
                City = PublicPlace.City,
                State = PublicPlace.State,
                Zipcode = PublicPlace.Zipcode,
                Phone = PublicPlace.Phone,
                Website = PublicPlace.Website,
                AverageRating = PublicPlace.AverageRating,
                MyRating = MyRating,
                Games = PlaceGameModels,
                PublicPlaceId = PublicPlace.PublicPlaceId,
                GameModels = AllGameModels
            };
            return View(viewModel);
        }
        public ActionResult DetailsResult(PublicPlaceViewModel model)
        {
            var currentUserName = User.Identity.Name;
            var currentUser = _context.Users.FirstOrDefault(m => m.UserName == currentUserName);
            var currentUserModel = _context.UserModel.FirstOrDefault(m => m.Email == currentUserName);
            var MyRating = _context.PublicPlaceRatingModel.FirstOrDefault(m => m.User.UserId == currentUserModel.UserId).Rating;
            int PublicPlaceId = model.PublicPlaceId;
            var PublicPlace = _context.PublicPlaceModel.Find(PublicPlaceId);
            var PlaceGameModels = PublicPlace.Games;
            var AllGameModels = _context.GameModel;
            var NewRating = model.MyRating;
            var ChangeRating = model.MyRating;
            PublicPlace.Ratings.FirstOrDefault(m => m.User == currentUserModel).Rating = ChangeRating;
            double NewAverage = CalculateAverageRating(PublicPlace);
            PublicPlace.AverageRating = NewAverage;
            if (model.Game != null)
            {
                int GameId = model.Game.GameId;
                var Game = _context.GameModel.Find(GameId);
                if (GameId != 0)
                {
                    PublicPlace.Games.Add(Game);
                }
            }
            _context.SaveChanges();

//            var currentUserModel = _context.UserModel.FirstOrDefault(m => m.Email == currentUserName);

            var viewModel = new PublicPlaceViewModel()
            {
                Name = PublicPlace.Name,
                Address = PublicPlace.Address,
                City = PublicPlace.City,
                State = PublicPlace.State,
                Zipcode = PublicPlace.Zipcode,
                Phone = PublicPlace.Phone,
                Website = PublicPlace.Website,
                AverageRating = PublicPlace.AverageRating,
                MyRating = ChangeRating,
                Games = PlaceGameModels,
                PublicPlaceId = PublicPlace.PublicPlaceId,
                GameModels = AllGameModels
            };
            return View("Details", viewModel);
        }
        public ActionResult RemoveGame(int GameToRemove, int PublicPlaceId)
        {
            var currentUserName = User.Identity.Name;
            var currentUser = _context.Users.FirstOrDefault(m => m.UserName == currentUserName);
            var currentUserModel = _context.UserModel.FirstOrDefault(m => m.Email == currentUserName);
            var MyRating = _context.PublicPlaceRatingModel.FirstOrDefault(m => m.User.UserId == currentUserModel.UserId).Rating;
            var PublicPlace = _context.PublicPlaceModel.Find(PublicPlaceId);
            var PlaceGameModels = PublicPlace.Games;
            var AllGameModels = _context.GameModel;
            var Game = _context.GameModel.Find(GameToRemove);
            PublicPlace.Games.Remove(Game);
            _context.SaveChanges();
            var viewModel = new PublicPlaceViewModel()
            {
                Name = PublicPlace.Name,
                Address = PublicPlace.Address,
                City = PublicPlace.City,
                State = PublicPlace.State,
                Zipcode = PublicPlace.Zipcode,
                Phone = PublicPlace.Phone,
                Website = PublicPlace.Website,
                AverageRating = PublicPlace.AverageRating,
                MyRating = MyRating,
                Games = PlaceGameModels,
                PublicPlaceId = PublicPlace.PublicPlaceId,
                GameModels = AllGameModels
            };
            return View("Details", viewModel);
        }
        public Double CalculateAverageRating(PublicPlaceModel PublicPlace)
        {
            int NumberOfRatings = PublicPlace.Ratings.Count();
            int TotalOfRatings = 0;
            for (int i = 0; i < NumberOfRatings; i++)
            {
                TotalOfRatings += PublicPlace.Ratings.ElementAt(i).Rating;
            }
            double NewRating = TotalOfRatings / NumberOfRatings;
            return NewRating;
        }
    }
}