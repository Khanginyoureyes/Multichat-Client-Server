using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Server
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Connect();
        }

        IPEndPoint IP = new(IPAddress.Any, 6990);
        Socket? server = null;
        List<Socket> ListClient = new();

        void Connect()
        {
            ListClient = new();
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            server.Bind(IP);
            Thread Listen = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        server.Listen(100);
                        Socket client = server.Accept();

                        lock (ListClient) // Khóa đồng bộ để tránh lỗi khi truy cập ListClient
                        {
                            ListClient.Add(client);
                        }

                        Thread receive = new Thread(obj => Receive((Socket)obj!));
                        receive.IsBackground = true;
                        receive.Start(client);
                    }
                }
                catch
                {
                    IP = new IPEndPoint(IPAddress.Any, 9999);
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                }
            });
            Listen.IsBackground = true;
            Listen.Start();
        }

        new void Close()
        {
            if (server != null)
            {
                server.Close();
                server = null!;
            }
        }

        void Receive(Socket client)
        {
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[1024 * 5000];
                    int receivedBytes = client.Receive(buffer);
                    if (receivedBytes == 0) break;

                    try
                    {
                        string? message = Deserialize<string>(buffer[..receivedBytes]); // Deserialize với xử lý lỗi
                        if (!string.IsNullOrEmpty(message))
                        {
                            AddMessege(message);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Deserialize error: {ex.Message}"); // Log lỗi khi Deserialize
                    }
                }
            }
            catch
            {
                lock (ListClient) // Khóa đồng bộ để xóa client khỏi danh sách
                {
                    ListClient.Remove(client);
                }
                client.Close();
            }
        }

        void AddMessege(string s)
        {
            Dispatcher.Invoke(() =>
            {
                lvmessage.Items.Add(new ListViewItem { Content = s });
            });
        }

        void Send(Socket client)
        {
            if (!string.IsNullOrEmpty(tbmessage.Text))
            {
                client.Send(Serialize(tbmessage.Text));
            }
        }

        static byte[] Serialize(object obj)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(obj);
                return Encoding.UTF8.GetBytes(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Serialize error: {ex.Message}");
                return Array.Empty<byte>();
            }
        }

        static T? Deserialize<T>(byte[] data)
        {
            try
            {
                string jsonString = Encoding.UTF8.GetString(data);
                return JsonSerializer.Deserialize<T>(jsonString) ?? default;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Deserialize error: {ex.Message}");
                return default;
            }
        }


        private void btSend_Click(object sender, RoutedEventArgs e)
        {
            lock (ListClient) // Khóa đồng bộ khi gửi tin nhắn tới tất cả Client
            {
                foreach (Socket client in ListClient)
                {
                    Send(client);
                }
            }
            AddMessege(tbmessage.Text);
            tbmessage.Clear();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Close();
        }
    }
}