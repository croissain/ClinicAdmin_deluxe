using ClinicAdmin.DTO;
using System;

namespace ClinicAdmin.DAO
{
    public class PrescriptionDAO
    {
        private static PrescriptionDAO _instance;
        private int id;
        private DateTime medicalExamDay;
        private string diagnose;
        private string medicalHistory;
        private string symptom;
        private string note;
        private string doctor;
        private string staff;
        private PatientDAO patient;

        public DateTime MedicalExamDay
        {
            get => medicalExamDay; set => medicalExamDay = value;
        }
        public string Diagnose
        {
            get => diagnose; set => diagnose = value;
        }
        public string MedicalHistory
        {
            get => medicalHistory; set => medicalHistory = value;
        }
        public string Symptom
        {
            get => symptom; set => symptom = value;
        }
        public string Note
        {
            get => note; set => note = value;
        }
        public string Doctor
        {
            get => doctor; set => doctor = value;
        }
        public string Staff
        {
            get => staff; set => staff = value;
        }
        public PatientDAO Patient
        {
            get => patient; set => patient = value;
        }
        public int Id
        {
            get => id; set => id = value;
        }

        public static PrescriptionDAO getInstance()
        {
            if (_instance == null)
            {
                _instance = new PrescriptionDAO();
            }
            return _instance;
        }

        public Prescription AddPrescription(PrescriptionDAO prescriptionDAO)
        {
            Prescription result = null;
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                var prescription = new Prescription()
                {
                    Doctor = prescriptionDAO.Doctor,
                    Staff = prescriptionDAO.Staff,
                    PatientId = prescriptionDAO.Patient.Id,
                    MedicalExamDay = DateTime.Now,
                    Diagnose = prescriptionDAO.Diagnose,
                    Symptom = prescriptionDAO.Symptom,
                    Note = prescriptionDAO.Note,
                    MedicalHistory = prescriptionDAO.MedicalHistory
                };
                result = context.Prescriptions.Add(prescription);
                context.SaveChanges();
            }
            return result;
        }
    }
}
