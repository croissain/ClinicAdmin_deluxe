using ClinicAdmin.BUS;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ClinicAdmin.GUI
{
    /// <summary>
    /// Interaction logic for Prescription.xaml
    /// </summary>
    public partial class Prescription : Window
    {
        private PrescriptionBUS _prescriptionBUS;
        public Prescription()
        {
            InitializeComponent();
        }

        private void ExportPrescription_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "Prescription");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _prescriptionBUS = PrescriptionBUS.getInstance();
            txblFullname.Text = _prescriptionBUS.Patient.Fullname;
            txblGender.Text = _prescriptionBUS.Patient.Gender;
            txblAge.Text = _prescriptionBUS.Patient.Age.ToString();
            txblAddress.Text = _prescriptionBUS.Patient.Address;
            txblDiagnose.Text = _prescriptionBUS.Diagnose;
            lsvMedicines.ItemsSource = HomeBUS.getInstance().listMedicines;
            txblTotalCost.Text = _prescriptionBUS.TotalCost.ToString() + " VNĐ";
            txblNote.Text = _prescriptionBUS.Note;
            txblStaffName.Text = _prescriptionBUS.StaffName;
            txblDoctorName.Text = _prescriptionBUS.DoctorName;
            txblDayExam.Text = DateTime.Today.ToShortDateString();
            txblHourExam.Text = DateTime.Now.ToShortTimeString();
        }
    }
}
