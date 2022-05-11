using ClinicAdmin.DAO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClinicAdmin.BUS
{
    public class LoginBUS
    {
        private static LoginBUS instance;

        public static LoginBUS getInstance()
        {
            if (instance == null)
            {
                instance = new LoginBUS();
            }
            return instance;
        }

        public void UserLogin(string username, string password, Window window)
        {
            UserAccountDAO userAccount = UserAccountDAO.getInstance();
            var user = userAccount.GetUserLogin(username, password);
            if (user != null)
            {
                MainWindow mainWindow = new MainWindow();
                HomeBUS.getInstance().userAccount = user;
                AccountBUS.getInstance().userAccount = user;
                window.Close();
                mainWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
            }
        }
    }
}
