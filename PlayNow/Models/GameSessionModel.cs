using PlayNow.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlayNow.Models
{
    public class GameSessionModel
    {
        public GameSessionModel()
        {
            this.Users = new HashSet<UserModel>();
            this.ChatRooms = new HashSet<ChatRoomModel>();
            //            this.UsersNeedingApproval = new HashSet<UserModel>();
            //            this.InvitedUsers = new HashSet<UserModel>();
        }
        [Key]
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

        [InverseProperty("GameSessions")]
        public virtual ICollection<UserModel> Users { get; set; }
        [InverseProperty("GameSessionsApprovalNeeded")]
        public virtual ICollection<UserModel> UsersNeedingApproval { get; set; }
        [InverseProperty("GameSessionsInvitedTo")]
        public virtual ICollection<UserModel> InvitedUsers { get; set; }
        public int UserId { get; set; }
        public bool ApprovalNeeded { get; set; }
        public virtual ICollection<ChatRoomModel> ChatRooms { get; set; }
    }
}