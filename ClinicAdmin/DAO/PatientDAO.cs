using ClinicAdmin.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
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

        public int Id
        {
            get => id; set => id = value;
        }
        public string Fullname
        {
            get => fullname; set => fullname = value;
        }
        public string Address
        {
            get => address; set => address = value;
        }
        public string Phone
        {
            get => phone; set => phone = value;
        }
        public string Gender
        {
            get => gender; set => gender = value;
        }
        public int Age
        {
            get => age; set => age = value;
        }
        public int Weight
        {
            get => weight; set => weight = value;
        }

        public static PatientDAO getInstance()
        {
            if (_instance == null)
            {
                _instance = new PatientDAO();
            }
            return _instance;
        }

        public List<AppointmentDAO> GetListPatient()
        {
            List<AppointmentDAO> result = new List<AppointmentDAO>();
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                var entryPoint = (from pt in context.Patients
                                  join ap in context.Appointments on pt.Id equals ap.PatientId
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

        public Patient AddPatient(PatientDAO patientDAO)
        {
            Patient result = null;
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                var patient = new Patient()
                {
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

        public bool UpdatePatient(PatientDAO patientDAO)
        {
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                try
                {
                    var dbSet = context.Patients.SingleOrDefault(x => x.Id == patientDAO.Id);
                    if (dbSet != null)
                    {
                        dbSet.FullName = patientDAO.Fullname;
                        dbSet.Address = patientDAO.Address;
                        dbSet.Phone = patientDAO.Phone;
                        dbSet.Weight = patientDAO.Weight;
                        dbSet.Age = patientDAO.Age;
                        dbSet.Gender = patientDAO.Gender;
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            return true;
        }
    }
}
