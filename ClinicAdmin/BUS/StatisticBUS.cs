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

        public double SumProfit()
        {
            double result = 0;
            using(ClinicAdminEntities context = new ClinicAdminEntities())
            {
                result = (double)context.usp_SumProfit().FirstOrDefault().GetValueOrDefault();
            }
            return result;
        }

        public double SumProfitInMonth()
        {
            double result = 0;
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                result = (double)context.usp_SumProfitInMonth(DateTime.Today.Month, DateTime.Today.Year).FirstOrDefault().GetValueOrDefault();
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
    }
}
