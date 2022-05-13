using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAdmin.DAO
{
    public class DoctorDAO : UserDAO
    {
        private static DoctorDAO _instance;

        public static DoctorDAO getInstance()
        {
            if (_instance == null)
            {
                _instance = new DoctorDAO();
            }
            return _instance;
        }

        public DoctorDAO() { }

        public DoctorDAO(int id, string userName, string password, string fullname, string address, string email, string phone)
        {
            this.Id = id;
            this.Username = userName;
            this.Password = password;
            this.Fullname = fullname;
            this.Address = address;
            this.Email = email;
            this.Phone = phone;
        }

        public override bool AddAccountUser()
        {
            throw new NotImplementedException();
        }

        public override bool ChangeRegulation()
        {
            throw new NotImplementedException();
        }

        public override bool AddPatient(PatientDAO patientDAO)
        {
            throw new NotImplementedException();
        }

        public override bool AddPrescription()
        {
            throw new NotImplementedException();
        }

        public override string GetRole()
        {
            return "Bác sĩ";
        }
    }
}
