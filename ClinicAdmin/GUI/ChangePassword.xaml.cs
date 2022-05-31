using ClinicAdmin.BUS;
using System.Windows;

namespace ClinicAdmin.GUI
{
    /// <summary>
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txbUsername.Text = MainWindowBUS.getInstance().userAccount.Username;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            string pass = txbPassword.Password;
            string confirmPass = txbConfirmPass.Password;
            AccountBUS.getInstance().ChangePassword(pass, confirmPass);
            this.Close();
        }
    }
}
