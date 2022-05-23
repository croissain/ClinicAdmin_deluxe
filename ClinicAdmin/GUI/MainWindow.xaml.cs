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
using System.Windows.Controls.Primitives;
using ClinicAdmin.GUI;
using ClinicAdmin.BUS;

namespace ClinicAdmin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowBUS _mainWindowBUS;

        public MainWindow()
        {
            InitializeComponent();
        }

        public string IntialName(string name)
        {
            string FirstIntial = name.Substring(0, 1);
            string LastIntial = "";
            for (int i = name.Length - 1; i > 0; i--)
            {
                if (name[i] == ' ')
                {
                    LastIntial = name[i+1].ToString();
                    break;
                }
            }
            return FirstIntial + LastIntial;
        }

        public string LongNameBeautify(string name)
        {
            string result = name;
            if (result.Length > 15)
            {
                for (int i = result.Length / 2 - 1; i < result.Length - 1; i++)
                {
                    if (result[i] == ' ')
                    {
                        result = result.Remove(i,1).Insert(i, "\n");
                        break;
                    }
                }
            }
            return result;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _mainWindowBUS = MainWindowBUS.getInstance();
            _mainWindowBUS.BUSLayer_Loaded();
            if (_mainWindowBUS.userAccount != null)
            {
                txblUserInitial.Text = IntialName(_mainWindowBUS.userAccount.Fullname);
                txblUserName.Text = LongNameBeautify(_mainWindowBUS.userAccount.Fullname);
                txblUserRole.Text = _mainWindowBUS.userAccount.Role.Name;
            }
            fContainer.Navigate(new System.Uri("GUI/Pages/Welcome.xaml", UriKind.RelativeOrAbsolute));
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát!", "Thông báo", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        #region MacOS UI cheap moment
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
        #endregion

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        #region MenuLeft PopupButton
        private void btnHome_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnHome;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Trang chủ";
            }
        }

        private void btnHome_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnStaffList_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnStaffList;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "DS Nhân Viên";
            }
        }
        
        private void btnStaffList_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnMedicalList_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnMedicalList_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnMedicalList;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "DS Thuốc/VTYT";
            }
        }

        private void btnAccount_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnAccount;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Tài Khoản";
            }
        }

        private void btnAccount_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }

        private void btnReport_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnReport;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Thống Kê";
            }
        }

        private void btnReport_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }
        #endregion

        #region Sidebar Tabs Click
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("GUI/Pages/Home.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnStaffList_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("GUI/Pages/StaffsList.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnMedicalList_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("GUI/Pages/MedicinesList.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnAccount_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("GUI/Pages/Account.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("GUI/Pages/Report.xaml", UriKind.RelativeOrAbsolute));
        }
        #endregion

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Login dialog = new Login();
            this.Close();
            dialog.ShowDialog();
        }
    }
}
