using ClinicAdmin.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClinicAdmin.DAO
{
    public class UserFactory
    {
        public static UserDAO GetUserLogin(string username)
        {
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                var entryPoint = (from us in context.Users
                                  where us.Username == username
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
                switch (entryPoint.RoleId)
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

        public static UserDAO GetUser(string fullname, string address, string email, string phone, string username, string pass, int role)
        {
            switch (role)
            {
                case (int)RoleEnum.ADMIN:
                    return new AdminDAO() 
                    { 
                        Fullname = fullname,
                        Address = address,
                        Email = email,
                        Phone = phone,
                        Password = pass,
                        Username = username
                    };
                case (int)RoleEnum.DOCTOR:
                    return new DoctorDAO()
                    {
                        Fullname = fullname,
                        Address = address,
                        Email = email,
                        Phone = phone,
                        Password = pass,
                        Username = username
                    };
                case (int)RoleEnum.STAFF:
                    return new StaffDAO()
                    {
                        Fullname = fullname,
                        Address = address,
                        Email = email,
                        Phone = phone,
                        Password = pass,
                        Username = username
                    };
                default:
                    return null;
            }
        }

        public static bool AddUser(UserDAO userDAO, int role)
        {
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                string hasPass = "";
                byte[] buffer = ASCIIEncoding.ASCII.GetBytes(userDAO.Password);
                byte[] hasData = md5.ComputeHash(buffer);

                foreach (var item in hasData)
                {
                    hasPass += item;
                }

                var user = new User()
                {
                    FullName = userDAO.Fullname,
                    Address = userDAO.Address,
                    Username = userDAO.Username,
                    Email = userDAO.Email,
                    Phone = userDAO.Phone,
                    RoleId = role,
                    Password = hasPass
                };
                try
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return true;
            }
            return false;
        }
    }
}
