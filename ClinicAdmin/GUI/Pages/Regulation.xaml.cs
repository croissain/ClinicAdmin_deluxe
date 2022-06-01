using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace ClinicAdmin.Pages
{
    /// <summary>
    /// Interaction logic for Regulation.xaml
    /// </summary>
    public partial class Regulation : System.Windows.Controls.Page
    {
        public Regulation()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void EditRegulation_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
