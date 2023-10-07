using ClientApp.ServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ClientApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IServiceChatCallback
    {
        private ServiceChatClient _client;
        private UserDTO _thisUser;
        private List<UserDTO> _users;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitClient();
        }

        private async void Window_Closing(object sender, CancelEventArgs e) => await Disconnect();

        private void InitClient()
        {
            try
            {
                _client = new ServiceChatClient(new InstanceContext(this));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при создание клиента.\nПодключение невозможно!" + ex.Message.ToString());
                buttonConnect.IsEnabled = false;
            }
        }


        private async Task Connect()
        {
            try
            {
                if (ClientIsOK)
                {
                    _thisUser = await _client.ConnectAsync(tbUserName.Text);
                    await _client.ChangeStatusAsync(_thisUser.Id, UserStatus.Online);

                    buttonConnect.Content = "Отключиться";
                    tbUserName.IsEnabled = false;
                }
                else
                    throw new Exception("Подключение не удалось!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                await Disconnect();
            }

        }

        private async Task Disconnect()
        {
            if (_client != null)
            {
                await _client?.DisconnectAsync(_thisUser.Id);

                _client = null;
            }
            buttonConnect.Content = "Подключиться";
            tbUserName.IsEnabled = true;
        }

        private async Task GetAllUsers()
        {
            _users = new List<UserDTO>(await _client.GetOnlineUsersAsync());
        }

        private async Task SetAllUsers()
        {
            cbOnlineUsers.DataContext = _users.Select(x => $"{x.Name}({x.Status})");
        }

        private async void buttonConnect_Click(object sender, RoutedEventArgs e)
        {
            if (ClientIsOK)
                await Disconnect();
            else
                await Connect();
        }

        public void MessageCallback(string message)
        {
            listBox.Items.Add(message);
        }

        public async void StatusCallback(Guid id, UserStatus status)
        {
            var user = _users.Find(u => u.Id == id);
            if (user != null)
            {
                user.Status = status;
            }
            else
            {
                await GetAllUsers();
            }

            await SetAllUsers();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (ClientIsOK)
                {
                    _client.SendMessage(textBoxMessage.Text, senderId: _thisUser.Id, default);
                    textBoxMessage.Text = string.Empty;
                }
            }
        }


        private bool ClientIsOK => _client != null && _client.State == CommunicationState.Opened;
    }
}
