using PlayNow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayNow.Controllers
{
    public class GeneralChatController : Controller
    {
        private ApplicationDbContext _context;
        public GeneralChatController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult GeneralChatIndex()
        {
            var Messages = _context.ChatRoomModel.Find(1).Messages;
            var ChatRoomViewModel = new ChatRoomViewModel()
            {
                ChatRoomId = 1,
                Messages = Messages
            };
            var ChatRoomMessageViewModel = new ChatRoomMessageViewModel()
            {

            };
            var viewModel = new ChatRoomAndMessageViewModel()
            {
                ChatRoom = ChatRoomViewModel,
                ChatRoomMessages = ChatRoomMessageViewModel
            };
            return View(viewModel);
        }
        public ActionResult GeneralChatMessages()
        {
            var Messages = _context.ChatRoomModel.Find(1).Messages;
            var ChatRoomViewModel = new ChatRoomViewModel()
            {
                ChatRoomId = 1,
                Messages = Messages
            };
            return PartialView("GeneralChatRoomPartial", ChatRoomViewModel);
        }
        public ActionResult GeneralChat()
        {
            var ChatRoomMessageViewModel = new ChatRoomMessageViewModel()
            {

            };
            return PartialView("GeneralChatRoomAddMessagePartial", ChatRoomMessageViewModel);
        }
        public ActionResult AddMessage(ChatRoomMessageViewModel model)
        {
            string NewMessage = model.Message;
            var currentUserName = User.Identity.Name;
            var currentUser = _context.UserModel.FirstOrDefault(m => m.Email == currentUserName);
            string CompleteMessage = currentUser.DisplayName + " says " + NewMessage;
            var ChatRoomMessage = new ChatRoomMessageModel
            {
                User = currentUser.UserId,
                UserName = currentUser.DisplayName,
                Message = CompleteMessage
            };
            _context.ChatRoomModel.Find(1).Messages.Add(ChatRoomMessage);
            _context.SaveChanges();
            var Messages = _context.ChatRoomModel.Find(1).Messages;
            var ChatRoomViewModel = new ChatRoomViewModel()
            {
                ChatRoomId = 1,
                Messages = Messages
            };
            var ChatRoomMessageViewModel = new ChatRoomMessageViewModel()
            {

            };
            var viewModel = new ChatRoomAndMessageViewModel()
            {
                ChatRoom = ChatRoomViewModel,
                ChatRoomMessages = ChatRoomMessageViewModel
            };

            return View("GeneralChatIndex",viewModel);
        }
    }
}