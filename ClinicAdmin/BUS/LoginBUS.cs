using ClinicAdmin.DAO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAdmin.BUS
{
    public class LoginBUS
    {
        public UserAccountDAO UserLogin(string username, string password)
        {
            UserAccountDAO userAccount = UserAccountDAO.getInstance();
            var user = userAccount.GetUserLogin(username, password);
            return user;
        }
    }
}
