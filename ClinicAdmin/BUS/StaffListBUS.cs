using ClinicAdmin.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClinicAdmin.BUS
{
    public class StaffListBUS
    {
        private static StaffListBUS _instance;
        public List<DoctorDAO> listDoctors;
        public List<StaffDAO> listStaffs;
        public List<AdminDAO> listAdmins;

        public static StaffListBUS getInstance()
        {
            if (_instance == null)
            {
                _instance = new StaffListBUS();
            }
            return _instance;
        }

        public void BUSLayer_Loaded()
        {
            listDoctors = DoctorDAO.getInstance().GetListDoctor();
            listAdmins = AdminDAO.getInstance().GetListAdmin();
            listStaffs = StaffDAO.getInstance().GetListStaff();
        }

        public void RemoveUser(int id)
        {
            if(MessageBox.Show("Bạn chắc chắn muốn xóa?","Xóa người dùng", MessageBoxButton.YesNo, MessageBoxImage.Warning ) == MessageBoxResult.Yes)
            {
                if(UserFactory.RemoveUser(id))
                {
                    MessageBox.Show("Xoá thành công!");
                }
            }
        }
    }
}
