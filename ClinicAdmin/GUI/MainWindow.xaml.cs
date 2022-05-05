﻿using System;
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

namespace ClinicAdmin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        //private void ButtonNav_Click(object sender, RoutedEventArgs e)
        //{
        //    int index = int.Parse(((Button)e.Source).Uid);
        //    MainSectionControl.SelectedIndex = index;
        //}

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

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        // Start: MenuLeft PopupButton //
        private void btnHome_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnHome;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Home";
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

        private void btnBilling_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Tg_Btn.IsChecked == false)
            {
                Popup.PlacementTarget = btnBilling;
                Popup.Placement = PlacementMode.Right;
                Popup.IsOpen = true;
                Header.PopupText.Text = "Hóa Đơn";
            }
        }

        private void btnBilling_MouseLeave(object sender, MouseEventArgs e)
        {
            Popup.Visibility = Visibility.Collapsed;
            Popup.IsOpen = false;
        }
        // End: MenuLeft PopupButton //

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Pages/Home.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnStaffList_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Pages/StaffsList.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnMedicalList_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Pages/MedicinesList.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnAccount_Click(object sender, RoutedEventArgs e)
        {
            fContainer.Navigate(new System.Uri("Pages/Account.xaml", UriKind.RelativeOrAbsolute));
        }

        private void btnBilling_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}