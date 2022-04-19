using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceChat : IServiceChat
    {
        private List<User> _users = new List<User>();
        private int _newId = 1;

        public int Connect(string nameUser)
        {
            User user = new User() { Id = _newId, Name = nameUser, operationContext = OperationContext.Current };
            _newId++;
            _users.Add(user);
            SendMessage(user.Name + " вошёл в чат!", 0);
            return user.Id;
        }

        public void Disconnect(int id)
        {
            var user = _users.Find(i => i.Id == id);
            if (user!=null)
            {
                _users.Remove(user);
                SendMessage(user.Name + " вышел из чата!", 0);
            }
        }

        public void SendMessage(string message, int id)
        {
            foreach (var item in _users)
            {
                string answer = DateTime.Now.ToShortTimeString();
                var user = _users.Find(i => i.Id == id);
                if (user != null)
                {
                    answer += ": " + user.Name + " ";
                }
                answer += message;
                item.operationContext.GetCallbackChannel<IServerChatCallback>().MessageCallback(answer);
            }
        }
    }
}
