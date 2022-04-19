using System;
using System.Windows;
using System.Windows.Input;
using System.ComponentModel;
using ClientApp.ServiceChat;

namespace ClientApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IServiceChatCallback
    {
        private bool _isConnected = false;
        private ServiceChatClient _client;
        private int _id;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Disconnect();
        }

        private void Connect()
        {
            try
            {
                if (!_isConnected)
                {
                    _client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));
                    _id = _client.Connect(textBoxName.Text);
                    buttonConnect.Content = "Отключиться";
                    _isConnected = true;
                    textBoxName.IsEnabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void Disconnect()
        {
            if (_isConnected)
            {
                _client.Disconnect(_id);
                _client = null;
                buttonConnect.Content = "Подключиться";
                _isConnected = false;
                textBoxName.IsEnabled = true;
            }
        }

        private void buttonConnect_Click(object sender, RoutedEventArgs e)
        {
            if (_isConnected)
                Disconnect();
            else
                Connect();
        }

        public void MessageCallback(string message)
        {
            listBox.Items.Add(message);
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (_client != null)
                {
                    _client.SendMessage(textBoxMessage.Text, _id);
                    textBoxMessage.Text = "";
                }
            }
        }
    }
}
