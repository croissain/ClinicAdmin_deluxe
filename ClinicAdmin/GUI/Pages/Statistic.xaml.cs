using ClinicAdmin.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClinicAdmin.BUS;
using ClinicAdmin.GUI;

namespace ClinicAdmin.GUI.Pages
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Statistic : Page
    {
        private StatisticBUS _statisticBUS; 
        private ReportBUS _reportBUS;
        private MainWindowBUS _mainWindowBUS;

        public Statistic()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _statisticBUS = StatisticBUS.getInstance();
            _reportBUS = ReportBUS.getInstance();
            _mainWindowBUS = MainWindowBUS.getInstance();
            _statisticBUS.BUSLayer_Loaded();
            lsvPatient.ItemsSource = _statisticBUS.listPatients;
            txblTotalMedicines.Text = _reportBUS.TotalMedicines.ToString();
            txblTotalPatients.Text = _reportBUS.TotalPatients.ToString();
            txblTotalInvoices.Text = _reportBUS.TotalInvoice.ToString();
            lbSumProfit.Content = _statisticBUS.SumProfitInMonth(DateTime.Today.Month, DateTime.Today.Year).ToString();
            lbPatientInDay.Content = _statisticBUS.PatientInDay().ToString();
            lbProfitInDay.Content = _statisticBUS.ProfitInDay().ToString();
        }

        private void btnRegulation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string patientName = txbPatientName.Text;
            DateTime? dateFrom = dpkFrom.SelectedDate;
            DateTime? dateTo = dpkTo.SelectedDate;

            _statisticBUS.PatientSearch(patientName, dateFrom, dateTo);
            lsvPatient.ItemsSource = null;
            lsvPatient.Items.Clear();
            lsvPatient.ItemsSource = _statisticBUS.listPatients;
        }

        private void btnClearSearch_Click(object sender, RoutedEventArgs e)
        {
            txbPatientName.Text = "";
            dpkFrom.SelectedDate = null;
            dpkTo.SelectedDate = null;

            btnSearch_Click(sender, e);
        }

        private void ExportReport_Click(object sender, RoutedEventArgs e)
        {
            int totalMedicines = Convert.ToInt32(txblTotalMedicines.Text);
            int totalPatients = Convert.ToInt32(txblTotalPatients.Text);
            int totaInvoice = Convert.ToInt32(txblTotalInvoices.Text);
            double sumProfit = Convert.ToDouble(lbSumProfit.Content.ToString());
            double profitInDay = Convert.ToDouble(lbProfitInDay.Content.ToString());
            int patientInDay = Convert.ToInt32(_reportBUS.PatientInDay.ToString());
            string reportPerson = _mainWindowBUS.userAccount.Fullname;
            string description = "";
            string purpose = "";
            _statisticBUS.ExportReport(
                totalMedicines,
                totalPatients,
                totaInvoice,
                sumProfit,
                profitInDay,
                patientInDay,
                reportPerson,
                description,
                purpose
            );
        }
    }
}
