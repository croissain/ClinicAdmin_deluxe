using ClinicAdmin.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAdmin.DAO
{
    public class ScheduleDAO: Schedule
    {
        private static ScheduleDAO _instance;

        public static ScheduleDAO getInstance()
        {
            if (_instance == null)
            {
                _instance = new ScheduleDAO();
            }
            return _instance;
        }

        public void CheckIn(int patientId, int scheduleId)
        {
            using(ClinicAdminEntities context = new ClinicAdminEntities())
            {
                var schedule = new Schedule() { id = scheduleId, PatientId = patientId, Status = 1 };
                context.Schedules.Attach(schedule);
                context.Entry(schedule).Property(x => x.Status).IsModified = true;
                context.SaveChanges();
            }
        }

        //public void CheckOut(int patientId, int scheduleId)
        //{
        //    using (ClinicAdminEntities context = new ClinicAdminEntities())
        //    {
        //        var schedule = new Schedule() { id = scheduleId, PatientId = patientId, Status = 0 };
        //        context.Schedules.Attach(schedule);
        //        context.Entry(schedule).Property(x => x.Status).IsModified = true;
        //        context.SaveChanges();
        //    }
        //}
    }
}
