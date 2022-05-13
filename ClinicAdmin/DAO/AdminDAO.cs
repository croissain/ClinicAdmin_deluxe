using ClinicAdmin.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAdmin.DAO
{
    public class AdminDAO : UserDAO
    {
        private static AdminDAO _instance;

        public static AdminDAO getInstance()
        {
            if (_instance == null)
            {
                _instance = new AdminDAO();
            }
            return _instance;
        }

        public AdminDAO() { }

        public AdminDAO(int id, string userName, string password, string fullname, string address, string email, string phone)
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
            return "Quản trị";
        }
    }
}
