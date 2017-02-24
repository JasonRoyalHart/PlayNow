using PlayNow.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayNow.Models
{
    public class UserViewModel
    {
        public int UserId { get; set; }
        public string DisplayName { get; set; }
        public double Rating { get; set; }
        public byte[] ImageData { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Login { get; set; }
        public virtual ICollection<UserRatingModel> Ratings { get; set; }
        public int MyRating { get; set; }
        public IEnumerable<UserModel> UserModels { get; set; }
        public Game Game { get; set; }
        public IEnumerable<GameModel> GameModels { get; set; }
        public IEnumerable<GameModel> AllGameModels { get; set; }
    }
}