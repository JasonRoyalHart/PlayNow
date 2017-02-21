using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlayNow.Models
{
    public class PublicPlaceRatingModel
    {
        [Key]
        public int PublicPlaceRatingID { get; set; }
        public int Rating { get; set; }
        public UserModel User { get; set;}
        public virtual PublicPlaceModel PublicPlace { get; set; }
    }
}