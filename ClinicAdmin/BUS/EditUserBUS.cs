using ClinicAdmin.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClinicAdmin.BUS
{
    public class EditUserBUS
    {
        private static EditUserBUS _instance;
        private int userId;
        private UserDAO user;

        public UserDAO User { get => user; set => user = value; }
        public int UserId { get => userId; set => userId = value; }

        public static EditUserBUS getInstance()
        {
            if (_instance == null)
            {
                _instance = new EditUserBUS();
            }
            return _instance;
        }

        public void BUSLayer_Loaded()
        {
            user = UserFactory.GetUserById(UserId);
        }

        public void UpdateAccount(string username, string fullname, string address, string email, string phone)
        {
            UserDAO user = UserFactory.GetUser(fullname, address, email, phone, username, null, MainWindowBUS.getInstance().userAccount.Role.Id);
            if (UserFactory.UpdateAccount(user))
            {
                MessageBox.Show("Cập nhật thành công!");
            }
        }
    }
}
