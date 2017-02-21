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

        public ActionResult NewPublicPlaceResult(PublicPlaceViewModel model)
        {
            var currentUserName = User.Identity.Name;
            var currentUser = _context.Users.FirstOrDefault(m => m.UserName == currentUserName);

            string Name = model.Name;
            string Address = model.Address;
            string City = model.City;
            string State = model.State;
            string Zipcode = model.Zipcode;
            string Phone = model.Phone;
            string Website = model.Website;
            double MyRating = System.Convert.ToDouble(model.MyRating);
            var PublicPlace = new PublicPlaceModel()
            {
                Name = Name,
                Address = Address,
                City = City,
                State = State,
                Zipcode = Zipcode,
                Phone = Phone,
                Website = Website,
                AverageRating = MyRating
            };
            _context.PublicPlaceModel.Add(PublicPlace);
            _context.SaveChanges();
            return RedirectToAction("PublicPlaceIndex", "PublicPlace");
        }
    }
}