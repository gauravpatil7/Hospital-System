using Hospital.Dal.Models;

namespace Hospital.Dal
{
    public class HospitalRepo
    {
        HOSPITALContext HpContext;
        public HospitalRepo()
        {
            HpContext = new HOSPITALContext();
        }

        public List<Doctor> getDoctors()
        {
            List<Doctor> DoctorsList = new List<Doctor>();
            try
            {
                DoctorsList = (from dr in HpContext.Doctors select dr).ToList();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return DoctorsList;
        }

        public List<Appontment> GetAppointments()
        {
            List<Appontment> AppointmentsList = new List<Appontment>();
            try
            {
                AppointmentsList = (from dr in HpContext.Appontments select dr).ToList();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return AppointmentsList;
        }
    }
}