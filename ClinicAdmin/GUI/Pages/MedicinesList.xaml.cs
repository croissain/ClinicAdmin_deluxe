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
    /// Interaction logic for MedicinesList.xaml
    /// </summary>
    public partial class MedicinesList : Page
    {
        public MedicinesList()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var listMedicines = MedicineDAO.getInstance().GetListMedicine();
            lsvMedicine.ItemsSource = listMedicines;
        }

        private void ExportInvoice_Click(object sender, RoutedEventArgs e)
        {
            var screen = new ClinicAdmin.GUI.Prescription();
            screen.ShowDialog();
        }
    }
}
