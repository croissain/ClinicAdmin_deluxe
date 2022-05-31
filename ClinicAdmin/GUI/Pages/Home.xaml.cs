using ClinicAdmin.BUS;
using ClinicAdmin.DAO;
using ClinicAdmin.GUI;
using System;
using System.Windows;
using System.Windows.Controls;

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
            if (MainWindowBUS.getInstance().userAccount != null)
            {
                txblStaffName.Text = MainWindowBUS.getInstance().userAccount.Fullname;
            }

            _homeBUS.BUSLayer_Loaded();
            lsvPatient.ItemsSource = _homeBUS.listPatients;
            txblDayExam.Text = DateTime.Today.ToShortDateString();

            txblMedicineStorage.Text = _homeBUS.GetTotalStorage();
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
                txblTotalCost.Text = _homeBUS.TotalCost_ToString(_homeBUS.listMedicines);
            }
            else
            {
                MessageBox.Show("Hãy chọn bệnh nhân trước", "Thêm thuốc không thành công", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddPatient_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindowBUS.getInstance().userAccount.AddPatient())
            {
                AddPatient dialog = new AddPatient();
                dialog.ShowDialog();
                lsvPatient.ItemsSource = null;
                lsvPatient.Items.Clear();
                lsvPatient.ItemsSource = _homeBUS.listPatients;
            }
        }

        private void ExportInvoice_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindowBUS.getInstance().userAccount.AddPrescription())
            {
                if (txblFullname.Text != "")
                {
                    string patientName = txblFullname.Text;
                    string patientGender = txblGender.Text;
                    string patientAge = txblAge.Text;
                    string patientAddress = txblAddress.Text;
                    string symptom = txblSymptom.Text;
                    string diagnose = txblDiagnose.Text;
                    string medicalHistory = txblMedicalHistory.Text;
                    string note = txbNote.Text;
                    string doctorName = txbDoctorName.Text;
                    string staffName = txblStaffName.Text;
                    _homeBUS.ExportInvoice(
                        patientName,
                        patientGender,
                        patientAge,
                        patientAddress,
                        symptom,
                        diagnose,
                        medicalHistory,
                        note,
                        doctorName,
                        staffName
                    );
                }
                else
                {
                    MessageBox.Show("Hãy chọn bệnh nhân trước", "Xuất hóa đơn không thành công", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Checkin_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindowBUS.getInstance().userAccount.CheckIn())
            {
                var appointment = lsvPatient.SelectedItem as AppointmentDAO;
                if (_homeBUS.CheckIn(appointment))
                {
                    txblFullname.Text = appointment.Patient.Fullname;
                    txblAge.Text = appointment.Patient.Age.ToString();
                    txblAddress.Text = appointment.Patient.Address;
                    txblWeight.Text = appointment.Patient.Weight.ToString();
                    txblGender.Text = appointment.Patient.Gender;
                    txblPhone.Text = appointment.Patient.Phone;
                    lsvPatient.ItemsSource = null;
                    lsvPatient.Items.Clear();
                    lsvPatient.ItemsSource = _homeBUS.listPatients;
                }
            }
        }

        private void Remove_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindowBUS.getInstance().userAccount.AddPatient())
            {
                var appointment = lsvPatient.SelectedItem as AppointmentDAO;
                _homeBUS.listPatients.Remove(appointment);
                lsvPatient.ItemsSource = null;
                lsvPatient.Items.Clear();
                lsvPatient.ItemsSource = _homeBUS.listPatients;
            }
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
            Prescription_MedicineDAO medicine = button.DataContext as Prescription_MedicineDAO;
            _homeBUS.listMedicines.Remove(medicine);
            lstvMedicines.ItemsSource = null;
            lstvMedicines.Items.Clear();
            lstvMedicines.ItemsSource = _homeBUS.listMedicines;
            txblTotalCost.Text = _homeBUS.TotalCost_ToString(_homeBUS.listMedicines);
        }
    }
}
