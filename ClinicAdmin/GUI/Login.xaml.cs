using ClinicAdmin.BUS;
using System.Windows;

namespace ClinicAdmin
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private LoginBUS _loginBUS;
        public Login()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _loginBUS = LoginBUS.getInstance();
            txbUsername.Focus();
        }

        private void ButtonSignIn_Click(object sender, RoutedEventArgs e)
        {
            string userName = txbUsername.Text;
            string passWord = txbPassword.Password;
            _loginBUS.UserLogin(userName, passWord, this);
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
    }
}
