using ClinicAdmin.DTO;
using ClinicAdmin.GUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClinicAdmin.DAO
{
    public class StaffDAO : UserDAO
    {
        private static StaffDAO _instance;

        public static StaffDAO getInstance()
        {
            if (_instance == null)
            {
                _instance = new StaffDAO();
            }
            return _instance;
        }

        public List<StaffDAO> GetListStaff()
        {
            List<StaffDAO> result = new List<StaffDAO>();
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                var entryPoint = (from m in context.Users
                                  where m.RoleId == (int)RoleEnum.STAFF
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
                    StaffDAO staff = new StaffDAO()
                    {
                        Id = item.id,
                        Username = item.Username,
                        Password = item.Password,
                        Fullname = item.Fullname,
                        Address = item.Address,
                        Email = item.Email,
                        Phone = item.Phone
                    };
                    result.Add(staff);
                }
            }
            return result;
        }

        public StaffDAO()
        {
        }

        public StaffDAO(int id, string userName, string password, string fullname, string address, string email, string phone)
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
            MessageBox.Show("Vai trò của bạn không thể thực hiện chức năng này!", "Quyền không khả dụng", MessageBoxButton.OK, MessageBoxImage.Warning);
            return false;
        }

        public override bool ChangeRegulation()
        {
            MessageBox.Show("Vai trò của bạn không thể thực hiện chức năng này!", "Quyền không khả dụng", MessageBoxButton.OK, MessageBoxImage.Warning);
            return false;
        }

        public override bool AddPatient()
        {
            return true;
        }

        public override bool AddPrescription()
        {
            MessageBox.Show("Vai trò của bạn không thể thực hiện chức năng này!", "Quyền không khả dụng", MessageBoxButton.OK, MessageBoxImage.Warning);
            return false;
        }

        //public override string GetRole()
        //{
        //    return "Nhân viên";
        //}

        public override bool CheckIn()
        {
            return true;
        }
    }
}
