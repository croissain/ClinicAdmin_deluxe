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

namespace ClinicAdmin.GUI
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Addnew : Window
    {
        public Addnew()
        {
            InitializeComponent();
        }

        // MacOS UI cheap moment
        // Button Close | Minimize | Restore
        private void WindowButton_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void WindowButton_Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void WindowButton_FullScreen_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
