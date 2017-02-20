using PlayNow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayNow.Helpers
{
    public class GameSession
    {
        public int GameSessionId { get; set; }
        public string Creator { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
        public string Day { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public int MinimumPlayers { get; set; }
        public int MaximumPlayers { get; set; }
        public double MinimumRating { get; set; }
        public Game Game { get; set; }
        public int GameId { get; set; }
        public string GameName { get; set; }

        public virtual ICollection<UserModel> Users { get; set; }
        public virtual ICollection<UserModel> UsersNeedingApproval { get; set; }

        public virtual ICollection<UserModel> InvitedUsers { get; set; }
        public int UserId { get; set; }
        public bool ApprovalNeeded { get; set; }
    }
}