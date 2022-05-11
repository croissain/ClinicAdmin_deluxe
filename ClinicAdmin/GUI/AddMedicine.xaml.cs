using ClinicAdmin.BUS;
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
using System.Text.RegularExpressions;

namespace ClinicAdmin.GUI
{
    /// <summary>
    /// Interaction logic for AddMedicine.xaml
    /// </summary>
    public partial class AddMedicine : Window
    {
        private AddMedicineBUS _addMedicineBUS;
        public AddMedicine()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _addMedicineBUS = AddMedicineBUS.getInstance();
            _addMedicineBUS.BUSLayer_Loaded();

            cbbDrug.ItemsSource = _addMedicineBUS.medicines;
            cbbUnit.ItemsSource = _addMedicineBUS.unitMedicines;
            cbbUsage.ItemsSource = _addMedicineBUS.usageMedicines;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnAddMedicine_Click(object sender, RoutedEventArgs e)
        {
            var medicine = cbbDrug.SelectedItem;
            var unit = cbbUnit.SelectedItem;
            var usage = cbbUsage.SelectedItem;
            string amount = txbAmount.Text;
            _addMedicineBUS.AddListMedicine(medicine, unit, usage, amount, this);
        }
    }
}
