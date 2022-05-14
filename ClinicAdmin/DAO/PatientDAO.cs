using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAdmin.DTO;
namespace ClinicAdmin.DAO
{
    public class PatientDAO
    {
        private static PatientDAO _instance;
        private int id;
        private string fullname;
        private string address;
        private string phone;
        private string gender;
        private int age;
        private int weight;

        public int Id { get => id; set => id = value; }
        public string Fullname { get => fullname; set => fullname = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Gender { get => gender; set => gender = value; }
        public int Age { get => age; set => age = value; }
        public int Weight { get => weight; set => weight = value; }

        public static PatientDAO getInstance()
        {
            if (_instance == null)
            {
                _instance = new PatientDAO();
            }
            return _instance;
        }

        public Patient AddPatient(PatientDAO patientDAO)
        {
            Patient result = null;
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                var patient = new Patient() 
                { 
                    Id = patientDAO.Id, 
                    FullName = patientDAO.Fullname,
                    Address = patientDAO.Address,
                    Age = patientDAO.Age,
                    Phone = patientDAO.Phone,
                    Weight = patientDAO.Weight,
                    Gender = patientDAO.Gender
                };
                result = context.Patients.Add(patient);
                context.SaveChanges();
            }
            return result;
        }
    }
}
