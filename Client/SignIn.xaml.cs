using Client.Models;
using System;
using System.Collections.Generic;
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

namespace Client
{
    /// <summary>
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        public SignIn()
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

        private void btSignIn_Click(object sender, RoutedEventArgs e)
        {
            // Kiểm tra nhập đầy đủ thông tin
            if (!AllowUserName())
            {
                return;
            }
            else
            {
                string Email = txtEmail.Text.Trim();
                string PassWord = txtPassword.Password.Trim();
                using (var context = new MultichatContext())
                {
                    var NguoiDung = context.Nguoidungs.FirstOrDefault(u => u.Email == Email && u.Matkhau == PassWord); bool isUserFound = false; // Kiểm tra trạng thái đăng nhập
                    if (NguoiDung != null)
                    {
                        App.IdCurrentUser = NguoiDung.Mand;// Lưu mã người dùng để dùng cho quá trình cập nhật profile
                        isUserFound = true;
                        MainWindow mainwindow = new MainWindow();
                        mainwindow.Show();
                        this.Close();
                    }
                    // Không tìm thấy tài khoản nào khớp
                    if (!isUserFound)
                    {
                        MessageBox.Show("Email hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
        private bool AllowUserName()
        {
            if (txtEmail.Text.Trim().Length == 0)// Sự kiện chưa nhập tài khoản
            {
                MessageBox.Show("Bạn chưa nhập Email", "Cảnh Báo", MessageBoxButton.OK, MessageBoxImage.Error);
                txtEmail.Focus();
                return false; // Nếu chưa đăng nhập thông tin thì thoát
            }
            if (txtPassword.Password.Trim().Length == 0)// Sự kiện chưa nhập mật khẩu
            {
                MessageBox.Show("Bạn chưa nhập Password", "Cảnh Báo", MessageBoxButton.OK, MessageBoxImage.Error);
                txtPassword.Focus();
                return false;// Nếu chưa đăng nhập thông tin thì thoát
            }
            return true;
        }

        private void btSignUp_Click(object sender, RoutedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.Show();
            this.Close();
        }
    }
 }

