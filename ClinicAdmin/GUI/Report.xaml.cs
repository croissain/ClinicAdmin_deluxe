using ClinicAdmin.BUS;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ClinicAdmin.GUI
{
    /// <summary>
    /// Interaction logic for Prescription.xaml
    /// </summary>
    public partial class Report : Window
    {
        private ReportBUS _reportBUS;
        private StatisticBUS _statisticBUS;

        public Report()
        {
            InitializeComponent();
        }

        private void ExportPrescription_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "Prescription");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _reportBUS = ReportBUS.getInstance();
            _statisticBUS = StatisticBUS.getInstance();
            txblPatientAmount.Text = _statisticBUS.PatientInMonth().ToString();
            txblDailyProfit.Text = _statisticBUS.ProfitInDay().ToString();
            txblMonthlyProfit.Text = _statisticBUS.SumProfitInMonth(DateTime.Today.Month, DateTime.Today.Year).ToString();
            txblPercent.Text = _statisticBUS.MonthlyGrowth(DateTime.Today.Month, DateTime.Today.Year).ToString();

            txblTotalInvoices.Text = _reportBUS.TotalInvoice.ToString();
            txblTotalPatients.Text = _reportBUS.TotalPatients.ToString();
            txblTotalMedicines.Text = _reportBUS.TotalMedicines.ToString();
            txblDay.Text = DateTime.Now.ToString("dd");
            txblMonth.Text = DateTime.Now.ToString("MM");
            txblYear.Text = DateTime.Now.ToString("yyyy");
        }
    }
}
