using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayNow.Models
{
    public class ChatRoomViewModel
    {
        public int ChatRoomId { get; set; }
        public IEnumerable<ChatRoomModel> ChatRoomModels { get; set; }
        public virtual ICollection<ChatRoomMessageModel> Messages { get; set; }
    }
}