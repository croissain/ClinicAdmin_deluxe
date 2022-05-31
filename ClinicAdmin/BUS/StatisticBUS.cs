using ClinicAdmin.DAO;
using ClinicAdmin.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClinicAdmin.BUS
{
    public class StatisticBUS
    {
        public List<AppointmentDAO> listPatients;
        private static StatisticBUS _instance;

        public static StatisticBUS getInstance()
        {
            if (_instance == null)
            {
                _instance = new StatisticBUS();
            }
            return _instance;
        }

        public void BUSLayer_Loaded()
        {
            listPatients = AppointmentDAO.getInstance().GetListPatient();
        }

        public int TotalMedicines()
        {
            int result = 0;
            double totalStorage = MedicineDAO.getInstance().GetTotalStorage();
            result = (int)totalStorage;
            return result;
        }

        //public int TotalInvoice()
        //{
        //    int result = 0;

        //    return result;
        //}

        public double SumProfit()
        {
            double result = 0;
            using(ClinicAdminEntities context = new ClinicAdminEntities())
            {
                result = (double)context.usp_SumProfit().FirstOrDefault().GetValueOrDefault();
            }
            return result;
        }

        public double SumProfitInMonth(int month, int year)
        {
            double result = 0;
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                result = (double)context.usp_SumProfitInMonth(month, year).FirstOrDefault().GetValueOrDefault();
            }
            return result;
        }

        public double ProfitInDay()
        {
            double result = 0;
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                result = (double)context.usp_ProfitInDay(DateTime.Today).FirstOrDefault().GetValueOrDefault();

            }
            return result;
        }

        public int PatientInDay()
        {
            int result = 0;
            using(ClinicAdminEntities context = new ClinicAdminEntities())
            {
                result = (int)context.usp_PatientInDay(DateTime.Today).FirstOrDefault().GetValueOrDefault();
            }
            return result;
        }

        public int PatientInMonth()
        {
            int result = 0;
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                result = (int)context.usp_PatientInMonth(DateTime.Today.Month, DateTime.Today.Year).FirstOrDefault().GetValueOrDefault();
            }
            return result;
        }

        public double MonthlyGrowth(int month, int year)
        {
            double result = 0;
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                double thisMonthProfit = 0;
                double previousMonthProfit = 0;
                if (month == 1)
                {
                    thisMonthProfit = (double)SumProfitInMonth(12, year);
                    previousMonthProfit = (double)SumProfitInMonth(12, year);
                } else
                {
                    thisMonthProfit = (double)SumProfitInMonth(month, year);
                    previousMonthProfit = (double)SumProfitInMonth(month-1, year);
                }

                result = Math.Round(((thisMonthProfit - previousMonthProfit) / previousMonthProfit) * 100, 2);
            }
            return result;
        }

        public void PatientSearch(string patientName, DateTime? dateFrom, DateTime? dateTo)
        {
            if (dateFrom > dateTo)
            {
                MessageBox.Show("Ngày đến phải lớn hơn ngày từ!", "Lỗi ngày", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            dateFrom = dateFrom != null ? dateFrom : DateTime.MinValue;
            dateTo = dateTo != null ? dateTo : DateTime.MaxValue;
            listPatients = AppointmentDAO.getInstance().PatientSearch(patientName, dateFrom, dateTo);
        }

        public void ExportReport(int totalMedicines,
          int totalPatients,
          int totaInvoice,
          double sumProfit,
          double profitInDay,
          int patientInDay,
          string reportPerson,
          string description,
          string purpose)
        {
            ReportBUS.getInstance().TotalMedicines = TotalMedicines(); 
            ReportBUS.getInstance().TotalPatients = PatientInMonth();
            ReportBUS.getInstance().TotalInvoice = PatientInMonth();
            ReportBUS.getInstance().SumProfit = sumProfit;
            ReportBUS.getInstance().ProfitInDay = profitInDay;
            ReportBUS.getInstance().PatientInDay = patientInDay;
            ReportBUS.getInstance().ReportPerson = reportPerson;
            ReportBUS.getInstance().Description = description;
            ReportBUS.getInstance().Purpose = purpose;
            ReportBUS.getInstance().AddReport();
            var screen = new ClinicAdmin.GUI.Report();
            screen.ShowDialog();
        }

        public void CancleAppoint(int id)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn huỷ lịch hẹn này?", "Xóa lịch hẹn", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if (AppointmentDAO.getInstance().RemoveAppointment(id))
                {
                    MessageBox.Show("Hủy thành công!");
                }
            }
        }

    }
}
