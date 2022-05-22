using ClinicAdmin.DAO;
using ClinicAdmin.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Security.Cryptography;
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
            using(ClinicAdminEntities context = new ClinicAdminEntities())
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                string hasPass = "";
                byte[] buffer = ASCIIEncoding.ASCII.GetBytes(password);
                byte[] hasData = md5.ComputeHash(buffer);

                foreach(var item in hasData)
                {
                    hasPass += item;
                }
                
                int count = (int)context.usp_Login(username, hasPass).FirstOrDefault();
                if (count == 1)
                {
                    MainWindow mainWindow = new MainWindow();
                    MainWindowBUS.getInstance().username = username;
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
}
