﻿using ClinicAdmin.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAdmin.BUS
{
    public class MainWindowBUS
    {
        private static MainWindowBUS instance;
        public string username;
        public UserDAO userAccount;

        public static MainWindowBUS getInstance()
        {
            if (instance == null)
            {
                instance = new MainWindowBUS();
            }
            return instance;
            
        }

        public void BUSLayer_Loaded()
        {
            userAccount = UserFactory.GetUserLogin(username);
        }
    }
}
