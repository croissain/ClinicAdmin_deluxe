﻿using ClinicAdmin.BUS;
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
        private StaffListBUS _staffListBUS;
        public StaffsList()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _staffListBUS = StaffListBUS.getInstance();
            Refresh();
        }

        private void Refresh()
        {
            _staffListBUS.BUSLayer_Loaded();
            lsvDoctor.ItemsSource = _staffListBUS.listDoctors;
            lsvAdmin.ItemsSource = _staffListBUS.listAdmins;
            lsvStaff.ItemsSource = _staffListBUS.listStaffs;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindowBUS.getInstance().userAccount.AddAccountUser())
            {
                var screen = new ClinicAdmin.GUI.Addnew();
                screen.ShowDialog();
                Refresh();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindowBUS.getInstance().userAccount.RemoveUser())
            {
                var id = Int32.Parse((sender as Button).Uid);
                var screen = new ClinicAdmin.GUI.EditUser(id);
                screen.ShowDialog();
                Refresh();
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindowBUS.getInstance().userAccount.RemoveUser())
            {
                var id = Int32.Parse((sender as Button).Uid);
                _staffListBUS.RemoveUser(id);
                Refresh();
            }
        }

    }
}
