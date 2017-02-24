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
        public int Rating { get; set; }
        public UserModel RatingUser { get; set; }
        public virtual UserModel User { get; set; }
    }
}