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
        private PatientDAO _patientDAO;
        private StatisticBUS _statisticBUS;

        public Statistic()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _patientDAO = PatientDAO.getInstance();
            lsvPatient.ItemsSource = _patientDAO.GetListPatient();
        }

        private void btnRegulation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string patientName = txbPatientName.Text;
            DateTime? dateFrom = dpkFrom.SelectedDate;
            DateTime? dateTo = dpkTo.SelectedDate;

            _patientDAO.PatientSearch(patientName, dateFrom, dateTo);
            lsvPatient.ItemsSource = null;
            lsvPatient.Items.Clear();
            lsvPatient.ItemsSource = _patientDAO.GetListPatient();
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

        }
    }
}
