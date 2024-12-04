using Client.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Client
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }

        // Đóng form
        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // Thu nhỏ form
        private void btMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        // Kiểm tra nhập đầy đủ thông tin
        private bool AllowUserName()
        {
            // Sự kiện chill fill đủ các ô 
            if (tbname.Text.Trim().Length == 0 ||  tbemail.Text.Trim().Length == 0 || tbpassword.Password.Trim().Length == 0 || tbagainpassword.Password.Trim().Length == 0 || cbnationnality.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Cảnh Báo", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                if (tbpassword.Password.Trim() != tbagainpassword.Password.Trim())
                {
                    MessageBox.Show("Hai mật khẩu không khớp. Vui lòng nhập lại!", "Cảnh Báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            return true;
        }
        // Tạo mã người dùng tăng dần
        private string CreateMaND(MultichatContext context)
        {
            int UserCount = context.Nguoidungs.Count();
            return $"ND{(UserCount + 1).ToString("D2")}";
        }
        // Thêm người dùng mới vào csdl
        private void btsignup_Click(object sender, RoutedEventArgs e)
        {
            // Kiểm tra nhập đầy đủ thông tin
            if (!AllowUserName())
            {
                return;
            }
            string HoTen = tbname.Text.Trim();
            string NationNality = cbnationnality.Text.Trim();
            string Gmail = tbemail.Text.Trim();
            string PassWord = tbpassword.Password.Trim();
            string AgainPassWord = tbagainpassword.Password.Trim();          
            // Lấy hình ảnh từ Ellipe
            ImageBrush imb = ImageEllipse.Fill as ImageBrush;
            BitmapImage bmi = imb?.ImageSource as BitmapImage;
            byte[] Avatar = CoversionAvatar(bmi);
            using (var context = new MultichatContext())
            {
                // Kiểm tra kích thước họ tên > 50
                if (HoTen.Length > 30)
                {
                    MessageBox.Show("Tên không vượt quá 30 ký tự!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    tbname.Focus();

                }
                else if (Avatar == null)
                {
                    MessageBox.Show("Vui lòng chọn ảnh đại diện!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    var existingUser = context.Nguoidungs.FirstOrDefault(u => u.Email == Gmail);
                    if (existingUser != null)// Kiểm tra Email đã tồn tại trong csdl
                    {
                        MessageBox.Show("Email hoặc Mật Khẩu đã tồn tại. Vui lòng nhập lại!", "Cảnh Báo", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        string MaND = CreateMaND(context);
                        Nguoidung NewUser = new Nguoidung()
                        {
                            Mand = MaND,
                            Tennd = HoTen,
                            Matkhau = PassWord,
                            Email = Gmail,
                            Nationality = NationNality,
                            Imageuser = Avatar
                        };
                        context.Nguoidungs.Add(NewUser);
                        context.SaveChanges();
                        MessageBox.Show("Đã đăng ký thành công!", "Thông Báo", MessageBoxButton.OK);
                        var signInWindow = new Client.SignIn();
                        signInWindow.Show();
                        this.Close();
                    }
                }
            }
        }
        // Chuyển đổi hình ảnh sang chuỗi binary
        private byte[] CoversionAvatar(BitmapImage bmi)
        {
            if (bmi == null)
                return null;
            else
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    PngBitmapEncoder encoder = new PngBitmapEncoder(); // chuyển đổi ảnh qua kiểu PNG
                    encoder.Frames.Add(BitmapFrame.Create(bmi));
                    encoder.Save(memoryStream);
                    return memoryStream.ToArray();
                }
            }
        }
        // Sự kiện thay đổi ảnh đại diện
        private void txtAvtChange_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog // Tạo đối tượng lưu ảnh
            {
                Filter = "Image Files (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp" // Giới hạn file
            };
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    BitmapImage bmi = new BitmapImage(new Uri(openFileDialog.FileName)); // Lấy URL cùa file ảnh gán vào bmi
                    ImageEllipse.Fill = new ImageBrush(bmi); // Đưa ảnh lên Ellipse
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải ảnh!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
