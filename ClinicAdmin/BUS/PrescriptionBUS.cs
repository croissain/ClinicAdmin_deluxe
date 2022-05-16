using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAdmin.BUS
{
    public class PrescriptionBUS
    {
        private static PrescriptionBUS _instance;
        private string patientName;
        private string patientGender;
        private string patientAge;
        private string patientAddress;
        private string symptom;
        private string diagnose;
        private string medicalHistory;
        private string note;
        private string doctorName;
        private string staffName;
        private string totalCost;

        public string PatientName { get => patientName; set => patientName = value; }
        public string PatientGender { get => patientGender; set => patientGender = value; }
        public string PatientAge { get => patientAge; set => patientAge = value; }
        public string PatientAddress { get => patientAddress; set => patientAddress = value; }
        public string Symptom { get => symptom; set => symptom = value; }
        public string Diagnose { get => diagnose; set => diagnose = value; }
        public string MedicalHistory { get => medicalHistory; set => medicalHistory = value; }
        public string Note { get => note; set => note = value; }
        public string DoctorName { get => doctorName; set => doctorName = value; }
        public string StaffName { get => staffName; set => staffName = value; }
        public string TotalCost { get => totalCost; set => totalCost = value; }

        public static PrescriptionBUS getInstance()
        {
            if (_instance == null)
            {
                _instance = new PrescriptionBUS();
            }
            return _instance;
        }

        public void BUSLayer_Loaded()
        {
           
        }
    }
}
