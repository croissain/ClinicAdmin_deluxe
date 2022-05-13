using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAdmin.DAO
{
    public class Prescription_MedicineDAO
    {
        private static Prescription_MedicineDAO _instance;
        private int amountDrug;
        private double cost;
        private string unit;
        private string usage;
        private MedicineDAO medicine;

        public int AmountDrug { get => amountDrug; set => amountDrug = value; }
        public double Cost { get => cost; set => cost = value; }
        public string Unit { get => unit; set => unit = value; }
        public string Usage { get => usage; set => usage = value; }
        public MedicineDAO Medicine { get => medicine; set => medicine = value; }

        public static Prescription_MedicineDAO getInstance()
        {
            if (_instance == null)
            {
                _instance = new Prescription_MedicineDAO();
            }
            return _instance;
        }
    }
}
