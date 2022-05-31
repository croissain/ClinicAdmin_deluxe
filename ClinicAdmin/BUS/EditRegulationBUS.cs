using ClinicAdmin.DAO;
using System;
using System.Windows;

namespace ClinicAdmin.BUS
{
    public class EditRegulationBUS
    {
        private static EditRegulationBUS _instance;
        private int appointmentId;
        private AppointmentDAO appointment;

        public int AppointmentId
        {
            get => appointmentId; set => appointmentId = value;
        }
        public AppointmentDAO Appointment
        {
            get => appointment; set => appointment = value;
        }

        public static EditRegulationBUS getInstance()
        {
            if (_instance == null)
            {
                _instance = new EditRegulationBUS();
            }
            return _instance;
        }

        public void BUSLayer_Loaded()
        {
            appointment = AppointmentDAO.getInstance().GetAppointmentById(appointmentId);
        }

        public void UpdateRecord(string fullname, string gender, string address, string age, string weight, string phone, DateTime? dayExam)
        {
            if (fullname == "" || address == "" || phone == "" || age == "" || weight == "")
            {
                MessageBox.Show("Bạn cần nhập đầy đủ thông tin");
                return;
            }
            PatientDAO patient = new PatientDAO()
            {
                Id = Appointment.Patient.Id,
                Fullname = fullname,
                Address = address,
                Age = Int32.Parse(age),
                Weight = Int32.Parse(weight),
                Gender = gender,
                Phone = phone
            };

            AppointmentDAO appointment = new AppointmentDAO()
            {
                Id = AppointmentId,
                Status = Appointment.Status,
                AppointmentDay = (DateTime)dayExam,
                Patient = patient
            };

            if (PatientDAO.getInstance().UpdatePatient(patient) && AppointmentDAO.getInstance().UpdateAppointment(appointment))
            {
                MessageBox.Show("Cập nhật thành công!");
            }
        }
    }
}
