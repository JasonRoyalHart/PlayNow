using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayNow.Models
{
    public class GameModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GameId { get; set; }
        public byte[] ImageData { get; set; }
        public int MinimumPlayers { get; set; }
        public int MaximumPlayers { get; set; }
        public double Rating { get; set; }
        public string AmazonLink { get; set; }
        public Dictionary<string, double> Ratings { get; set; }
    }
}