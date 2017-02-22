using PlayNow.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlayNow.Models
{
    public class PublicPlaceViewModel
    {
        private ApplicationDbContext _context;
        public PublicPlaceViewModel()
        {
            _context = new ApplicationDbContext();
        }
        public int PublicPlaceId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public double AverageRating { get; set; }

        [Display(Name = "My Rating")]

        public int MyRating { get; set; }
        public IEnumerable<PublicPlaceModel> PublicPlaceModels { get; set; }
        public Game Game { get; set; }
        public IEnumerable<GameModel> GameModels { get; set; }
        public virtual ICollection<GameModel> Games { get; set; }
    }
}