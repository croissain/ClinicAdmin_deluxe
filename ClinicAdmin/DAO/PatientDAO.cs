using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAdmin.DTO;
namespace ClinicAdmin.DAO
{
    public class PatientDAO : Patient
    {
        private static PatientDAO instance;
        private string status;

        public string Status { get => status; set => status = value; }

        public PatientDAO() { }

        public PatientDAO(int id, string fullname, string address, string phone, int? weight, int? age, string gender, int? status)
        {
            this.id = id;
            this.FullName = fullname;
            this.Address = address;
            this.Phone = phone;
            this.Weight = weight;
            this.Age = age;
            this.Gender = gender;
            this.Status = status == 0 ? "Chưa khám" : "Đã khám";
        }

        public static PatientDAO getInstance()
        {
            if (instance == null)
            {
                instance = new PatientDAO();
            }
            return instance;
        }

        public List<PatientDAO> GetListPatient()
        {
            List<PatientDAO> result = new List<PatientDAO>();
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                var entryPoint = (from pt in context.Patients
                                  join sc in context.Schedules on pt.id equals sc.PatientId
                                  select new
                                  {
                                      id = pt.id,
                                      FullName = pt.FullName,
                                      Address = pt.Address,
                                      Phone = pt.Phone,
                                      Weight = pt.Weight,
                                      Age = pt.Age,
                                      Gender = pt.Gender,
                                      Status = sc.Status
                                  }).ToList();
                foreach(var item in entryPoint)
                {
                    PatientDAO patient = new PatientDAO(item.id, item.FullName, item.Address, item.Phone, item.Weight, item.Age, item.Gender, item.Status);
                    result.Add(patient);
                }
            }
            return result;
        }
    }
}
