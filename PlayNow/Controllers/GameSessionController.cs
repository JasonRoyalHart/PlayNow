using PlayNow.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PlayNow.Helpers;

namespace PlayNow.Controllers
{
    public class GameSessionController : Controller
    {
        private ApplicationDbContext _context;
        // GET: GameSession

        public GameSessionController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult GameSessionIndex()
        {
            var restList = _context.GameSessionModel;
            var gameList = _context.GameModel.ToList();
            var viewModel = new GameSessionViewModel()
            {
                Game = new Game(),
                GameSessionModels = restList,
                GameModels = gameList
            };
            return View(viewModel);
        }

        public ActionResult NewGameSessionResult(GameSessionViewModel model)
        {
            var currentUserName = User.Identity.Name;
            var currentUser = _context.Users.FirstOrDefault(m => m.UserName == currentUserName);
            int GameId = model.Game.GameId;
            var currentUserModel = _context.UserModel.FirstOrDefault(m => m.Email == currentUserName);
            string GameName = _context.GameModel.Find(GameId).Name;
            Game Game = model.Game;
            string Name = model.Name;
            string Time = model.Time;
            string Day = model.Day;
            string Month = model.Month;
            string Year = model.Year;
            int MinimumPlayers = model.MinimumPlayers;
            int MaximumPlayers = model.MaximumPlayers;
            double MinimumRating = model.MinimumRating;
            bool ApprovalNeeded = model.ApprovalNeeded;

            var GameSession = new GameSessionModel()
            {
                Creator = currentUserModel.DisplayName,
                Game = Game,
                GameId = GameId,
                Name = Name,
                Time = Time,
                Day = Day,
                Month = Month,
                Year = Year,
                MinimumPlayers = MinimumPlayers,
                MaximumPlayers = MaximumPlayers,
                MinimumRating = MinimumRating,
                GameName = GameName,
                ApprovalNeeded = ApprovalNeeded
            };
            _context.GameSessionModel.Add(GameSession);
            GameSession.Users.Add(currentUserModel);
            var ChatRoom = new ChatRoomModel();
            GameSession.ChatRooms.Add(ChatRoom);
            _context.SaveChanges();
            var restList = _context.GameSessionModel;
            var gameList = _context.GameModel.ToList();
            var viewModel = new GameSessionViewModel()
            {
                Game = new Game(),
                GameSessionModels = restList,
                GameModels = gameList
            };
            return View("GameSessionIndex", viewModel);
        }
        public ActionResult Details(int GameSessionDetails)
        {
            var restList = _context.GameSessionModel;
            var gameList = _context.GameModel.ToList();
            var GameSession = _context.GameSessionModel.Find(GameSessionDetails);
            var viewModel = new GameSessionViewModel()
            {
                Game = new Game(),
                GameSessionId = GameSessionDetails,
                GameSessionModels = restList,
                GameModels = gameList,
                GameName = GameSession.GameName,
                Time = GameSession.Time,
                Day = GameSession.Day,
                Month = GameSession.Month,
                Creator = GameSession.Creator,
                Year = GameSession.Year,
                ApprovalNeeded = GameSession.ApprovalNeeded,
                MinimumPlayers = GameSession.MinimumPlayers,
                MaximumPlayers = GameSession.MaximumPlayers,
                MinimumRating = GameSession.MinimumRating,
                Users = GameSession.Users,
                InvitedUsers = GameSession.InvitedUsers,
                UsersNeedingApproval = GameSession.UsersNeedingApproval
            };
            return View(viewModel);
        }
        public ActionResult DetailsPartial(int GameSessionDetails)
        {
            var restList = _context.GameSessionModel;
            var gameList = _context.GameModel.ToList();
            var GameSession = _context.GameSessionModel.Find(GameSessionDetails);
            var viewModel = new GameSessionViewModel()
            {
                Game = new Game(),
                GameSessionId = GameSessionDetails,
                GameSessionModels = restList,
                GameModels = gameList,
                GameName = GameSession.GameName,
                Time = GameSession.Time,
                Day = GameSession.Day,
                Month = GameSession.Month,
                Creator = GameSession.Creator,
                Year = GameSession.Year,
                ApprovalNeeded = GameSession.ApprovalNeeded,
                MinimumPlayers = GameSession.MinimumPlayers,
                MaximumPlayers = GameSession.MaximumPlayers,
                MinimumRating = GameSession.MinimumRating,
                Users = GameSession.Users,
                InvitedUsers = GameSession.InvitedUsers,
                UsersNeedingApproval = GameSession.UsersNeedingApproval
            };
            return PartialView("GameSessionDetailsPartial", viewModel);
        }

        public ActionResult GeneralChatMessages(int GameSessionId)
        {
            var ChatRoom = _context.ChatRoomModel.FirstOrDefault(m => m.GameSession.GameSessionId == GameSessionId);
            var Messages = ChatRoom.Messages;
            var ChatRoomViewModel = new ChatRoomViewModel()
            {
                ChatRoomId = ChatRoom.ChatRoomId,
                Messages = Messages
            };
            return PartialView("GameSessionChatRoomPartial", ChatRoomViewModel);
        }
        public ActionResult GeneralChat(int GameSessionId)
        {
            var ChatRoomMessageViewModel = new ChatRoomMessageViewModel()
            {
                GameSession = GameSessionId
            };
            return PartialView("GameSessionChatRoomAddMessagePartial", ChatRoomMessageViewModel);
        }
        public ActionResult AddMessage(ChatRoomMessageViewModel model)
        {
            var GameSessionId = model.GameSession;
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
            var ChatRoom = _context.ChatRoomModel.FirstOrDefault(m => m.GameSession.GameSessionId == GameSessionId);
            _context.ChatRoomModel.Find(ChatRoom.ChatRoomId).Messages.Add(ChatRoomMessage);
            _context.SaveChanges();
            var Messages = _context.ChatRoomModel.Find(ChatRoom.ChatRoomId).Messages;
            var restList = _context.GameSessionModel;
            var gameList = _context.GameModel.ToList();
            var GameSession = _context.GameSessionModel.Find(GameSessionId);
            var viewModel = new GameSessionViewModel()
            {
                Game = new Game(),
                GameSessionId = GameSessionId,
                GameSessionModels = restList,
                GameModels = gameList,
                GameName = GameSession.GameName,
                Time = GameSession.Time,
                Day = GameSession.Day,
                Month = GameSession.Month,
                Creator = GameSession.Creator,
                Year = GameSession.Year,
                ApprovalNeeded = GameSession.ApprovalNeeded,
                MinimumPlayers = GameSession.MinimumPlayers,
                MaximumPlayers = GameSession.MaximumPlayers,
                MinimumRating = GameSession.MinimumRating,
                Users = GameSession.Users,
                InvitedUsers = GameSession.InvitedUsers,
                UsersNeedingApproval = GameSession.UsersNeedingApproval
            };
            return View("Details", viewModel);
        }
    }
}