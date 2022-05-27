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
    public class StatisticBUS
    {
        private static StatisticBUS instance;

        public static StatisticBUS getInstance()
        {
            if (instance == null)
            {
                instance = new StatisticBUS();
            }
            return instance;
        }
    }
}
