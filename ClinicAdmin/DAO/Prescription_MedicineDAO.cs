using ClinicAdmin.DTO;

namespace ClinicAdmin.DAO
{
    public class Prescription_MedicineDAO
    {
        private static Prescription_MedicineDAO _instance;
        private int amountDrug;
        private double cost;
        private UnitMedicineDAO unit;
        private UsageMedicineDAO usage;
        private MedicineDAO medicine;
        private PrescriptionDAO prescription;

        public int AmountDrug
        {
            get => amountDrug; set => amountDrug = value;
        }
        public double Cost
        {
            get => cost; set => cost = value;
        }
        public MedicineDAO Medicine
        {
            get => medicine; set => medicine = value;
        }
        public PrescriptionDAO Prescription
        {
            get => prescription; set => prescription = value;
        }
        public UnitMedicineDAO Unit
        {
            get => unit; set => unit = value;
        }
        public UsageMedicineDAO Usage
        {
            get => usage; set => usage = value;
        }

        public static Prescription_MedicineDAO getInstance()
        {
            if (_instance == null)
            {
                _instance = new Prescription_MedicineDAO();
            }
            return _instance;
        }

        public Prescription_Medicine AddPrescription(Prescription_MedicineDAO prescriptionMedicine)
        {
            Prescription_Medicine result = null;
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                var entry = new Prescription_Medicine()
                {
                    PrescriptionId = prescriptionMedicine.Prescription.Id,
                    MedicineId = prescriptionMedicine.Medicine.Id,
                    AmountDrug = prescriptionMedicine.AmountDrug,
                    Cost = prescriptionMedicine.Cost,
                    Unit = prescriptionMedicine.Unit.Id,
                    Usage = prescriptionMedicine.Usage.Id

                };
                result = context.Prescription_Medicine.Add(entry);
                context.SaveChanges();
            }
            return result;
        }
    }
}
