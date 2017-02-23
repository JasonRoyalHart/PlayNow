using PlayNow.Helpers;
using PlayNow.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlayNow.Models
{
    public class GameSessionViewModel
    {
        private ApplicationDbContext _context;

        public GameSessionViewModel()
        {
            _context = new ApplicationDbContext();
        }


        [Required]
        [Display(Name = "Game Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Time")]
        public string Time { get; set; }

        [Required]
        [Display(Name = "Day")]
        public string Day { get; set; }
        [Required]
        [Display(Name = "Month")]
        public string Month { get; set; }

        [Required]
        [Display(Name = "Year")]
        public string Year { get; set; }

        [Required]
        [Display(Name = "Minimum Players")]
        public int MinimumPlayers { get; set; }

        [Required]
        [Display(Name = "Maximum Players")]
        public int MaximumPlayers { get; set; }

        [Required]
        [Display(Name = "Minimum Rating")]
        public double MinimumRating { get; set; }

        [Required]
        [Display(Name = "Require Approval")]
        public bool ApprovalNeeded { get; set; }
        public int GameSessionId { get; set; }
        public GameSessionModel GameSessionToEdit { get; set; }
        public IEnumerable<UserModel> InvitableUsers { get; set; }

        public IEnumerable<GameSessionModel> GameSessionModels { get; set; }
        public IEnumerable<GameModel> GameModels { get; set; }
        public Game Game { get; set; }
        public int NumberOfCurrentUsers { get; set; }
        public GameSession GameSession { get; set; }
        public UserModel CurrentUserModel { get; set; }
        public string GameName { get; set; }
        public string Creator { get; set; }
        public virtual ICollection<UserModel> Users { get; set; }
        public virtual ICollection<UserModel> UsersNeedingApproval { get; set; }
        public virtual ICollection<UserModel> InvitedUsers { get; set; }
    }

}