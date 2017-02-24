using PlayNow.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayNow.Models
{
    public class RPGSessionViewModel
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
        public List<UserModel> Players { get; set; }
        public RPG RPG { get; set; }
        public User User { get; set; }
        public int GameId { get; set; }
        public string RPGName { get; set; }
        public int GM { get; set; }
        public string GMName { get; set; }
        public IEnumerable<RPGModel> RPGModels { get; set; }
        public IEnumerable<UserModel> UserModels { get; set; }
        public IEnumerable<RPGSessionModel> RPGSessionModels { get; set; }
        public bool ApprovalNeeded { get; set; }
        public virtual ICollection<UserModel> Users { get; set; }
        public virtual ICollection<UserModel> UsersNeedingApproval { get; set; }
        public virtual ICollection<UserModel> InvitedUsers { get; set; }
        public UserModel CurrentUserModel { get; set; }
        public RPGSessionModel RPGSessionToEdit { get; set; }
        public int NumberOfCurrentUsers { get; set; }
        public IEnumerable<UserModel> InvitableUsers { get; set; }
        public RPGSession RPGSession { get; set; }
    }
}