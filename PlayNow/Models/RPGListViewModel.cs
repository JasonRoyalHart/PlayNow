using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlayNow.Models
{
    public class RPGListViewModel
    {
        [Display(Name = "Id")]
        public int RPGListId { get; set; }
        public int CurrentUserId { get; set; }
        public IEnumerable<RPGSessionModel> RPGSessionModels { get; set; }
    }
}