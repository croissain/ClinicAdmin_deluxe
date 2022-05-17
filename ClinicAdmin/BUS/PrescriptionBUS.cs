using ClinicAdmin.DAO;
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
        private PatientDAO patient;
        private string symptom;
        private string diagnose;
        private string medicalHistory;
        private string note;
        private string doctorName;
        private string staffName;
        private string totalCost;
        private List<Prescription_MedicineDAO> listMedicines;

        public string Symptom { get => symptom; set => symptom = value; }
        public string Diagnose { get => diagnose; set => diagnose = value; }
        public string MedicalHistory { get => medicalHistory; set => medicalHistory = value; }
        public string Note { get => note; set => note = value; }
        public string DoctorName { get => doctorName; set => doctorName = value; }
        public string StaffName { get => staffName; set => staffName = value; }
        public string TotalCost { get => totalCost; set => totalCost = value; }
        public PatientDAO Patient { get => patient; set => patient = value; }
        public List<Prescription_MedicineDAO> ListMedicines { get => listMedicines; set => listMedicines = value; }

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

        public void AddPrescription()
        {
            PrescriptionDAO prescriptionDAO = new PrescriptionDAO()
            {
                Diagnose = Diagnose,
                MedicalHistory = MedicalHistory,
                Symptom = Symptom,
                Note = Note,
                Patient = Patient,
                Doctor = DoctorName,
                Staff = StaffName,
            };
            var prescriptMedicine =  PrescriptionDAO.getInstance().AddPrescription(prescriptionDAO);
            prescriptionDAO.Id = prescriptMedicine.Id;
            foreach (var medicine in ListMedicines)
            {
                Prescription_MedicineDAO prescription_MedicineDAO = new Prescription_MedicineDAO()
                {
                    AmountDrug = medicine.AmountDrug,
                    Cost = medicine.Cost,
                    Unit = medicine.Unit,
                    Usage = medicine.Usage,
                    Medicine = medicine.Medicine,
                    Prescription = prescriptionDAO
                };
                Prescription_MedicineDAO.getInstance().AddPrescription(prescription_MedicineDAO);
            }
        }
    }
}
