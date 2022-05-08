using ClinicAdmin.DAO;
using ClinicAdmin.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAdmin.BUS
{
    public class LoginBUS
    {
        public usp_Login_Result GetUserLogin(string username, string password)
        {
            usp_Login_Result user;
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                user = context.usp_Login(username, password).FirstOrDefault();
            }
            return user;
        }

        public string GetRoleUser(int id)
        {
            string result = null;
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                var entryPoint = (from role in context.Roles
                                  join hr in context.Has_role on role.id equals hr.roleId
                                  join user in context.Users on hr.userId equals user.id
                                  where user.id == id
                                  select new
                                  {
                                      RoleName = role.RoleName
                                  }).Take(1).FirstOrDefault();
                result = entryPoint.RoleName;
            }
            return result;
        }
    }
}
