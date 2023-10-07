using System;
using System.ServiceModel;
namespace Service
{
    public enum UserStatus
    {
        Online,
        Busy,
        AFK,
        Offline
    }

    internal class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public OperationContext operationContext { get; set; }
        public UserStatus Status { get; set; }
        public UserDTO GetUserDTO() => new UserDTO { Id = Id, Name = Name, Status = Status };
    }

    public class UserDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public UserStatus Status { get; set; }
    }
}
