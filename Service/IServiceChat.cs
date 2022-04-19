using System.ServiceModel;

namespace Service
{
    [ServiceContract(CallbackContract =typeof(IServerChatCallback))]
    public interface IServiceChat
    {
        [OperationContract]
        int Connect(string nameUser);

        [OperationContract]
        void Disconnect(int id);

        [OperationContract (IsOneWay = true)]
        void SendMessage(string message, int id);
    }

    public interface IServerChatCallback
    {
        [OperationContract(IsOneWay = true)]
        void MessageCallback(string message);
    }
}
