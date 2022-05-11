using ClinicAdmin.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAdmin.DAO
{
    public class UserAccountDAO: User
    {
        private static UserAccountDAO instance;
        private string roleName;
        private int roleId;

        public string RoleName { get => roleName; set => roleName = value; }
        public int RoleId { get => roleId; set => roleId = value; }

        public UserAccountDAO() { }

        public UserAccountDAO(int id, string userName, string password, string fullname, string address, string email, string phone, string roleName, int roleId)
        {
            this.id = id;
            this.Username = userName;
            this.Password = password;
            this.FullName = fullname;
            this.Address = address;
            this.Email = email;
            this.Phone = phone;
            this.RoleName = roleName;
            this.RoleId = roleId;
        }

        public static UserAccountDAO getInstance()
        {
            if (instance == null)
            {
                instance = new UserAccountDAO();
            }
            return instance;
        }

        public UserAccountDAO GetUserLogin(string username, string password)
        {
            UserAccountDAO result = null;
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                var entryPoint = (from role in context.Roles
                                  join hr in context.Has_role on role.id equals hr.roleId
                                  join us in context.Users on hr.userId equals us.id
                                  where us.Username == username && us.Password == password
                                  select new
                                  {
                                      id = us.id,
                                      FullName = us.FullName,
                                      Username = us.Username,
                                      Password = us.Password,
                                      Address = us.Address,
                                      Email = us.Email,
                                      Phone = us.Phone,
                                      RoleName = role.RoleName,
                                      RoleId = role.id
                                  }).Take(1).FirstOrDefault();
                result = new UserAccountDAO(entryPoint.id, entryPoint.Username, entryPoint.Password, entryPoint.FullName,
                                            entryPoint.Address, entryPoint.Email, entryPoint.Phone, entryPoint.RoleName, entryPoint.RoleId);
            }

            return result;
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
