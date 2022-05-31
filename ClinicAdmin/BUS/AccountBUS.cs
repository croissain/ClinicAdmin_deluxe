using ClinicAdmin.DAO;
using System.Windows;

namespace ClinicAdmin.BUS
{
    public class AccountBUS
    {
        private static AccountBUS _instance;

        public static AccountBUS getInstance()
        {
            if (_instance == null)
            {
                _instance = new AccountBUS();
            }
            return _instance;
        }

        public void UpdateAccount(string username, string fullname, string address, string email, string phone)
        {
            UserDAO user = UserFactory.GetUser(fullname, address, email, phone, username, null, MainWindowBUS.getInstance().userAccount.Role.Id);
            if (UserFactory.UpdateAccount(user))
            {
                MessageBox.Show("Cập nhật thành công!");
            }
        }

        public void ChangePassword(string password, string confirmPass)
        {
            if (password != confirmPass)
            {
                MessageBox.Show("Mật khẩu không trùng khớp!");
                return;
            }
            if (UserFactory.ChangePassword(password, MainWindowBUS.getInstance().userAccount.Id))
            {
                MessageBox.Show("Cập nhật thành công!");
            }
        }
    }
}
