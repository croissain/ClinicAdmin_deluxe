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
using ClinicAdmin.DAO;

namespace ClinicAdmin.Pages
{
    /// <summary>
    /// Interaction logic for Account.xaml
    /// </summary>
    public partial class Account : Page
    {
        private UserAccountDAO _userAccount;
        public Account(UserAccountDAO userAccountDAO)
        {
            InitializeComponent();
            _userAccount = userAccountDAO;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if(_userAccount != null)
            {
                txbUsername.Text = _userAccount.Username;
                txbFullname.Text = _userAccount.FullName;
                txbEmail.Text = _userAccount.Email;
                txbAddress.Text = _userAccount.Address;
                txbPhone.Text = _userAccount.Phone;
                txbRole.Text = _userAccount.Role;
            }
        }

        private void BtnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            ChangePassword dialog = new ChangePassword();
            dialog.ShowDialog();
        }
    }
}
