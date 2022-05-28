using ClinicAdmin.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClinicAdmin.DAO
{
    public class AppointmentDAO
    {
        private static AppointmentDAO _instance;
        private int id;
        private DateTime appointmentDay;
        private int status;
        private PatientDAO patient;

        public int Id { get => id; set => id = value; }
        public DateTime AppointmentDay { get => appointmentDay; set => appointmentDay = value; }
        public int Status { get => status; set => status = value; }
        public PatientDAO Patient { get => patient; set => patient = value; }

        public static AppointmentDAO getInstance()
        {
            if (_instance == null)
            {
                _instance = new AppointmentDAO();
            }
            return _instance;
        }

        public void CheckIn(AppointmentDAO appointmentDAO)
        {
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                var appointment = new Appointment() { Id = appointmentDAO.Id, PatientId = appointmentDAO.Patient.Id, Status = 1 };
                context.Appointments.Attach(appointment);
                context.Entry(appointment).Property(x => x.Status).IsModified = true;
                context.SaveChanges();
            }
        }

        public List<AppointmentDAO> GetListPatient()
        {
            List<AppointmentDAO> result = new List<AppointmentDAO>();
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                var entryPoint = (from pt in context.Patients
                                  join ap in context.Appointments on pt.Id equals ap.PatientId
                                  where ap.Status == 0
                                  select new
                                  {
                                      patientId = pt.Id,
                                      FullName = pt.FullName,
                                      Address = pt.Address,
                                      Phone = pt.Phone,
                                      Weight = pt.Weight,
                                      Age = pt.Age,
                                      Gender = pt.Gender,
                                      appId = ap.Id,
                                      Day = ap.AppointmentDay,
                                      Status = ap.Status

                                  }).ToList();
                foreach (var item in entryPoint)
                {
                    PatientDAO patient = new PatientDAO()
                    {
                        Id = item.patientId,
                        Fullname = item.FullName,
                        Address = item.Address,
                        Phone = item.Phone,
                        Weight = item.Weight,
                        Age = item.Age,
                        Gender = item.Gender
                    };
                    AppointmentDAO appointment = new AppointmentDAO()
                    {
                        Id = item.appId,
                        AppointmentDay = item.Day,
                        Status = item.Status,
                        Patient = patient
                    };

                    result.Add(appointment);
                }
            }
            return result;
        }

        public List<AppointmentDAO> PatientSearch(string patientName, DateTime? dateFrom, DateTime? dateTo)
        {
            List<AppointmentDAO> result = new List<AppointmentDAO>();
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                var entryPoint = (from pt in context.Patients
                                  join ap in context.Appointments on pt.Id equals ap.PatientId
                                  where pt.FullName.Contains(patientName) && ap.AppointmentDay >= dateFrom && ap.AppointmentDay <= dateTo
                                  select new
                                  {
                                      patientId = pt.Id,
                                      FullName = pt.FullName,
                                      Address = pt.Address,
                                      Phone = pt.Phone,
                                      Weight = pt.Weight,
                                      Age = pt.Age,
                                      Gender = pt.Gender,
                                      appId = ap.Id,
                                      Day = ap.AppointmentDay,
                                      Status = ap.Status

                                  }).ToList();
                foreach (var item in entryPoint)
                {
                    PatientDAO patient = new PatientDAO()
                    {
                        Id = item.patientId,
                        Fullname = item.FullName,
                        Address = item.Address,
                        Phone = item.Phone,
                        Weight = item.Weight,
                        Age = item.Age,
                        Gender = item.Gender
                    };
                    AppointmentDAO appointment = new AppointmentDAO()
                    {
                        Id = item.appId,
                        AppointmentDay = item.Day,
                        Status = item.Status,
                        Patient = patient
                    };

                    result.Add(appointment);
                }
            }
            return result;
        }

        public Appointment AddApointment(DateTime dayExam, int patientId)
        {
            Appointment result = null;
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                var appointment = new Appointment() 
                { 
                    PatientId = patientId, 
                    Status = 0,
                    AppointmentDay = dayExam
                };
                result = context.Appointments.Add(appointment);
                context.SaveChanges();
            }
            return result;
        }

        public bool RemoveAppointment(int id)
        {
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                var appointment = new Appointment { Id = id };
                try
                {
                    context.Appointments.Attach(appointment);
                    context.Appointments.Remove(appointment);
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi:" + ex.Message);
                    return false;
                }
            }
        }
    }
}
