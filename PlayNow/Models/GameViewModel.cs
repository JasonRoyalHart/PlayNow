using PlayNow.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlayNow.Models
{
    public class GameViewModel
    {
        private ApplicationDbContext _context;
        public GameViewModel()
        {
            _context = new ApplicationDbContext();
        }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Minimum Players")]
        public int MinimumPlayers { get; set; }

        [Required]
        [Display(Name = "Maximum Players")]
        public int MaximumPlayers { get; set; }

        public IEnumerable<GameModel> GameModels { get; set; }
    }

}

