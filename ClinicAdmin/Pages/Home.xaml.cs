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

namespace ClinicAdmin.Pages
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        private HomeBUS _homeBUS;

        public Home()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _homeBUS = HomeBUS.getInstance();
            if (_homeBUS.userAccount != null)
            {
                txblStaffName.Text = _homeBUS.userAccount.FullName;
            }

            _homeBUS.BUSLayer_Loaded();
            lsvPatient.ItemsSource = _homeBUS.listPatients;
        }

        private void AddMedicine_Click(object sender, RoutedEventArgs e)
        {
            if (txblFullname.Text != "")
            {
                AddMedicine dialog = new AddMedicine();
                dialog.ShowDialog();
                lstvMedicines.ItemsSource = null;
                lstvMedicines.Items.Clear();
                lstvMedicines.ItemsSource = _homeBUS.listMedicines;
            }
            else
            {
                MessageBox.Show("Hãy chọn bệnh nhân trước", "Thêm thuốc không thành công", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddPatient_Click(object sender, RoutedEventArgs e)
        {
            AddPatient dialog = new AddPatient();
            dialog.ShowDialog();
        }

        private void ExportInvoice_Click(object sender, RoutedEventArgs e)
        {
            var screen = new ClinicAdmin.GUI.Prescription();
            screen.ShowDialog();
        }

        private void Checkin_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var patient = lsvPatient.SelectedItem as PatientDAO;

            if (_homeBUS.CheckIn(patient))
            {
                txblFullname.Text = patient.FullName;
                txblAge.Text = patient.Age.ToString();
                txblAddress.Text = patient.Address;
                txblWeight.Text = patient.Weight.ToString();
                txblGender.Text = patient.Gender;
                txblPhone.Text = patient.Phone;
                lsvPatient.ItemsSource = null;
                lsvPatient.Items.Clear();
                lsvPatient.ItemsSource = _homeBUS.listPatients;
            }
        }

        private void Remove_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var patient = lsvPatient.SelectedItem as PatientDAO;
            //_homeBUS.CheckOut(patient);

            _homeBUS.listPatients.Remove(patient);
            lsvPatient.ItemsSource = null;
            lsvPatient.Items.Clear();
            lsvPatient.ItemsSource = _homeBUS.listPatients;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string patientName = txbPatientName.Text;
            DateTime? dateFrom = dpkFrom.SelectedDate;
            DateTime? dateTo = dpkTo.SelectedDate;

            _homeBUS.PatientSearch(patientName, dateFrom, dateTo);
            lsvPatient.ItemsSource = null;
            lsvPatient.Items.Clear();
            lsvPatient.ItemsSource = _homeBUS.listPatients;
        }

        private void btnClearSearch_Click(object sender, RoutedEventArgs e)
        {
            txbPatientName.Text = "";
            dpkFrom.SelectedDate = null;
            dpkTo.SelectedDate = null;

            btnSearch_Click(sender, e);
        }

        private void btnRemoveMedicine_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            MedicineDAO medicine = button.DataContext as MedicineDAO;
            _homeBUS.listMedicines.Remove(medicine);
            lstvMedicines.ItemsSource = null;
            lstvMedicines.Items.Clear();
            lstvMedicines.ItemsSource = _homeBUS.listMedicines;
        }
    }
}
