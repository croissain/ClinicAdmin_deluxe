using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAdmin.BUS
{
    public class AddPatientBUS
    {
        private static AddPatientBUS _instance;

        public static AddPatientBUS getInstance()
        {
            if (_instance == null)
            {
                _instance = new AddPatientBUS();
            }
            return _instance;
        }

        public void AddPatient()
        {

        }
    }
}
