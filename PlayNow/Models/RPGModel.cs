using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PlayNow.Models
{
    public class RPGModel
    {
        [Key]
        public int RPGId { get; set; }
        public string Name { get; set; }
        public byte[] ImageData { get; set; }
        public double Rating { get; set; }
        public string AmazonLink { get; set; }
        [InverseProperty("RPGsIWantToPlay")]
        public virtual ICollection<UserModel> UsersThatWantToPlay { get; set; }
    }
}