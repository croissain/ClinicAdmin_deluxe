using ClinicAdmin.BUS;
using ClinicAdmin.GUI;
using System.Windows;
using System.Windows.Controls;

namespace ClinicAdmin.Pages
{
    /// <summary>
    /// Interaction logic for Account.xaml
    /// </summary>
    public partial class Account : Page
    {
        private MainWindowBUS _mainWindowBUS;
        private AccountBUS _accountBUS;
        public Account()
        {
            InitializeComponent();
        }

        public string IntialName(string name)
        {
            string FirstIntial = name.Substring(0, 1);
            string LastIntial = "";
            for (int i = name.Length - 1; i > 0; i--)
            {
                if (name[i] == ' ')
                {
                    LastIntial = name[i + 1].ToString();
                    break;
                }
            }
            return FirstIntial + LastIntial;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _accountBUS = AccountBUS.getInstance();
            _mainWindowBUS = MainWindowBUS.getInstance();
            if (MainWindowBUS.getInstance().userAccount != null)
            {
                txbUsername.Text = MainWindowBUS.getInstance().userAccount.Username;
                txbFullname.Text = MainWindowBUS.getInstance().userAccount.Fullname;
                txbEmail.Text = MainWindowBUS.getInstance().userAccount.Email;
                txbAddress.Text = MainWindowBUS.getInstance().userAccount.Address;
                txbPhone.Text = MainWindowBUS.getInstance().userAccount.Phone;
                txbRole.Text = MainWindowBUS.getInstance().userAccount.Role.Name;
                txblUserInitial.Text = IntialName(_mainWindowBUS.userAccount.Fullname);
            }
        }

        private void BtnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            ChangePassword dialog = new ChangePassword();
            dialog.ShowDialog();
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            string username = txbUsername.Text;
            string fulname = txbFullname.Text;
            string address = txbAddress.Text;
            string email = txbEmail.Text;
            string phone = txbPhone.Text;

            _accountBUS.UpdateAccount(username, fulname, address, email, phone);
        }
    }
}
