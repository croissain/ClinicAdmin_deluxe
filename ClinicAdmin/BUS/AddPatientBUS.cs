using ClinicAdmin.DAO;
using System;
using System.Windows;

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

        public void AddPatient(string fullname, string gender, string age, string weight, string address, string phone, DateTime? dayExam, Window window)
        {
            if (fullname == "")
            {
                MessageBox.Show("Bạn cần nhập tên!");
            }
            else if (age == "")
            {
                MessageBox.Show("Bạn cần chọn tuổi!");
            }
            else if (weight == "")
            {
                MessageBox.Show("Bạn cần nhập cân nặng!");
            }
            else if (address == "")
            {
                MessageBox.Show("Bạn cần nhập địa chỉ!");
            }
            else if (phone == "")
            {
                MessageBox.Show("Bạn cần nhập số điện thoại!");
            }
            else if (dayExam == null)
            {
                MessageBox.Show("Bạn cần nhập ngày khám!");
            }
            else
            {
                PatientDAO patientDAO = new PatientDAO()
                {
                    Fullname = fullname,
                    Address = address,
                    Age = Int32.Parse(age),
                    Gender = gender,
                    Phone = phone
                };
                var patient = PatientDAO.getInstance().AddPatient(patientDAO);
                var appointment = AppointmentDAO.getInstance().AddApointment((DateTime)dayExam, patient.Id);
                HomeBUS.getInstance().listPatients = AppointmentDAO.getInstance().GetListPatient();
                window.Close();
            }
        }
    }
}
