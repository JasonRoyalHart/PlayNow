using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlayNow.Models
{
    public class UserRatingModel
    {
        [Key]
        public int UserRatingId { get; set; }
    }
}