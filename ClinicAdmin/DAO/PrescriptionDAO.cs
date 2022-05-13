using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAdmin.DAO
{
    public class PrescriptionDAO
    {
        private static PatientDAO _instance;
        private DateTime medicalExamDay;
        private string diagnose;
        private string medicalHistory;
        private string symptom;
        private string note;
        private DoctorDAO doctor;
        private StaffDAO staff;

        public DateTime MedicalExamDay { get => medicalExamDay; set => medicalExamDay = value; }
        public string Diagnose { get => diagnose; set => diagnose = value; }
        public string MedicalHistory { get => medicalHistory; set => medicalHistory = value; }
        public string Symptom { get => symptom; set => symptom = value; }
        public string Note { get => note; set => note = value; }
        public DoctorDAO Doctor { get => doctor; set => doctor = value; }
        public StaffDAO Staff { get => staff; set => staff = value; }

        public static PatientDAO getInstance()
        {
            if (_instance == null)
            {
                _instance = new PatientDAO();
            }
            return _instance;
        }
    }
}
