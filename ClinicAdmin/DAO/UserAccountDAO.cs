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
        private string role;

        public string Role { get => role; set => role = value; }

        public UserAccountDAO() { }

        public UserAccountDAO(int id, string userName, string password, string fullname, string address, string email, string phone, string role)
        {
            this.id = id;
            this.Username = userName;
            this.Password = password;
            this.FullName = fullname;
            this.Address = address;
            this.Email = email;
            this.Phone = phone;
            this.Role = role;
        }
    }
}
