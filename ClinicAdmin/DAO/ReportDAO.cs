using ClinicAdmin.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAdmin.DAO
{
    public class ReportDAO
    {
        private static ReportDAO _instance;
        private int totalMedicines;
        private int totalPatients;
        private int totaInvoice;
        private double sumProfit;
        private double profitInDay;
        private int patientInDay;
        private string reportPerson;
        private string description;
        private string purpose;

        public int TotalMedicines { get => totalMedicines; set => totalMedicines = value; }
        public int TotalPatients { get => totalPatients; set => totalPatients = value; }
        public int TotalInvoice { get => totaInvoice; set => totaInvoice = value; }
        public double SumProfit { get => sumProfit; set => sumProfit = value; }
        public double ProfitInDay { get => profitInDay; set => profitInDay = value; }
        public int PatientInDay { get => patientInDay; set => patientInDay = value; }
        public string ReportPerson { get => reportPerson; set => reportPerson = value; }
        public string Description { get => description; set => description = value; }
        public string Purpose { get => purpose; set => purpose = value; }
    

        public static ReportDAO getInstance()
        {
            if (_instance == null)
            {
                _instance = new ReportDAO();
            }
            return _instance;
        }

        public Report AddReport(ReportDAO ReportDAO)
        {
            Report result = null;
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                var report = new Report()
                {
                    TotalMedicines = ReportDAO.TotalMedicines,
                    TotalPatients = ReportDAO.TotalPatients,
                    TotalInvoice = ReportDAO.TotalInvoice,
                    SumProfit = ReportDAO.SumProfit,
                    ProfitInDay = ReportDAO.ProfitInDay,
                    PatientInDay = ReportDAO.PatientInDay,
                    ReportPerson = ReportDAO.ReportPerson,
                    Created_at = DateTime.Now,
                    Descript = ReportDAO.Description,
                    Purpose = ReportDAO.Purpose
                };
                result = context.Reports.Add(report);
                context.SaveChanges();
            }
            return result;
        }
    }
}
