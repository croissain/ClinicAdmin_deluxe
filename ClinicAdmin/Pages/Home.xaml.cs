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

            _homeBUS.listPatients = PatientDAO.getInstance().GetListPatient();
            lsvPatient.ItemsSource = _homeBUS.listPatients;
        }

        private void ExportInvoice_Click(object sender, RoutedEventArgs e)
        {
            var screen = new ClinicAdmin.GUI.Prescription();
            screen.ShowDialog();
        }

        private void Checkin_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var patient = lsvPatient.SelectedItem as PatientDAO;

            if(_homeBUS.CheckIn(patient))
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

        }
    }
}
