using ClinicAdmin.BUS;
using ClinicAdmin.DAO;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ClinicAdmin.GUI.Pages
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Statistic : Excel.Page
    {
        private StatisticBUS _statisticBUS;
        private ReportBUS _reportBUS;
        private MainWindowBUS _mainWindowBUS;

        public Statistic()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            _statisticBUS = StatisticBUS.getInstance();
            _reportBUS = ReportBUS.getInstance();
            _mainWindowBUS = MainWindowBUS.getInstance();
            _statisticBUS.BUSLayer_Loaded();
            lsvPatient.ItemsSource = _statisticBUS.listPatients;
            txblTotalMedicines.Text = _reportBUS.TotalMedicines.ToString();
            txblTotalPatients.Text = _reportBUS.TotalPatients.ToString();
            txblTotalInvoices.Text = _reportBUS.TotalInvoice.ToString();
            lbSumProfit.Content = _statisticBUS.SumProfitInMonth(DateTime.Today.Month, DateTime.Today.Year).ToString();
            lbPatientInDay.Content = _statisticBUS.PatientInDay().ToString();
            lbProfitInDay.Content = _statisticBUS.ProfitInDay().ToString();
            lbMonthlyGrowth.Content = _statisticBUS.MonthlyGrowth(DateTime.Today.Month, DateTime.Today.Year).ToString() + " %";
        }

        private void Refresh()
        {
            _statisticBUS.BUSLayer_Loaded();
            lsvPatient.ItemsSource = null;
            lsvPatient.Items.Clear();
            lsvPatient.ItemsSource = _statisticBUS.listPatients;
        }

        private void btnRegulation_Click(object sender, RoutedEventArgs e)
        {
            var screen = new PopupRegulation();
            screen.ShowDialog();
            Refresh();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string patientName = txbPatientName.Text;
            DateTime? dateFrom = dpkFrom.SelectedDate;
            DateTime? dateTo = dpkTo.SelectedDate;

            _statisticBUS.PatientSearch(patientName, dateFrom, dateTo);
            lsvPatient.ItemsSource = null;
            lsvPatient.Items.Clear();
            lsvPatient.ItemsSource = _statisticBUS.listPatients;
        }

        private void btnClearSearch_Click(object sender, RoutedEventArgs e)
        {
            txbPatientName.Text = "";
            dpkFrom.SelectedDate = null;
            dpkTo.SelectedDate = null;

            btnSearch_Click(sender, e);
        }

        private void ExportReport_Click(object sender, RoutedEventArgs e)
        {
            int totalMedicines = Convert.ToInt32(txblTotalMedicines.Text);
            int totalPatients = Convert.ToInt32(txblTotalPatients.Text);
            int totaInvoice = Convert.ToInt32(txblTotalInvoices.Text);
            double sumProfit = Convert.ToDouble(lbSumProfit.Content.ToString());
            double profitInDay = Convert.ToDouble(lbProfitInDay.Content.ToString());
            int patientInDay = Convert.ToInt32(_reportBUS.PatientInDay.ToString());
            string reportPerson = _mainWindowBUS.userAccount.Fullname;
            string description = "";
            string purpose = "";
            _statisticBUS.ExportReport(
                totalMedicines,
                totalPatients,
                totaInvoice,
                sumProfit,
                profitInDay,
                patientInDay,
                reportPerson,
                description,
                purpose
            );

            // Lần lượt xuất file excel DS Bệnh nhân và thuốc tồn
            btnExportPatientsToExcel_Click(sender, e);
            btnExportMedicineToExcel_Click(sender, e);
        }

        #region Xuất file excel của bệnh nhân, thuốc
        private void btnExportPatientsToExcel_Click(object sender, RoutedEventArgs e)
        {
            string filePath = "";

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "CA_patients_" + DateTime.Now.ToString("MMyy");
            dialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                filePath = dialog.FileName;
            }

            if (string.IsNullOrEmpty(filePath))
            {
                System.Windows.MessageBox.Show("Đường dẫn không hợp lệ");
                return;
            }
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            try
            {
                using (ExcelPackage p = new ExcelPackage())
                {
                    p.Workbook.Properties.Author = "";
                    p.Workbook.Properties.Title = "Báo cáo thống kê bệnh nhân";
                    p.Workbook.Worksheets.Add("Patient List");
                    ExcelWorksheet ws = p.Workbook.Worksheets["Patient List"];

                    ws.Name = "Patient List";
                    string[] arrColumnHeader =
                    {
                        "Mã bệnh nhân",
                        "Họ và tên",
                        "Địa chỉ",
                        "Số điện thoại",
                        "Cân nặng",
                        "Tuổi",
                        "Giới tính",
                        "Ngày khám"
                    };
                    var countColHeader = arrColumnHeader.Count();
                    ws.Cells[1, 1].Value = "Danh sách bệnh nhân tháng " + DateTime.Today.Month.ToString();
                    ws.Cells[1, 1, 1, countColHeader].Merge = true;
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                    ws.Cells[1, 1, 1, countColHeader].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                    int colIndex = 1;
                    int rowIndex = 2;
                    foreach (var item in arrColumnHeader)
                    {
                        var cell = ws.Cells[rowIndex, colIndex];
                        var fill = cell.Style.Fill;
                        fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(System.Drawing.Color.MediumAquamarine);
                        cell.Style.Font.Color.SetColor(System.Drawing.Color.White);

                        cell.Value = item;
                        colIndex++;
                    }
                    List<AppointmentDAO> patients = lsvPatient.ItemsSource.Cast<AppointmentDAO>().ToList();
                    foreach (var item in patients)
                    {
                        colIndex = 1;
                        rowIndex++;
                        ws.Cells[rowIndex, colIndex++].Value = item.Patient.Id;
                        ws.Cells[rowIndex, colIndex++].Value = item.Patient.Fullname;
                        ws.Cells[rowIndex, colIndex++].Value = item.Patient.Address;
                        ws.Cells[rowIndex, colIndex++].Value = item.Patient.Phone;
                        ws.Cells[rowIndex, colIndex++].Value = item.Patient.Weight;
                        ws.Cells[rowIndex, colIndex++].Value = item.Patient.Age;
                        ws.Cells[rowIndex, colIndex++].Value = item.Patient.Gender;
                        ws.Cells[rowIndex, colIndex++].Value = item.AppointmentDay.ToShortDateString();
                    }
                    Byte[] bin = p.GetAsByteArray();
                    File.WriteAllBytes(filePath, bin);
                }
                System.Windows.MessageBox.Show("Thành công xuất ra file excel!");
            }
            catch (Exception EE)
            {
                //System.Windows.MessageBox.Show(EE.Message);
                System.Windows.MessageBox.Show("Đã xảy ra lỗi khi xuất file!");
            }
        }

        private void btnExportMedicineToExcel_Click(object sender, RoutedEventArgs e)
        {
            string filePath = "";

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "CA_medicines_" + DateTime.Now.ToString("MMyy");
            dialog.Filter = "Excel | *.xlsx | Excel 2003 | *.xls";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                filePath = dialog.FileName;
            }

            if (string.IsNullOrEmpty(filePath))
            {
                System.Windows.MessageBox.Show("Đường dẫn không hợp lệ");
                return;
            }
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            try
            {
                using (ExcelPackage p = new ExcelPackage())
                {
                    p.Workbook.Properties.Author = "";
                    p.Workbook.Properties.Title = "Báo cáo thống kê thuốc/vật tư y tế";
                    p.Workbook.Worksheets.Add("Medicines List");
                    ExcelWorksheet ws = p.Workbook.Worksheets["Medicines List"];

                    ws.Name = "Patient List";
                    string[] arrColumnHeader =
                    {
                        "Mã thuốc",
                        "Tên thuốc",
                        "Giá tiền",
                        "Tồn kho",
                    };
                    var countColHeader = arrColumnHeader.Count();
                    ws.Cells[1, 1].Value = "Danh sách thuốc tồn kho tháng " + DateTime.Today.Month.ToString();
                    ws.Cells[1, 1, 1, countColHeader].Merge = true;
                    ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
                    ws.Cells[1, 1, 1, countColHeader].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

                    int colIndex = 1;
                    int rowIndex = 2;
                    foreach (var item in arrColumnHeader)
                    {
                        var cell = ws.Cells[rowIndex, colIndex];
                        var fill = cell.Style.Fill;
                        fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        fill.BackgroundColor.SetColor(System.Drawing.Color.MediumAquamarine);
                        cell.Style.Font.Color.SetColor(System.Drawing.Color.White);

                        cell.Value = item;
                        colIndex++;
                    }
                    ClinicAdmin.Pages.MedicinesList medicinesList = new ClinicAdmin.Pages.MedicinesList();
                    medicinesList.lsvMedicine.ItemsSource = MedicineDAO.getInstance().GetListMedicine();
                    List<MedicineDAO> medicines = medicinesList.lsvMedicine.ItemsSource.Cast<MedicineDAO>().ToList();
                    foreach (var item in medicines)
                    {
                        colIndex = 1;
                        rowIndex++;
                        ws.Cells[rowIndex, colIndex++].Value = item.Id;
                        ws.Cells[rowIndex, colIndex++].Value = item.DrugName;
                        ws.Cells[rowIndex, colIndex++].Value = item.Price;
                        ws.Cells[rowIndex, colIndex++].Value = item.Storage;
                    }
                    Byte[] bin = p.GetAsByteArray();
                    File.WriteAllBytes(filePath, bin);
                }
                System.Windows.MessageBox.Show("Thành công xuất ra file excel!");
            }
            catch (Exception EE)
            {
                System.Windows.MessageBox.Show(EE.Message);
                //System.Windows.MessageBox.Show("Đã xảy ra lỗi khi xuất file!");
            }
        }
        #endregion

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var id = Int32.Parse((sender as System.Windows.Controls.Button).Uid);
            var screen = new ClinicAdmin.GUI.EditPatient(id);
            screen.ShowDialog();
            Refresh();
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindowBUS.getInstance().userAccount.CancelAppointment())
            {
                var id = Int32.Parse((sender as System.Windows.Controls.Button).Uid);
                _statisticBUS.CancelAppoint(id);
                Refresh();
            }
        }

        public HeaderFooter LeftHeader => throw new NotImplementedException();

        public HeaderFooter CenterHeader => throw new NotImplementedException();

        public HeaderFooter RightHeader => throw new NotImplementedException();

        public HeaderFooter LeftFooter => throw new NotImplementedException();

        public HeaderFooter CenterFooter => throw new NotImplementedException();

        public HeaderFooter RightFooter => throw new NotImplementedException();
    }
}
