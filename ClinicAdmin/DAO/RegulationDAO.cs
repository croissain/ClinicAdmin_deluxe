using ClinicAdmin.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAdmin.DAO
{
    public class RegulationDAO
    {
        private static RegulationDAO _instance;
        private int id;
        private string name;
        private string value;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Value { get => value; set => this.value = value; }

        public static RegulationDAO getInstance()
        {
            if (_instance == null)
            {
                _instance = new RegulationDAO();
            }
            return _instance;
        }

        public RegulationDAO GetExamFee()
        {
            RegulationDAO result = null;
            using(ClinicAdminEntities context = new ClinicAdminEntities())
            {
                var entryPoint = (from r in context.Regulations
                                  where r.Name.Contains("Phí khám bệnh")
                                select new
                                {
                                    id = r.Id,
                                    name = r.Name,
                                    value = r.Value
                                }).FirstOrDefault();
                result = new RegulationDAO()
                {
                    Id = entryPoint.id,
                    Name = entryPoint.name,
                    Value = entryPoint.value
                };
            }
            return result;
        }

        public RegulationDAO GetPatientMax()
        {
            RegulationDAO result = null;
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                var entryPoint = (from r in context.Regulations
                                  where r.Name.Contains("Bệnh nhân tối đa")
                                  select new
                                  {
                                      id = r.Id,
                                      name = r.Name,
                                      value = r.Value
                                  }).FirstOrDefault();
                result = new RegulationDAO()
                {
                    Id = entryPoint.id,
                    Name = entryPoint.name,
                    Value = entryPoint.value
                };
            }
            return result;
        }
    }
}
