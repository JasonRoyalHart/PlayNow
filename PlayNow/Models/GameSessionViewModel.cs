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
        [Display(Name = "Game")]
        public string Game { get; set; }

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
        public int MinimumRating { get; set; }
    }

}