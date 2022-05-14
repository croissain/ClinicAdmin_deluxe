using ClinicAdmin.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAdmin.DAO
{
    public class UserFactory
    {
        public static UserDAO GetUserLogin(string username, string password)
        {
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                var entryPoint = ( from us in context.Users
                                  where us.Username == username && us.Password == password
                                  select new
                                  {
                                      id = us.Id,
                                      FullName = us.FullName,
                                      Username = us.Username,
                                      Password = us.Password,
                                      Address = us.Address,
                                      Email = us.Email,
                                      Phone = us.Phone,
                                      RoleId = us.RoleId
                                  }).FirstOrDefault();
                switch(entryPoint.RoleId)
                {
                    case (int)RoleEnum.ADMIN:
                        return new AdminDAO(entryPoint.id, entryPoint.Username, entryPoint.Password, entryPoint.FullName,
                                            entryPoint.Address, entryPoint.Email, entryPoint.Phone);
                    case (int)RoleEnum.DOCTOR:
                        return new DoctorDAO(entryPoint.id, entryPoint.Username, entryPoint.Password, entryPoint.FullName,
                                            entryPoint.Address, entryPoint.Email, entryPoint.Phone);
                    case (int)RoleEnum.STAFF:
                        return new StaffDAO(entryPoint.id, entryPoint.Username, entryPoint.Password, entryPoint.FullName,
                                            entryPoint.Address, entryPoint.Email, entryPoint.Phone);
                }
            }

            return null;
        }

        //public string GetRoleUser(int id)
        //{
        //    string result = null;
        //    using (ClinicAdminEntities context = new ClinicAdminEntities())
        //    {
        //        var entryPoint = (from role in context.Roles
        //                          join user in context.Users on role.Id equals user.RoleId
        //                          where user.Id == id
        //                          select new
        //                          {
        //                              RoleName = role.Name
        //                          }).Take(1).FirstOrDefault();
        //        result = entryPoint.RoleName;
        //    }
        //    return result;
        //}
    }
}
