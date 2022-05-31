using ClinicAdmin.DAO;

namespace ClinicAdmin.BUS
{
    public class ReportBUS
    {
        private static ReportBUS _instance;
        private int totalMedicines;
        private int totalPatients;
        private int totaInvoice;
        private double sumProfit;
        private double profitInDay;
        private int patientInDay;
        private string reportPerson;
        private string description;
        private string purpose;

        public int TotalMedicines
        {
            get => totalMedicines; set => totalMedicines = value;
        }
        public int TotalPatients
        {
            get => totalPatients; set => totalPatients = value;
        }
        public int TotalInvoice
        {
            get => totaInvoice; set => totaInvoice = value;
        }
        public double SumProfit
        {
            get => sumProfit; set => sumProfit = value;
        }
        public double ProfitInDay
        {
            get => profitInDay; set => profitInDay = value;
        }
        public int PatientInDay
        {
            get => patientInDay; set => patientInDay = value;
        }
        public string ReportPerson
        {
            get => reportPerson; set => reportPerson = value;
        }
        public string Description
        {
            get => description; set => description = value;
        }
        public string Purpose
        {
            get => purpose; set => purpose = value;
        }

        public static ReportBUS getInstance()
        {
            if (_instance == null)
            {
                _instance = new ReportBUS();
            }
            return _instance;
        }

        public void BUSLayer_Loaded()
        {

        }

        //Them du lieu vao bang Report
        public void AddReport()
        {
            ReportDAO reportDAO = new ReportDAO()
            {
                TotalMedicines = TotalMedicines,
                TotalPatients = TotalPatients,
                TotalInvoice = TotalInvoice,
                SumProfit = SumProfit,
                ProfitInDay = ProfitInDay,
                ReportPerson = ReportPerson,
                Description = Description,
                Purpose = Purpose

            };
        }
    }
}
