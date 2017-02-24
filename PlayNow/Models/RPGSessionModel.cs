using PlayNow.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PlayNow.Models
{
    public class RPGSessionModel
    {
        public RPGSessionModel()
        {
            this.Users = new HashSet<UserModel>();
            this.ChatRooms = new HashSet<ChatRoomModel>();
            this.UsersNeedingApproval = new HashSet<UserModel>();
            this.InvitedUsers = new HashSet<UserModel>();
        }
        [Key]
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

        [InverseProperty("RPGSessions")]
        public virtual ICollection<UserModel> Users { get; set; }
        [InverseProperty("RPGSessionsApprovalNeeded")]
        public virtual ICollection<UserModel> UsersNeedingApproval { get; set; }
        [InverseProperty("RPGSessionsInvitedTo")]
        public virtual ICollection<UserModel> InvitedUsers { get; set; }
        public int UserId { get; set; }
        public bool ApprovalNeeded { get; set; }
        public virtual ICollection<ChatRoomModel> ChatRooms { get; set; }
    }
}