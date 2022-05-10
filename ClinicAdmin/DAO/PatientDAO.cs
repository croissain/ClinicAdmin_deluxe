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
        private static PatientDAO _instance;
        private int status;
        private int scheduleId;

        public int Status { get => status; set => status = value; }
        public int ScheduleId { get => scheduleId; set => scheduleId = value; }

        public PatientDAO() { }

        public PatientDAO(int id, string fullname, string address, string phone, int? weight, int? age, string gender, int? status, int scheduleId)
        {
            this.id = id;
            this.FullName = fullname;
            this.Address = address;
            this.Phone = phone;
            this.Weight = weight;
            this.Age = age;
            this.Gender = gender;
            this.Status = (int)status;
            this.ScheduleId = scheduleId;
        }

        public static PatientDAO getInstance()
        {
            if (_instance == null)
            {
                _instance = new PatientDAO();
            }
            return _instance;
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
                                      ScheduleId = sc.id,
                                      Status = sc.Status
                                  }).ToList();
                foreach(var item in entryPoint)
                {
                    PatientDAO patient = new PatientDAO(item.id, item.FullName, item.Address, item.Phone, item.Weight, item.Age, item.Gender, item.Status, item.ScheduleId);
                    result.Add(patient);
                }
            }
            return result;
        }
    }
}
