using ClinicAdmin.GUI;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClinicAdmin.BUS;

namespace ClinicAdmin.Pages
{
    /// <summary>
    /// Interaction logic for Account.xaml
    /// </summary>
    public partial class Account : Page
    {
        private AccountBUS _accountBUS;
        public Account()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _accountBUS = AccountBUS.getInstance();
            if (_accountBUS.userAccount != null)
            {
                txbUsername.Text = _accountBUS.userAccount.Username;
                txbFullname.Text = _accountBUS.userAccount.FullName;
                txbEmail.Text = _accountBUS.userAccount.Email;
                txbAddress.Text = _accountBUS.userAccount.Address;
                txbPhone.Text = _accountBUS.userAccount.Phone;
                txbRole.Text = _accountBUS.userAccount.RoleName;
            }
        }

        private void BtnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            ChangePassword dialog = new ChangePassword();
            dialog.ShowDialog();
        }
    }
}
