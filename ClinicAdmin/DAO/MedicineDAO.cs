using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAdmin.DTO;

namespace ClinicAdmin.DAO
{
    public class MedicineDAO : Medicine
    {
        private static MedicineDAO _instance;
        private string usage;
        private string unit;
        private int amount;
        private double price;

        public string Usage { get => usage; set => usage = value; }
        public string Unit { get => unit; set => unit = value; }
        public int Amount { get => amount; set => amount = value; }
        public double Price { get => price; set => price = value; }

        public MedicineDAO()
        {
        }

        public MedicineDAO(int id, string drugname, int? storage, double? cost)
        {
            this.id = id;
            this.DrugName = drugname;
            this.Storage = storage;
            this.Cost = cost;
        }

        public MedicineDAO(MedicineDAO medicineDAO, string usage, string unit, int amount)
        {
            this.id = medicineDAO.id;
            this.DrugName = medicineDAO.DrugName;
            this.Storage = medicineDAO.Storage;
            this.Cost = medicineDAO.Cost;
            this.Usage = usage;
            this.Unit = unit;
            this.Amount = amount;
            this.Price = (double)medicineDAO.Cost * amount;
        }

        public static MedicineDAO getInstance()
        {
            if (_instance == null)
            {
                _instance = new MedicineDAO();
            }
            return _instance;
        }

        public List<MedicineDAO> GetListMedicine()
        {
            List<MedicineDAO> result = new List<MedicineDAO>();
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                var entryPoint = (from m in context.Medicines
                                  select new
                                  {
                                      id = m.id,
                                      drugname = m.DrugName,
                                      storage = m.Storage,
                                      cost = m.Cost
                                  }).ToList();
                foreach (var item in entryPoint)
                {
                    MedicineDAO medicine = new MedicineDAO(item.id, item.drugname, item.storage, item.cost);
                    result.Add(medicine);
                }
            }
            return result;
        }
    }
}
