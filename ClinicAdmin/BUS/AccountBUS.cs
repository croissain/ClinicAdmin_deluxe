using ClinicAdmin.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAdmin.BUS
{
    public class AccountBUS
    {
        private static AccountBUS instance;
        public UserDAO user;

        public static AccountBUS getInstance()
        {
            if (instance == null)
            {
                instance = new AccountBUS();
            }
            return instance;
        }
    }
}
