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
        private UserAccountDAO _userAccount;
        public Home(UserAccountDAO userAccountDAO)
        {
            InitializeComponent();
            _userAccount = userAccountDAO;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (_userAccount != null)
            {
                txblStaffName.Text = _userAccount.FullName;
            }

            var listPatients = PatientDAO.getInstance().GetListPatient();
            lsvPatient.ItemsSource = listPatients;
        }

        private void AddMedicine_Click(object sender, RoutedEventArgs e)
        {
            AddMedicine dialog = new AddMedicine();
            dialog.ShowDialog();
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
    }
}
