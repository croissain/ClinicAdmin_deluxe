using ClinicAdmin.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAdmin.DAO
{
    public class UsageMedicineDAO :UsageMedicine
    {
        private static UsageMedicineDAO _instance;

        public static UsageMedicineDAO getInstance()
        {
            if (_instance == null)
            {
                _instance = new UsageMedicineDAO();
            }
            return _instance;
        }

        public UsageMedicineDAO()
        {
        }

        public UsageMedicineDAO(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public List<UsageMedicineDAO> GetListUsageMedicine()
        {
            List<UsageMedicineDAO> result = new List<UsageMedicineDAO>();
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                var entryPoint = (from us in context.UsageMedicines
                                  select new
                                  {
                                      id = us.id,
                                      name = us.name
                                  }).ToList();
                foreach (var item in entryPoint)
                {
                    UsageMedicineDAO medicine = new UsageMedicineDAO(item.id, item.name);
                    result.Add(medicine);
                }
            }
            return result;
        }
    }
}
