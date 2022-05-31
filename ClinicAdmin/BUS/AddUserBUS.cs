using ClinicAdmin.DAO;
using System.Collections.Generic;
using System.Windows;

namespace ClinicAdmin.BUS
{
    public class AddUserBUS
    {
        private static AddUserBUS _instance;
        public List<RoleDAO> listRoles;

        public static AddUserBUS getInstance()
        {
            if (_instance == null)
            {
                _instance = new AddUserBUS();
                _instance.listRoles = RoleDAO.getInstance().GetListRole();

            }
            return _instance;
        }

        public void AddUser(string fullname, string address, string email, string phone, string username, object roleObj, string pass, string confirmPass, Window window)
        {
            RoleDAO role = roleObj as RoleDAO;

            if (pass != confirmPass)
            {
                MessageBox.Show("Mật khẩu không trùng khớp!");
            }
            else if (username == "")
            {
                MessageBox.Show("Tên đăng nhập không được để trống");
            }
            else
            {
                UserDAO user = UserFactory.GetUser(fullname, address, email, phone, username, pass, role.Id);
                if (UserFactory.AddUser(user, role.Id))
                {
                    MessageBox.Show("Thêm tài khoản thành công");
                }
                else
                {
                    MessageBox.Show("Thêm tài khoản thất bại", "Thất bại", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                window.Close();
            }
        }
    }
}
