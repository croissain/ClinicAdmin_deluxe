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
        public UserAccountDAO userAccount;
        public List<PatientDAO> listPatients;
        public List<MedicineDAO> listMedicines;

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
            listPatients = PatientDAO.getInstance().GetListPatient();
            listMedicines = new List<MedicineDAO>();
        }

        public bool CheckIn(PatientDAO patient)
        {
            if(patient.Status == 1)
            {
                MessageBox.Show("Bệnh nhân này đã khám!", "Vào khám thất bại", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                ScheduleDAO.getInstance().CheckIn(patient.id, patient.ScheduleId);
                listPatients.Remove(patient);
                return true;
            }
        }

        public void PatientSearch(string patientName, DateTime? dateFrom, DateTime? dateTo)
        {
            if(dateFrom > dateTo)
            {
                MessageBox.Show("Ngày đến phải lớn hơn ngày từ!", "Lỗi ngày", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            dateFrom = dateFrom != null ? dateFrom : DateTime.MinValue;
            dateTo = dateTo != null ? dateTo : DateTime.MaxValue;
            listPatients = PatientDAO.getInstance().PatientSearch(patientName, dateFrom, dateTo);
        }
    }
}
