using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayNow.Models
{
    public class ChatRoomAndMessageViewModel
    {
       public ChatRoomViewModel ChatRoom { get; set; }
       public ChatRoomMessageViewModel ChatRoomMessages { get; set; }
    }
}