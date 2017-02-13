using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayNow.Helpers
{
    public class Location
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public double Rating { get; set; }
        public Dictionary<string, double> Ratings { get; set; }
        public Dictionary<string, string> Comments { get; set; }

    }
}