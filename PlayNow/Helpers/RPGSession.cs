using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayNow.Helpers
{
    public class RPGSession
    {
        public int RPGSessionId { get; set; }
        public string Creator { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
        public string Day { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public string Repeats { get; set; }
        public int MinimumPlayers { get; set; }
        public int MaximumPlayers { get; set; }
        public double MinimumRating { get; set; }
        public RPG RPG { get; set; }
        public int RPGId { get; set; }
        public string RPGName { get; set; }
        public int GM { get; set; }
        public string GMName { get; set; }
        public int UserId { get; set; }
    }
}