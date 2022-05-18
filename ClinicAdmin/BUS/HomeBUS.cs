using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ClinicAdmin.DAO;

namespace ClinicAdmin.BUS
{
    public class HomeBUS
    {
        private static HomeBUS _instance;
        public List<AppointmentDAO> listPatients;
        public List<Prescription_MedicineDAO> listMedicines;
        public PatientDAO patient;

        public static HomeBUS getInstance()
        {
            if (_instance == null)
            {
                _instance = new HomeBUS();
            }
            return _instance;
        }

        public void BUSLayer_Loaded()
        {
            listPatients = AppointmentDAO.getInstance().GetListPatient();
            listMedicines = new List<Prescription_MedicineDAO>();
        }

        public bool CheckIn(AppointmentDAO appointmentDAO)
        {
            if (appointmentDAO.Status == 1)
            {
                MessageBox.Show("Bệnh nhân này đã khám!", "Vào khám thất bại", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                AppointmentDAO.getInstance().CheckIn(appointmentDAO);
                listPatients.Remove(appointmentDAO);
                patient = appointmentDAO.Patient;
                return true;
            }
        }

        //public bool CheckOut(PatientDAO patient)
        //{
        //        ScheduleDAO.getInstance().CheckOut(patient.id, patient.ScheduleId);
        //        return true;
        //}

        public void PatientSearch(string patientName, DateTime? dateFrom, DateTime? dateTo)
        {
            if(dateFrom > dateTo)
            {
                MessageBox.Show("Ngày đến phải lớn hơn ngày từ!", "Lỗi ngày", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            dateFrom = dateFrom != null ? dateFrom : DateTime.MinValue;
            dateTo = dateTo != null ? dateTo : DateTime.MaxValue;
            listPatients = AppointmentDAO.getInstance().PatientSearch(patientName, dateFrom, dateTo);
        }

        public string GetTotalStorage()
        {
            string result = "";
            double totalStorage = MedicineDAO.getInstance().GetTotalStorage();
            if (totalStorage >= 100000)
            {
                totalStorage /= 1000;
                result = totalStorage.ToString() + 'k';
            }
            else
            {
                result = totalStorage.ToString();
            }
            return result;
        }

        public string TotalCost_ToString(List<Prescription_MedicineDAO> medicines)
        {
            double total = 0;
            foreach(var medicine in medicines)
            {
                total += medicine.Cost;
            }

            string result = total.ToString();
            result += " VND";
            return result;
        }

        public double TotalCost(List<Prescription_MedicineDAO> medicines)
        {
            double total = 0;
            foreach (var medicine in medicines)
            {
                total += medicine.Cost;
            }

            return total;
        }

        public void ExportInvoice(string patientName, string patientGender, string patientAge, string patientAddress, 
            string symptom, string diagnose, string medicalHistory, string note, string doctorName, string staffName)
        {
            PrescriptionBUS.getInstance().Patient = patient;
            PrescriptionBUS.getInstance().ListMedicines = listMedicines;
            PrescriptionBUS.getInstance().Symptom = symptom;
            PrescriptionBUS.getInstance().Diagnose = diagnose;
            PrescriptionBUS.getInstance().MedicalHistory = medicalHistory;
            PrescriptionBUS.getInstance().Note = note;
            PrescriptionBUS.getInstance().DoctorName = doctorName;
            PrescriptionBUS.getInstance().StaffName = staffName;
            PrescriptionBUS.getInstance().TotalCost = TotalCost(listMedicines);
            PrescriptionBUS.getInstance().AddPrescription();
            var screen = new ClinicAdmin.GUI.Prescription();
            screen.ShowDialog();
        }
    }
}
