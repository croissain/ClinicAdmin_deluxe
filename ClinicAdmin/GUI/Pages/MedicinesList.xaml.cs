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
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace ClinicAdmin.Pages
{
    /// <summary>
    /// Interaction logic for MedicinesList.xaml
    /// </summary>
    public partial class MedicinesList : System.Windows.Controls.Page
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

        private void ExportMedicineList_Click(object sender, RoutedEventArgs e)
        {
            //using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xls", ValidateNames = true })
            //{
            //    if (sfd.ShowDialog() == DialogResult.OK)
            //    {
            //        Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            //        Workbook wb = app.Workbooks.Add(XlSheetType.xlWorksheet);
            //        Worksheet ws = (Worksheet)app.ActiveSheet;
            //        app.Visible = false;

            //        ws.Cells[1, 1] = "Patient ID";
            //        ws.Cells[1, 2] = "Full name";
            //        ws.Cells[1, 3] = "Address";
            //        ws.Cells[1, 4] = "Phone";
            //        ws.Cells[1, 5] = "Weight";
            //        ws.Cells[1, 6] = "Age";
            //        ws.Cells[1, 7] = "Gender";
            //        int i = 2;
            //        foreach (System.Windows.Forms.ListViewItem item in (lsvMedicine.Items)
            //        {
            //            ws.Cells[i, 1] = item.SubItems[0].Text;
            //            ws.Cells[i, 2] = item.SubItems[1].Text;
            //            ws.Cells[i, 3] = item.SubItems[2].Text;
            //            ws.Cells[i, 4] = item.SubItems[3].Text;
            //            ws.Cells[i, 5] = item.SubItems[4].Text;
            //            ws.Cells[i, 6] = item.SubItems[5].Text;
            //            ws.Cells[i, 7] = item.SubItems[6].Text;
            //            i++;
            //        }
            //        wb.SaveAs(sfd.FileName, XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, true, false, XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);
            //        app.Quit();
            //        System.Windows.Forms.MessageBox.Show("Dữ liệu được xuất thành file Excel thành công!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string drugName = txbDrugName.Text;

            var listMedicines = MedicineDAO.getInstance().MedicineSearch(drugName);
            lsvMedicine.ItemsSource = listMedicines;
        }

        private void btnClearSearch_Click(object sender, RoutedEventArgs e)
        {
            txbDrugName.Text = "";

            btnSearch_Click(sender, e);
        }
    }
}
