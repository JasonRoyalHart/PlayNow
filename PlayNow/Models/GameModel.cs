using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayNow.Models
{
    public class GameModel
    {
        [Key]
        public int GameId { get; set; }
        public string Name { get; set; }
        public byte[] ImageData { get; set; }
        public int MinimumPlayers { get; set; }
        public int MaximumPlayers { get; set; }
        public double Rating { get; set; }
        public string AmazonLink { get; set; }

        [InverseProperty("Games")]
        public virtual ICollection<PublicPlaceModel> PublicPlaces { get; set; }
    }
}