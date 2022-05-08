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
using ClinicAdmin.BUS;

namespace ClinicAdmin
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void ButtonSignIn_Click(object sender, RoutedEventArgs e)
        {
            LoginBUS loginBUS = new LoginBUS();
            string userName = txbUsername.Text;
            string passWord = txbPassword.Password;
            var user = loginBUS.GetUserLogin(userName, passWord);
            
            if (user != null)
            {
                string roleName = loginBUS.GetRoleUser(user.id);
                MainWindow mainWindow = new MainWindow();
                mainWindow.userAccount = DAO.UserAccountDAO.getInstance(user.id, user.Username, user.Password, user.FullName, user.Address, user.Email, user.Phone, roleName);
                this.Hide();
                mainWindow.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát!", "Thông báo", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        // MacOS UI cheap moment
        // Button Close | Minimize | Restore
        private void WindowButton_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void WindowButton_Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void WindowButton_FullScreen_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txbUsername.Focus();
        }
    }
}
