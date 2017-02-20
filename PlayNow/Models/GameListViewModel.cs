using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlayNow.Models
{
    public class GameListViewModel
    {
        [Display(Name  = "Id")]
        public int GameListId { get; set; }
        public int CurrentUserId { get; set; }
        public IEnumerable<GameSessionModel> GameSessionModels { get; set; }
    }
}