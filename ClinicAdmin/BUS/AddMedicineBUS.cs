using ClinicAdmin.DAO;
using ClinicAdmin.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClinicAdmin.BUS
{
    public class AddMedicineBUS
    {
        private static AddMedicineBUS _instance;
        public List<MedicineDAO> medicines;
        public List<UnitMedicineDAO> unitMedicines;
        public List<UsageMedicineDAO> usageMedicines;

        public static AddMedicineBUS getInstance()
        {
            if (_instance == null)
            {
                _instance = new AddMedicineBUS();
            }
            return _instance;
        }

        public void BUSLayer_Loaded()
        {
            medicines = MedicineDAO.getInstance().GetListMedicine();
            unitMedicines = UnitMedicineDAO.getInstance().GetListUnitMedicine();
            usageMedicines = UsageMedicineDAO.getInstance().GetListUsageMedicine();
        }

        public void AddListMedicine(object medicineObj, object unitObj, object usageObj, string amount, Window window)
        {
            MedicineDAO medicineDAO = medicineObj as MedicineDAO;
            UnitMedicineDAO unitDAO = unitObj as UnitMedicineDAO;
            UsageMedicineDAO usageDAO = usageObj as UsageMedicineDAO;

            if(medicineDAO == null)
            {
                MessageBox.Show("Bạn cần chọn thuốc!");
            }
            else if (unitDAO == null)
            {
                MessageBox.Show("Bạn cần chọn đơn vị!");
            }
            else if (usageDAO == null)
            {
                MessageBox.Show("Bạn cần chọn cách sử dụng!");
            }
            else if(amount == "")
            {
                MessageBox.Show("Bạn cần nhập số lượng!");
            }
            else
            {
                Prescription_MedicineDAO medicine = new Prescription_MedicineDAO()
                {
                    AmountDrug = Int32.Parse(amount),
                    Unit = unitDAO.Name,
                    Usage = usageDAO.Name,
                    Medicine = medicineDAO,
                    Cost = (double)(medicineDAO.Price * Int32.Parse(amount))
                };
                HomeBUS.getInstance().listMedicines.Add(medicine);
                HomeBUS.getInstance().medicineStorage = medicine.Storage.ToString();
                window.Close();
            }
        }
    }
}
