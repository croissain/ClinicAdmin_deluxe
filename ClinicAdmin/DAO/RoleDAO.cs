using ClinicAdmin.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAdmin.DAO
{
    public class RoleDAO
    {
        private static RoleDAO _instance;
        private int id;
        private string name;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        public static RoleDAO getInstance()
        {
            if (_instance == null)
            {
                _instance = new RoleDAO();
            }
            return _instance;
        }

        public List<RoleDAO> GetListRole()
        {
            List<RoleDAO> result = new List<RoleDAO>();
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                var entryPoint = (from r in context.Roles
                                  select new
                                  {
                                      id = r.Id,
                                      name = r.Name
                                  }).ToList();
                foreach (var item in entryPoint)
                {
                    RoleDAO role = new RoleDAO()
                    {
                        Id = item.id,
                        Name = item.name
                    };
                    result.Add(role);
                }
            }
            return result;
        }
    }
}
