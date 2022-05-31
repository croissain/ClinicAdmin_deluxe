using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAdmin.DTO;

namespace ClinicAdmin.DAO
{
    public class MedicineDAO
    {
        private static MedicineDAO _instance;
        private int id;
        private string drugName;
        private int storage;
        private double price;
        //public double totalStorage = 0;

        public string DrugName
        {
            get => drugName; set => drugName = value;
        }
        public int Storage
        {
            get => storage; set => storage = value;
        }
        public double Price
        {
            get => price; set => price = value;
        }
        public int Id
        {
            get => id; set => id = value;
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
                                      id = m.Id,
                                      drugname = m.DrugName,
                                      storage = m.Storage,
                                      cost = m.Price
                                  }).ToList();
                foreach (var item in entryPoint)
                {
                    MedicineDAO medicine = new MedicineDAO()
                    {
                        Id = item.id,
                        DrugName = item.drugname,
                        Storage = item.storage,
                        Price = item.cost
                    };
                    result.Add(medicine);
                }
            }
            return result;
        }

        public double GetTotalStorage()
        {
            double totalStorage = 0;
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                var entryPoint = (from m in context.Medicines
                                  select new
                                  {
                                      id = m.Id,
                                      drugname = m.DrugName,
                                      storage = m.Storage,
                                      cost = m.Price
                                  }).ToList();
                foreach (var item in entryPoint)
                {
                    totalStorage += item.storage;
                }
            }
            return totalStorage;
        }

        public List<MedicineDAO> MedicineSearch(string drugName)
        {
            List<MedicineDAO> result = new List<MedicineDAO>();
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                var entryPoint = (from m in context.Medicines
                                  where m.DrugName.Contains(drugName)
                                  select new
                                  {
                                      id = m.Id,
                                      drugName = m.DrugName,
                                      storage = m.Storage,
                                      cost = m.Price
                                  }).ToList();
                foreach (var item in entryPoint)
                {
                    MedicineDAO medicine = new MedicineDAO()
                    {
                        Id = item.id,
                        DrugName = item.drugName,
                        Storage = item.storage,
                        Price = item.cost
                    };

                    result.Add(medicine);
                }
            }
            return result;
        }
    }
}
