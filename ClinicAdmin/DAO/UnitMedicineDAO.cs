using ClinicAdmin.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAdmin.DAO
{
    public class UnitMedicineDAO : UnitMedicine
    {
        private static UnitMedicineDAO _instance;

        public static UnitMedicineDAO getInstance()
        {
            if (_instance == null)
            {
                _instance = new UnitMedicineDAO();
            }
            return _instance;
        }

        public UnitMedicineDAO()
        {
        }

        public UnitMedicineDAO(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public List<UnitMedicineDAO> GetListUnitMedicine()
        {
            List<UnitMedicineDAO> result = new List<UnitMedicineDAO>();
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                var entryPoint = (from um in context.UnitMedicines
                                  select new
                                  {
                                      id = um.id,
                                      name = um.name
                                  }).ToList();
                foreach (var item in entryPoint)
                {
                    UnitMedicineDAO medicine = new UnitMedicineDAO(item.id, item.name);
                    result.Add(medicine);
                }
            }
            return result;
        }
    }
}
