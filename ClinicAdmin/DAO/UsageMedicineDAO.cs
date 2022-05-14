using ClinicAdmin.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAdmin.DAO
{
    public class UsageMedicineDAO
    {
        private static UsageMedicineDAO _instance;
        private int id;
        private string name;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        public static UsageMedicineDAO getInstance()
        {
            if (_instance == null)
            {
                _instance = new UsageMedicineDAO();
            }
            return _instance;
        }

        public List<UsageMedicineDAO> GetListUsageMedicine()
        {
            List<UsageMedicineDAO> result = new List<UsageMedicineDAO>();
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                var entryPoint = (from us in context.UsageMedicines
                                  select new
                                  {
                                      id = us.Id,
                                      name = us.Name
                                  }).ToList();
                foreach (var item in entryPoint)
                {
                    UsageMedicineDAO medicine = new UsageMedicineDAO()
                    {
                        Id = item.id, 
                        Name = item.name
                    };
                    result.Add(medicine);
                }
            }
            return result;
        }
    }
}
