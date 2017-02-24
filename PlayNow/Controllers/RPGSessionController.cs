using PlayNow.Helpers;
using PlayNow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlayNow.Controllers
{
    public class RPGSessionController : Controller
    {
        private ApplicationDbContext _context;
        // GET: GameSession

        public RPGSessionController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult RPGSessionIndex()
        {
            var restList = _context.RPGSessionModel;
            var gameList = _context.RPGModel.ToList();
            var userList = _context.UserModel;
            var viewModel = new RPGSessionViewModel()
            {
                RPG = new RPG(),
                RPGSessionModels = restList,
                RPGModels = gameList,
                UserModels = userList
            };
            return View(viewModel);
        }
        public ActionResult NewRPGSessionResult(RPGSessionViewModel model)
        {
            var currentUserName = User.Identity.Name;
            var currentUser = _context.Users.FirstOrDefault(m => m.UserName == currentUserName);
            var currentUserModel = _context.UserModel.FirstOrDefault(m => m.Email == currentUserName);
            int RPGId = model.RPG.RPGId;
            int GMId = model.User.UserId;
            string RPGName = _context.RPGModel.Find(RPGId).Name;
            string GMName = _context.UserModel.Find(GMId).DisplayName;
            RPG RPG = model.RPG;
            string Name = model.Name;
            string Time = model.Time;
            string Day = model.Day;
            string Month = model.Month;
            string Year = model.Year;
            int MinimumPlayers = model.MinimumPlayers;
            int MaximumPlayers = model.MaximumPlayers;
            double MinimumRating = model.MinimumRating;
            bool ApprovalNeeded = model.ApprovalNeeded;

            var RPGSession = new RPGSessionModel()
            {
                Creator = currentUserModel.DisplayName,
                GMName = GMName,
                GM = GMId,
                RPG = RPG,
                RPGId = RPGId,
                Name = Name,
                Time = Time,
                Day = Day,
                Month = Month,
                Year = Year,
                Repeats = model.Repeats,
                MinimumPlayers = MinimumPlayers,
                MaximumPlayers = MaximumPlayers,
                MinimumRating = MinimumRating,
                RPGName = RPGName,
                ApprovalNeeded = ApprovalNeeded
            };
            _context.RPGSessionModel.Add(RPGSession);
            RPGSession.Users.Add(currentUserModel);
            var ChatRoom = new ChatRoomModel();
            RPGSession.ChatRooms.Add(ChatRoom);
            _context.SaveChanges();
            var SessionList = _context.RPGSessionModel;
            var RPGList = _context.RPGModel.ToList();
            var UserList = _context.UserModel;
            var viewModel = new RPGSessionViewModel()
            {
                RPG = new RPG(),
                RPGSessionModels = SessionList,
                RPGModels = RPGList,
                UserModels = UserList
            };
            return View("RPGSessionIndex", viewModel);
        }
        public ActionResult Details(int RPGSessionDetails)
        {
            var restList = _context.RPGSessionModel;
            var RPGList = _context.RPGModel.ToList();
            var RPGSession = _context.RPGSessionModel.Find(RPGSessionDetails);
            var viewModel = new RPGSessionViewModel()
            {
                RPG = new RPG(),
                RPGSessionId = RPGSessionDetails,
                RPGSessionModels = restList,
                RPGModels = RPGList,
                RPGName = RPGSession.RPGName,
                Time = RPGSession.Time,
                Day = RPGSession.Day,
                Month = RPGSession.Month,
                Creator = RPGSession.Creator,
                Year = RPGSession.Year,
                Repeats = RPGSession.Repeats,
                GMName = RPGSession.GMName,
                ApprovalNeeded = RPGSession.ApprovalNeeded,
                MinimumPlayers = RPGSession.MinimumPlayers,
                MaximumPlayers = RPGSession.MaximumPlayers,
                MinimumRating = RPGSession.MinimumRating,
                Users = RPGSession.Users,
                InvitedUsers = RPGSession.InvitedUsers,
                UsersNeedingApproval = RPGSession.UsersNeedingApproval
            };
            return View("RPGSessionDetails", viewModel);
        }
        public ActionResult DetailsPartial(int RPGSessionDetails)
        {
            var restList = _context.RPGSessionModel;
            var RPGList = _context.RPGModel.ToList();
            var RPGSession = _context.RPGSessionModel.Find(RPGSessionDetails);
            var viewModel = new RPGSessionViewModel()
            {
                RPG = new RPG(),
                RPGSessionId = RPGSessionDetails,
                RPGSessionModels = restList,
                RPGModels = RPGList,
                RPGName = RPGSession.RPGName,
                Time = RPGSession.Time,
                Day = RPGSession.Day,
                Month = RPGSession.Month,
                Creator = RPGSession.Creator,
                GMName = RPGSession.GMName,
                Repeats = RPGSession.Repeats, 
                Year = RPGSession.Year,
                ApprovalNeeded = RPGSession.ApprovalNeeded,
                MinimumPlayers = RPGSession.MinimumPlayers,
                MaximumPlayers = RPGSession.MaximumPlayers,
                MinimumRating = RPGSession.MinimumRating,
                Users = RPGSession.Users,
                InvitedUsers = RPGSession.InvitedUsers,
                UsersNeedingApproval = RPGSession.UsersNeedingApproval
            };
            return PartialView("RPGSessionDetailsPartial", viewModel);
        }

        public ActionResult GeneralChatMessages(int RPGSessionId)
        {
            var ChatRoom = _context.ChatRoomModel.FirstOrDefault(m => m.RPGSession.RPGSessionId == RPGSessionId);
            var Messages = ChatRoom.Messages;
            var ChatRoomViewModel = new ChatRoomViewModel()
            {
                ChatRoomId = ChatRoom.ChatRoomId,
                Messages = Messages
            };
            return PartialView("RPGSessionChatRoomPartial", ChatRoomViewModel);
        }
        public ActionResult GeneralChat(int RPGSessionId)
        {
            var ChatRoomMessageViewModel = new ChatRoomMessageViewModel()
            {
                RPGSession = RPGSessionId
            };
            return PartialView("RPGSessionChatRoomAddMessagePartial", ChatRoomMessageViewModel);
        }
        public ActionResult AddMessage(ChatRoomMessageViewModel model)
        {
            var RPGSessionId = model.RPGSession;
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
            var ChatRoom = _context.ChatRoomModel.FirstOrDefault(m => m.RPGSession.RPGSessionId == RPGSessionId);
            _context.ChatRoomModel.Find(ChatRoom.ChatRoomId).Messages.Add(ChatRoomMessage);
            _context.SaveChanges();
            var Messages = _context.ChatRoomModel.Find(ChatRoom.ChatRoomId).Messages;
            var restList = _context.RPGSessionModel;
            var RPGList = _context.RPGModel.ToList();
            var RPGSession = _context.RPGSessionModel.Find(RPGSessionId);
            var viewModel = new RPGSessionViewModel()
            {
                RPG = new RPG(),
                RPGSessionId = RPGSessionId,
                RPGSessionModels = restList,
                RPGModels = RPGList,
                RPGName = RPGSession.RPGName,
                Time = RPGSession.Time,
                Day = RPGSession.Day,
                Month = RPGSession.Month,
                Creator = RPGSession.Creator,
                Year = RPGSession.Year,
                ApprovalNeeded = RPGSession.ApprovalNeeded,
                MinimumPlayers = RPGSession.MinimumPlayers,
                MaximumPlayers = RPGSession.MaximumPlayers,
                MinimumRating = RPGSession.MinimumRating,
                Users = RPGSession.Users,
                InvitedUsers = RPGSession.InvitedUsers,
                UsersNeedingApproval = RPGSession.UsersNeedingApproval
            };
            return View("RPGSessionDetails", viewModel);
        }
    }
}
