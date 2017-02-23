using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PlayNow.Models
{
    public class ChatRoomModel
    {
        [Key]
        public int ChatRoomId { get; set; }
        public IEnumerable<ChatRoomModel> ChatRoomModels { get; set; }
        public virtual ICollection<ChatRoomMessageModel> Messages { get; set; }
        public virtual GameSessionModel GameSession { get; set; }

    }
}