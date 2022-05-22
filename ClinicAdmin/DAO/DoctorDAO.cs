using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ClinicAdmin.DTO;
using ClinicAdmin.GUI;

namespace ClinicAdmin.DAO
{
    public class DoctorDAO : UserDAO
    {
        private static DoctorDAO _instance;

        public static DoctorDAO getInstance()
        {
            if (_instance == null)
            {
                _instance = new DoctorDAO();
            }
            return _instance;
        }

        public List<DoctorDAO> GetListDoctor()
        {
            List<DoctorDAO> result = new List<DoctorDAO>();
            using (ClinicAdminEntities context = new ClinicAdminEntities())
            {
                var entryPoint = (from m in context.Users
                                  where m.RoleId == (int)RoleEnum.DOCTOR
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
                    DoctorDAO doctor = new DoctorDAO()
                    {
                        Id = item.id,
                        Username = item.Username,
                        Password = item.Password,
                        Fullname = item.Fullname,
                        Address = item.Address,
                        Email = item.Email,
                        Phone = item.Phone
                    };
                    result.Add(doctor);
                }
            }
            return result;
        }

        public DoctorDAO() { }

        public DoctorDAO(int id, string userName, string password, string fullname, string address, string email, string phone)
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
            return true;
        }

        //public override string GetRole()
        //{
        //    return "Bác sĩ";
        //}

        public override bool CheckIn()
        {
            return true;
        }
    }
}
