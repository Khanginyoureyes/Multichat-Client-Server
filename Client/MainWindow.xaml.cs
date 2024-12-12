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
using Client.Models;
using System.IO;

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Connect();
            LoadUser();
        }

        // Nút gửi tin nhắn
        private void btSend_Click(object sender, EventArgs e)
        {
            if (client != null && client.Connected)
            {
                Send();
                AddMessage(tbmessage.Text);
            }
            else
            {
                MessageBox.Show("Không thể kết nối Server", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private IPEndPoint? IP;
        private Socket? client;

        // Hàm kết nối sever thông qua IP 127.0.0.1 (địa chỉ cục bộ) và port 6990
        private void Connect()
        {
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6990);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);// IPv4, TCP, xác định TCP protocol
            try
            {
                client.Connect(IP);
            }
            catch
            {
                MessageBox.Show("Không thể kết nối Server", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Thread listen = new Thread(Receive)// Tạo luồng Thread để liên tục lắng nghe server khi đã kết nối 
            {
                IsBackground = true // Cho phép luồng chạy nền
            };
            listen.Start(); 
        }


        private new void Close()
        {
            if (client != null)
            {
                client.Close();
                client = null;
            }
        }

        // Lắng nghe và nhận dữ liệu từ server gửi tới
        private void Receive()
        {
            try
            {
                while (client != null && client.Connected)
                {
                    byte[] buffer = new byte[1024 * 5000]; // Kích thước bộ đệm 5MB, lưu dữ liệu của server
                    int receivedBytes = client.Receive(buffer);
                    if (receivedBytes > 0)
                    {
                        try
                        {
                            string message = Deserialize<string>(buffer[..receivedBytes]);// Giải mã mảng byte thành chuỗi string
                            AddMessage(message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Không thể phân tích: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            catch
            {
                Close();
            }
        }

        // Hiển thị dữ liệu lên listview
        private void AddMessage(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                Dispatcher.Invoke(() => // Gửi yêu cầu cho luồng UI Thread cập nhật giao diện
                {
                    lvmessage.Items.Add(new ListViewItem { Content = message });
                    tbmessage.Clear();
                });
            }
        }

        // Gửi dữ liệu tin nhắn đã được chuyển đổi thành mảng byte đến server và các clinet khác    
        private void Send()
        {
            if (!string.IsNullOrWhiteSpace(tbmessage.Text) && client != null && client.Connected)
            {
                client.Send(Serialize($"{App.NameCurrentUser}: {tbmessage.Text}"));
            }
            else
            {
                Console.WriteLine("Socket đã đóng hoặc không thể kết nối");
            }
        }

        // Cắt tin nhắn thành mảng byte để gửi đi
        private static byte[] Serialize(object obj)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(obj); // Chuyển đổi đối tượng thành chuổi JSON
                return Encoding.UTF8.GetBytes(jsonString); // Chuyển đổi chuỗi JSON thành mảng byte
            } 
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
                return Array.Empty<byte>();
            }
        }

        // Tập hợp mảng byte để chuyển đổi thành tin nhắn
        private static T Deserialize<T>(byte[] data)
        {
            string jsonString = Encoding.UTF8.GetString(data);
            return JsonSerializer.Deserialize<T>(jsonString)!;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Close();
        }

        // Start: Close, Maximize, Minimize
        private void btMinimize_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Minimized;
            }
        }

        private void btMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }else
            {
                WindowState= WindowState.Normal;
            }    
        }

        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        // End: Close, Maximize, Minimize

        // Load profile của user khi đăng nhập
        private void LoadUser()
        {
            Nguoidung CurrentUser = null;
            using (var context = new MultichatContext())
            {
                var user = context.Nguoidungs.ToList();
                foreach (var item in user)
                {
                    if (item.Mand == App.IdCurrentUser)
                    {
                        CurrentUser = item;
                    }
                }
            }
            if (CurrentUser != null)
            {
                lbName.Content = CurrentUser.Tennd;
                lbNationality.Content = CurrentUser.Nationality;
                BitmapImage bitmap = new BitmapImage();
                using (MemoryStream stream = new MemoryStream(CurrentUser.Imageuser))
                {
                    bitmap.BeginInit();
                    bitmap.StreamSource = stream;
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();
                }
                elAvatar.Fill = new ImageBrush(bitmap);
            }
        }

        // Di chuyển được cửa sổ
        private void Client_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}