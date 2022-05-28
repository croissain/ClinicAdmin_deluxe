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
                        return new AdminDAO()
                        {
                            Id = entryPoint.id,
                            Fullname = entryPoint.FullName,
                            Address = entryPoint.Address,
                            Email = entryPoint.Email,
                            Phone = entryPoint.Phone,
                            Password = entryPoint.Password,
                            Username = username,
                            Role = new RoleDAO() { Id = (int)entryPoint.RoleId, Name= "Quản trị viên"}
                        };
                    case (int)RoleEnum.DOCTOR:
                        return new DoctorDAO()
                        {
                            Id = entryPoint.id,
                            Fullname = entryPoint.FullName,
                            Address = entryPoint.Address,
                            Email = entryPoint.Email,
                            Phone = entryPoint.Phone,
                            Password = entryPoint.Password,
                            Username = username,
                            Role = new RoleDAO() { Id = (int)entryPoint.RoleId, Name = "Quản trị viên" }
                        };
                    case (int)RoleEnum.STAFF:
                        return new StaffDAO()
                        {
                            Id = entryPoint.id,
                            Fullname = entryPoint.FullName,
                            Address = entryPoint.Address,
                            Email = entryPoint.Email,
                            Phone = entryPoint.Phone,
                            Password = entryPoint.Password,
                            Username = username,
                            Role = new RoleDAO() { Id = (int)entryPoint.RoleId, Name = "Quản trị viên" }
                        };
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

        public static UserDAO GetUserById(int id)
        {
            using(ClinicAdminEntities context = new ClinicAdminEntities())
            {
                var user = context.Users.SingleOrDefault(x => x.Id == id);
                switch (user.RoleId)
                {
                    case (int)RoleEnum.ADMIN:
                        return new AdminDAO()
                        {
                            Fullname = user.FullName,
                            Address = user.Address,
                            Email = user.Email,
                            Phone = user.Phone,
                            Password = user.Password,
                            Username = user.Username,
                            Role = new RoleDAO() { Id = user.Role.Id, Name = user.Role.Name}
                        };
                    case (int)RoleEnum.DOCTOR:
                        return new DoctorDAO()
                        {
                            Fullname = user.FullName,
                            Address = user.Address,
                            Email = user.Email,
                            Phone = user.Phone,
                            Password = user.Password,
                            Username = user.Username,
                            Role = new RoleDAO() { Id = user.Role.Id, Name = user.Role.Name }
                        };
                    case (int)RoleEnum.STAFF:
                        return new StaffDAO()
                        {
                            Fullname = user.FullName,
                            Address = user.Address,
                            Email = user.Email,
                            Phone = user.Phone,
                            Password = user.Password,
                            Username = user.Username,
                            Role = new RoleDAO() { Id = user.Role.Id, Name = user.Role.Name }
                        };
                    default:
                        return null;
                }
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
                    MessageBox.Show(ex.Message );
                    return false;
                }
                return true;
            }
        }

        public static bool UpdateAccount(UserDAO userDAO)
        {
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                try
                {
                    var dbSet = context.Users.SingleOrDefault(x => x.Id == userDAO.Id || x.Username == userDAO.Username);
                    if (dbSet != null)
                    {
                        dbSet.Address = userDAO.Address;
                        dbSet.Email = userDAO.Email;
                        dbSet.FullName = userDAO.Fullname;
                        dbSet.Phone = userDAO.Phone;
                        context.SaveChanges();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            return true;
        }

        public static bool ChangePassword(string password, int id)
        {
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                try
                {
                    var dbSet = context.Users.SingleOrDefault(x => x.Id == id);
                    string hasPass = "";
                    byte[] buffer = ASCIIEncoding.ASCII.GetBytes(password);
                    byte[] hasData = md5.ComputeHash(buffer);

                    foreach (var item in hasData)
                    {
                        hasPass += item;
                    }

                    if (dbSet != null)
                    {
                        dbSet.Password = hasPass;
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            return true;
        }

        public static bool EditUser(UserDAO userDAO)
        {
            return true;
        }

        public static bool RemoveUser(int id)
        {
            using(ClinicAdminEntities context = new ClinicAdminEntities())
            {
                var user = new User { Id = id };
                try
                {
                    context.Users.Attach(user);
                    context.Users.Remove(user);
                    context.SaveChanges();
                    return true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Lỗi:" + ex.Message);
                    return false;
                }
            }
        }
    }
}
