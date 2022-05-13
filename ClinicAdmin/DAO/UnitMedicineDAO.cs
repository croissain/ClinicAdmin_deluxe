using ClinicAdmin.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAdmin.DAO
{
    public class UnitMedicineDAO
    {
        private static UnitMedicineDAO _instance;
        private int id;
        private string name;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        public static UnitMedicineDAO getInstance()
        {
            if (_instance == null)
            {
                _instance = new UnitMedicineDAO();
            }
            return _instance;
        }

        public List<UnitMedicineDAO> GetListUnitMedicine()
        {
            List<UnitMedicineDAO> result = new List<UnitMedicineDAO>();
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                var entryPoint = (from um in context.UnitMedicines
                                  select new
                                  {
                                      id = um.Id,
                                      name = um.Name
                                  }).ToList();
                foreach (var item in entryPoint)
                {
                    UnitMedicineDAO medicine = new UnitMedicineDAO()
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
