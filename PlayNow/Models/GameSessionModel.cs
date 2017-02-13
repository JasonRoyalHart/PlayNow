using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayNow.Models
{
    public class GameSessionModel
    {
        public int Id { get; set; }
        public string Creator { get; set; }
        public string Game { get; set; }
        public int GameId { get; set; }
        public string Time { get; set; }
        public string Day { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public int MinimumPlayers { get; set; }
        public int MaximumPlayers { get; set; }
        public double MinimumRating { get; set; }
        public List<UserModel> Players { get; set; }
    }
}