using PlayNow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayNow.Controllers
{
    public class RPGController : Controller
    {
        private ApplicationDbContext _context;
        // GET: GameSession

        public RPGController()
        {
            _context = new ApplicationDbContext();

        }
        // GET: RPG
        public ActionResult RPGIndex()
        {
            var RPGList = _context.RPGModel;
            var viewModel = new RPGViewModel()
            {
                RPGModels = RPGList
            };
            return View(viewModel);
        }
        public ActionResult NewRPGResult(RPGViewModel model)
        {
            string Name = model.Name;
            var RPG = new RPGModel()
            {
                Name = Name,
            };
            _context.RPGModel.Add(RPG);
            _context.SaveChanges();
            return RedirectToAction("RPGIndex", "RPG");
        }
    }
}