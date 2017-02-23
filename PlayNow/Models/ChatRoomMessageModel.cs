using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlayNow.Models
{
    public class ChatRoomMessageModel
    {
        [Key]
        public int MessageId { get; set; }
        public virtual ChatRoomModel ChatRoom { get; set; }
        public int User { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public int GameSession { get; set; }
    }
}