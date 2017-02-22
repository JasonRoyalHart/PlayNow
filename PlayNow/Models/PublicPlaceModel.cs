using PlayNow.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PlayNow.Models
{
    public class PublicPlaceModel
    {
        [Key]
        public int PublicPlaceId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public double AverageRating { get; set; }

        [InverseProperty("PublicPlaces")]
        public virtual ICollection<GameModel> Games { get; set; }
        public PublicPlaceModel()
        {
            Ratings = new List<PublicPlaceRatingModel>();
        }
        public int MyRating { get; set; }
        public virtual ICollection<PublicPlaceRatingModel> Ratings { get; set; }
        public Game Game;
        public IEnumerable<GameModel> GameModels;
    }
}