using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayNow.Helpers
{
    public class RPG
    {
        public int RPGId { get; set; }
        public string Name { get; set; }
        public byte[] ImageData { get; set; }
        public double Rating { get; set; }
        public string AmazonLink { get; set; }
    }
}