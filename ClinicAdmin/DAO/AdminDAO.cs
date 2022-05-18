using ClinicAdmin.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClinicAdmin.DAO
{
    public class AdminDAO : UserDAO
    {
        private static AdminDAO _instance;

        public static AdminDAO getInstance()
        {
            if (_instance == null)
            {
                _instance = new AdminDAO();
            }
            return _instance;
        }

        public List<AdminDAO> GetListAdmin()
        {
            List<AdminDAO> result = new List<AdminDAO>();
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                var entryPoint = (from m in context.Users
                                  where m.RoleId == (int)RoleEnum.ADMIN
                                  select new
                                  {
                                      id = m.Id,
                                      Username = m.Username,
                                      Password = m.Password,
                                      Fullname = m.FullName,
                                      Address = m.Address,
                                      Email = m.Email,
                                      Phone = m.Phone
                                  }).ToList();
                foreach (var item in entryPoint)
                {
                    AdminDAO admin = new AdminDAO()
                    {
                        Id = item.id,
                        Username = item.Username,
                        Password = item.Password,
                        Fullname = item.Fullname,
                        Address = item.Address,
                        Email = item.Email,
                        Phone = item.Phone
                    };
                    result.Add(admin);
                }
            }
            return result;
        }

        public AdminDAO() { }

        public AdminDAO(int id, string userName, string password, string fullname, string address, string email, string phone)
        {
            this.Id = id;
            this.Username = userName;
            this.Password = password;
            this.Fullname = fullname;
            this.Address = address;
            this.Email = email;
            this.Phone = phone;
        }

        public override bool AddAccountUser()
        {
            throw new NotImplementedException();
        }

        public override bool ChangeRegulation()
        {
            throw new NotImplementedException();
        }

        public override bool AddPatient()
        {
            MessageBox.Show("Vai trò của bạn không thể thực hiện chức năng này!", "Quyền không khả dụng", MessageBoxButton.OK, MessageBoxImage.Warning);
            return false;
        }

        public override bool AddPrescription()
        {
            MessageBox.Show("Vai trò của bạn không thể thực hiện chức năng này!", "Quyền không khả dụng", MessageBoxButton.OK, MessageBoxImage.Warning);
            return false;
        }

        public override string GetRole()
        {
            return "Quản trị";
        }

        public override bool CheckIn()
        {
            MessageBox.Show("Vai trò của bạn không thể thực hiện chức năng này!", "Quyền không khả dụng", MessageBoxButton.OK, MessageBoxImage.Warning);
            return false;
        }
    }
}
