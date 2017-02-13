using PlayNow.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayNow.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public double Rating { get; set; }
        public byte[] ImageData { get; set; }
        public Dictionary<string, double> Ratings { get; set; }
        public string Email { get; set; }
        public Dictionary<string, Helpers.GameSession> GameSessions {get; set;}
        public string Address { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }


    }
}