using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tictactoe_Client_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static TcpClient client;
        static NetworkStream netStream;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Connect(string ip, int port)
        {
            client = new TcpClient();
            try
            {
                client.Connect("127.0.0.1", 2000);
                netStream = client.GetStream();
                //Thread receiveThread = new Thread(new ParameterizedThreadStart(RecieveFromServer));
               // receiveThread.Start();
            }
            catch
            {
                Connect(ip, port);
            }
          //  SendToServer("<All data>", null);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (myTextBox.Text=="")
            {
                 MessageBox.Show("You should specify the name!");
            }
            else
            {
                Connect("127.0.0.1", 2000);
            }



        }

    }
}
