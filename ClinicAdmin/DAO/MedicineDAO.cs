using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicAdmin.DTO;

namespace ClinicAdmin.DAO
{
    class MedicineDAO : Medicine
    {
        private static MedicineDAO instance;
        private string status;

        public string Status
        {
            get => status; set => status = value;
        }

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

        public static MedicineDAO getInstance()
        {
            if (instance == null)
            {
                instance = new MedicineDAO();
            }
            return instance;
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
