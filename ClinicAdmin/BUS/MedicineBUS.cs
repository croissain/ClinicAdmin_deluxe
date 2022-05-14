using ClinicAdmin.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAdmin.BUS
{
    public class MedicineBUS
    {
        private static MedicineBUS instance;
        public MedicineDAO user;

        public static MedicineBUS getInstance()
        {
            if (instance == null)
            {
                instance = new MedicineBUS();
            }
            return instance;
        }
    }
}
