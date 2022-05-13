using ClinicAdmin.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAdmin.DAO
{
    public class StaffDAO : UserDAO
    {
        private static StaffDAO _instance;

        public static StaffDAO getInstance()
        {
            if (_instance == null)
            {
                _instance = new StaffDAO();
            }
            return _instance;
        }

        public StaffDAO() { }

        public StaffDAO(int id, string userName, string password, string fullname, string address, string email, string phone)
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
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                Patient patient = new Patient()
                {
                    Id = patientDAO.Id,
                    FullName = patientDAO.Fullname,
                    Address = patientDAO.Address,
                    Phone = patientDAO.Phone,
                    Weight = patientDAO.Weight,
                    Age = patientDAO.Age,
                    Gender = patientDAO.Gender
                };
                if (context.Patients.Add(patient) != null)
                    return true;
                else
                    return false;
            }
        }

        public override bool AddPrescription()
        {
            throw new NotImplementedException();
        }

        public override string GetRole()
        {
            return "Nhân viên";
        }
    }
}
