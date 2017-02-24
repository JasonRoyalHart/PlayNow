using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayNow.Models
{
    public class RPGViewModel
    {
        public int RPGId { get; set; }
        public string Name { get; set; }
        public byte[] ImageData { get; set; }
        public double Rating { get; set; }
        public string AmazonLink { get; set; }

        public IEnumerable<RPGModel> RPGModels { get; set; }
    }
}