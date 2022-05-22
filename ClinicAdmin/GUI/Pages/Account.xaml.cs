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
            if (MainWindowBUS.getInstance().userAccount != null)
            {
                txbUsername.Text = MainWindowBUS.getInstance().userAccount.Username;
                txbFullname.Text = MainWindowBUS.getInstance().userAccount.Fullname;
                txbEmail.Text = MainWindowBUS.getInstance().userAccount.Email;
                txbAddress.Text = MainWindowBUS.getInstance().userAccount.Address;
                txbPhone.Text = MainWindowBUS.getInstance().userAccount.Phone;
                txbRole.Text = MainWindowBUS.getInstance().userAccount.Role.Name;
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
