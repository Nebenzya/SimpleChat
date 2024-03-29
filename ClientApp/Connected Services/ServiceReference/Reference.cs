﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientApp.ServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserDTO", Namespace="http://schemas.datacontract.org/2004/07/Service")]
    [System.SerializableAttribute()]
    public partial class UserDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Guid IdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private ClientApp.ServiceReference.UserStatus StatusField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Guid Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ClientApp.ServiceReference.UserStatus Status {
            get {
                return this.StatusField;
            }
            set {
                if ((this.StatusField.Equals(value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserStatus", Namespace="http://schemas.datacontract.org/2004/07/Service")]
    public enum UserStatus : int {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Online = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Busy = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        AFK = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Offline = 3,
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference.IServiceChat", CallbackContract=typeof(ClientApp.ServiceReference.IServiceChatCallback))]
    public interface IServiceChat {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChat/Connect", ReplyAction="http://tempuri.org/IServiceChat/ConnectResponse")]
        ClientApp.ServiceReference.UserDTO Connect(string nameUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChat/Connect", ReplyAction="http://tempuri.org/IServiceChat/ConnectResponse")]
        System.Threading.Tasks.Task<ClientApp.ServiceReference.UserDTO> ConnectAsync(string nameUser);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChat/Disconnect", ReplyAction="http://tempuri.org/IServiceChat/DisconnectResponse")]
        void Disconnect(System.Guid id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChat/Disconnect", ReplyAction="http://tempuri.org/IServiceChat/DisconnectResponse")]
        System.Threading.Tasks.Task DisconnectAsync(System.Guid id);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceChat/SendMessage")]
        void SendMessage(string message, System.Guid senderId, System.Guid recipientId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceChat/SendMessage")]
        System.Threading.Tasks.Task SendMessageAsync(string message, System.Guid senderId, System.Guid recipientId);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceChat/ChangeStatus")]
        void ChangeStatus(System.Guid id, ClientApp.ServiceReference.UserStatus status);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceChat/ChangeStatus")]
        System.Threading.Tasks.Task ChangeStatusAsync(System.Guid id, ClientApp.ServiceReference.UserStatus status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChat/GetOnlineUsers", ReplyAction="http://tempuri.org/IServiceChat/GetOnlineUsersResponse")]
        ClientApp.ServiceReference.UserDTO[] GetOnlineUsers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceChat/GetOnlineUsers", ReplyAction="http://tempuri.org/IServiceChat/GetOnlineUsersResponse")]
        System.Threading.Tasks.Task<ClientApp.ServiceReference.UserDTO[]> GetOnlineUsersAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChatCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceChat/MessageCallback")]
        void MessageCallback(string message);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServiceChat/StatusCallback")]
        void StatusCallback(System.Guid id, ClientApp.ServiceReference.UserStatus status);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChatChannel : ClientApp.ServiceReference.IServiceChat, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceChatClient : System.ServiceModel.DuplexClientBase<ClientApp.ServiceReference.IServiceChat>, ClientApp.ServiceReference.IServiceChat {
        
        public ServiceChatClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public ServiceChatClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public ServiceChatClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceChatClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceChatClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public ClientApp.ServiceReference.UserDTO Connect(string nameUser) {
            return base.Channel.Connect(nameUser);
        }
        
        public System.Threading.Tasks.Task<ClientApp.ServiceReference.UserDTO> ConnectAsync(string nameUser) {
            return base.Channel.ConnectAsync(nameUser);
        }
        
        public void Disconnect(System.Guid id) {
            base.Channel.Disconnect(id);
        }
        
        public System.Threading.Tasks.Task DisconnectAsync(System.Guid id) {
            return base.Channel.DisconnectAsync(id);
        }
        
        public void SendMessage(string message, System.Guid senderId, System.Guid recipientId) {
            base.Channel.SendMessage(message, senderId, recipientId);
        }
        
        public System.Threading.Tasks.Task SendMessageAsync(string message, System.Guid senderId, System.Guid recipientId) {
            return base.Channel.SendMessageAsync(message, senderId, recipientId);
        }
        
        public void ChangeStatus(System.Guid id, ClientApp.ServiceReference.UserStatus status) {
            base.Channel.ChangeStatus(id, status);
        }
        
        public System.Threading.Tasks.Task ChangeStatusAsync(System.Guid id, ClientApp.ServiceReference.UserStatus status) {
            return base.Channel.ChangeStatusAsync(id, status);
        }
        
        public ClientApp.ServiceReference.UserDTO[] GetOnlineUsers() {
            return base.Channel.GetOnlineUsers();
        }
        
        public System.Threading.Tasks.Task<ClientApp.ServiceReference.UserDTO[]> GetOnlineUsersAsync() {
            return base.Channel.GetOnlineUsersAsync();
        }
    }
}
