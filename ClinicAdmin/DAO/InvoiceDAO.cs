using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAdmin.DAO
{
    public class InvoiceDAO
    {
        private static PatientDAO _instance;
        private double totalCost;
        private double examCost;
        private double drugCost;
        private DateTime created_at;

        public double TotalCost { get => totalCost; set => totalCost = value; }
        public double ExamCost { get => examCost; set => examCost = value; }
        public double DrugCost { get => drugCost; set => drugCost = value; }
        public DateTime Created_at { get => created_at; set => created_at = value; }

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
