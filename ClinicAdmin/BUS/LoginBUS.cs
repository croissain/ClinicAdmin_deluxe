using ClinicAdmin.DAO;
using ClinicAdmin.DTO;
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
            //var user = UserFactory.GetUserLogin(username, password);
            //if (user != null)
            //{
            //    MainWindow mainWindow = new MainWindow();
            //    HomeBUS.getInstance().userAccount = user;
            //    AccountBUS.getInstance().user = user;
            //    window.Close();
            //    mainWindow.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
            //}
            using(ClinicAdminEntities context = new ClinicAdminEntities())
            {
                int count = (int)context.usp_Login(username, password).FirstOrDefault();
                if (count == 1)
                {
                    MainWindow mainWindow = new MainWindow();
                    var user = UserFactory.GetUserLogin(username, password);
                    HomeBUS.getInstance().userAccount = user;
                    AccountBUS.getInstance().user = user;
                    mainWindow.ShowDialog();
                    window.Close();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
                }
            }
        }
    }
}
