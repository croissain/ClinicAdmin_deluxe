using ClinicAdmin.DAO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace ClinicAdmin.Pages
{
    /// <summary>
    /// Interaction logic for StaffsList.xaml
    /// </summary>
    public partial class StaffsList : Page
    {
        public StaffsList()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var listDoctor = DoctorDAO.getInstance().GetListDoctor();
            lsvDoctor.ItemsSource = listDoctor;

            var listStaff = StaffDAO.getInstance().GetListStaff();
            lsvStaff.ItemsSource = listStaff;

            var listAdmin = AdminDAO.getInstance().GetListAdmin();
            lsvAdmin.ItemsSource = listAdmin;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var screen = new ClinicAdmin.GUI.Addnew();
            screen.ShowDialog();
        }
    }
}
