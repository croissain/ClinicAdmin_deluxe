using ClinicAdmin.BUS;
using System.Windows;

namespace ClinicAdmin.GUI
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Addnew : Window
    {
        private AddUserBUS _addUserBUS;
        public Addnew()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _addUserBUS = AddUserBUS.getInstance();
            cbbRole.ItemsSource = _addUserBUS.listRoles;
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string fullname = txbFullname.Text;
            string address = txbAddress.Text;
            string email = txbEmail.Text;
            string phone = txbPhone.Text;
            string username = txbUsername.Text;
            string pass = txbPassword.Password;
            string confirmPass = txbConfirmPass.Password;
            var role = cbbRole.SelectedItem;
            _addUserBUS.AddUser(fullname, address, email, phone, username, role, pass, confirmPass, this);
        }

    }
}
