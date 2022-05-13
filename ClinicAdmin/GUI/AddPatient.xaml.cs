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
using System.Windows.Shapes;
using ClinicAdmin.BUS;

namespace ClinicAdmin.GUI
{
    /// <summary>
    /// Interaction logic for AddPatient.xaml
    /// </summary>
    public partial class AddPatient : Window
    {
        public AddPatient()
        {
            InitializeComponent();
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
        }

    }
}
