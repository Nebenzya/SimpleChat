using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Service
{
    [ServiceContract(CallbackContract =typeof(IServerChatCallback))]
    public interface IServiceChat
    {
        [OperationContract]
        UserDTO Connect(string nameUser);

        [OperationContract]
        void Disconnect(Guid id);

        [OperationContract (IsOneWay = true)]
        void SendMessage(string message, Guid senderId = default, Guid recipientId = default);

        [OperationContract(IsOneWay = true)]
        void ChangeStatus(Guid id, UserStatus status);

        [OperationContract]
        IEnumerable<UserDTO> GetOnlineUsers();
    }

    public interface IServerChatCallback
    {
        [OperationContract(IsOneWay = true)]
        void MessageCallback(string message);

        [OperationContract(IsOneWay = true)]
        void StatusCallback(Guid id, UserStatus status);
    }
}
