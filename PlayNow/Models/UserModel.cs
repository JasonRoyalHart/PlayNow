using PlayNow.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayNow.Models
{
    public class UserModel
    {
        public UserModel()
        {
            this.GameSessions = new HashSet<GameSessionModel>();
            this.Ratings = new List<UserRatingModel>();
            this.RPGSessions = new HashSet<RPGSessionModel>();
            //            this.GameSessionsApprovalNeeded = new HashSet<GameSessionModel>();
            //            this.GameSessionsInvitedTo = new HashSet<GameSessionModel>();
        }
        [Key]
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
        [InverseProperty("Users")]
        public virtual ICollection<GameSessionModel> GameSessions { get; set; }
        [InverseProperty("UsersNeedingApproval")]
        public virtual ICollection<GameSessionModel> GameSessionsApprovalNeeded { get; set; }
        [InverseProperty("InvitedUsers")]
        public virtual ICollection<GameSessionModel> GameSessionsInvitedTo { get; set; }
        [InverseProperty("UsersThatWantToPlay")]
        public virtual ICollection<GameModel> GamesIWantToPlay { get; set; }
        public int GameSessionId { get; set; }
        public IEnumerable<UserModel> UserModels { get; set; }
        public double AverageRating { get; set; }

        public int MyRating { get; set; }
        public virtual ICollection<UserRatingModel> Ratings { get; set; }
        public Game Game { get; set; }

        [InverseProperty("Users")]
        public virtual ICollection<RPGSessionModel> RPGSessions { get; set; }
        [InverseProperty("UsersNeedingApproval")]
        public virtual ICollection<RPGSessionModel> RPGSessionsApprovalNeeded { get; set; }
        [InverseProperty("InvitedUsers")]
        public virtual ICollection<RPGSessionModel> RPGSessionsInvitedTo { get; set; }
        [InverseProperty("UsersThatWantToPlay")]
        public virtual ICollection<RPGModel> RPGsIWantToPlay { get; set; }
    }
}