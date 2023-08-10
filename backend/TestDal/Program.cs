using Hospital.Dal;
using Hospital.Dal.Models;

namespace TestDal
{
    internal class Program
    {
        public Program()
        {
            
        }
        static void Main(string[] args)
        {
            //List<Doctor> ll= new List<Doctor>();
            //try
            //{
            //    HospitalRepo HRepoObj = new HospitalRepo();
            //    ll = HRepoObj.getDoctors();
            //    foreach (Doctor doctor in ll)
            //    {
            //        Console.WriteLine(doctor.Did+"  "+ doctor.Dname + "  " + doctor.Dimage + "  " + doctor.Worksin + "  " + doctor.Appontments.Count());
            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}

            List<Appontment> ll;
            try
            {
                HospitalRepo HRepoObj = new HospitalRepo();
                ll = HRepoObj.GetAppointments();
                foreach (Appontment item in ll) {
                    Console.WriteLine(item.Hospitalid);
                    Console.WriteLine(item.Appontmentid);
                    Console.WriteLine(item.Userid);
                    Console.WriteLine(item.Appointmenttime);
                    Console.WriteLine(  "__________________________________________________________________");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}