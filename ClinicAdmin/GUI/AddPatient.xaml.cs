using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ClinicAdmin.BUS;

namespace ClinicAdmin.GUI
{
    /// <summary>
    /// Interaction logic for AddPatient.xaml
    /// </summary>
    public partial class AddPatient : Window
    {
        private AddPatientBUS _addPatientBUS;
        public AddPatient()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _addPatientBUS = AddPatientBUS.getInstance();
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

            _addPatientBUS.AddPatient(fullname, gender, age, weight, address, phone, dayExam, this);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
