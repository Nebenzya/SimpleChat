using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceChat : IServiceChat
    {
        private List<User> _users = new List<User>();

        public UserDTO Connect(string nameUser)
        {
            if (_users.Find(u => u.Name == nameUser).Id != default)
                throw new Exception("Данное имя уже существует!");

            User user = new User()
            {
                Id = Guid.NewGuid(),
                Name = nameUser,
                operationContext = OperationContext.Current,
                Status = UserStatus.Online
            };

            _users.Add(user);
            SendMessage(user.Name + " вошёл в чат!");
            SendUserStatusForAll(user);
            return user.GetUserDTO();
        }

        public void ChangeStatus(Guid id, UserStatus status)
        {
            var curUser = FindUser(id);
            if (UserExist(curUser))
            {
                curUser.Status = status;
                SendUserStatusForAll(curUser);
            }
        }

        public void Disconnect(Guid id)
        {
            var user = FindUser(id);
            if (UserExist(user) && _users.Remove(user))
            {
                user.Status = UserStatus.Offline;
                SendUserStatusForAll(user);
                SendMessage(user.Name + " вышел из чата!");
            }
        }

        public IEnumerable<UserDTO> GetOnlineUsers()
        {
            return _users.Select(u => u.GetUserDTO());
        }

        public void SendMessage(string message, Guid senderId = default, Guid recipientId = default)
        {
            // Если Id отправителя и имя получателя не указано,
            // значит сообщение для всех, иначе это приват
            if (senderId == default)
            {
                string str = AnswerHeader(string.Empty) + message;
                foreach (var user in _users)
                {
                    SendUserMessageSingle(user, str);
                }
            }
            else if (recipientId != default)
            {
                var recipient = _users.First(i => i.Id == recipientId);

                if (recipient != null)
                {
                    string str = AnswerHeader(_users.FirstOrDefault(i => i.Id == senderId).Name) + message;
                    SendUserMessageSingle(recipient, str);
                }
            }
        }

        private string AnswerHeader(string userName) => DateTime.Now.ToShortTimeString() + $" {userName}: ";

        private User FindUser(Guid id) => _users.Find(i => i.Id == id);

        private void SendUserStatusForAll(User senderUser)
        {
            foreach (var u in _users)
                u.operationContext.GetCallbackChannel<IServerChatCallback>()
                                  .StatusCallback(senderUser.Id, senderUser.Status);
        }

        private void SendUserMessageSingle(User recipientUser, string message) => 
            recipientUser.operationContext.GetCallbackChannel<IServerChatCallback>()
                                 .MessageCallback(message);

        private bool UserExist(User user) => user != null && user.Id != default;
    }
}
