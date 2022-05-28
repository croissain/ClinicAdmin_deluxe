using ClinicAdmin.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAdmin.DAO
{
    public abstract class UserDAO
    {
        private int id;
        private string username;
        private string password;
        private string fullname;
        private string address;
        private string phone;
        private string email;
        private RoleDAO role;

        public int Id { get => id; set => id = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Fullname { get => fullname; set => fullname = value; }
        public string Address { get => address; set => address = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public RoleDAO Role { get => role; set => role = value; }

        public abstract bool AddAccountUser();
        public abstract bool ChangeRegulation();
        public abstract bool AddPatient();
        public abstract bool AddPrescription();
        public abstract bool CheckIn();
        public abstract bool EditUser();
        public abstract bool RemoveUser();

        public abstract bool CancelAppointment();
    }
}
