using ClinicAdmin.BUS;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace ClinicAdmin.GUI
{
    /// <summary>
    /// Interaction logic for EditPatient.xaml
    /// </summary>
    public partial class EditPatient : Window
    {
        private EditPatientBUS _editPatientBUS;
        public EditPatient(int appointmentId)
        {
            InitializeComponent();
            _editPatientBUS = EditPatientBUS.getInstance();
            _editPatientBUS.AppointmentId = appointmentId;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _editPatientBUS.BUSLayer_Loaded();
            txbFullname.Text = _editPatientBUS.Appointment.Patient.Fullname;
            txbAge.Text = _editPatientBUS.Appointment.Patient.Age.ToString();
            txbWeight.Text = _editPatientBUS.Appointment.Patient.Weight.ToString();
            txbAddress.Text = _editPatientBUS.Appointment.Patient.Address;
            txbPhone.Text = _editPatientBUS.Appointment.Patient.Phone;
            dpkDayExam.SelectedDate = _editPatientBUS.Appointment.AppointmentDay;

            if (_editPatientBUS.Appointment.Patient.Gender == "Nam")
            {
                rdbtnMale.IsChecked = true;
            }
            else
            {
                rdbtnFemale.IsChecked = true;
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string fullname = txbFullname.Text;
            string gender = rdbtnMale.IsChecked == true ? rdbtnMale.Content.ToString() : rdbtnFemale.Content.ToString();
            string age = txbAge.Text;
            string weight = txbWeight.Text;
            string address = txbAddress.Text;
            string phone = txbPhone.Text;
            DateTime? dayExam = dpkDayExam.SelectedDate;

            _editPatientBUS.UpdateRecord(fullname, gender, address, age, weight, phone, dayExam);
            this.Close();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
