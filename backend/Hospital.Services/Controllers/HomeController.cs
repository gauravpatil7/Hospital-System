using Hospital.Dal;
using Hospital.Dal.Models;
using Hospital.Services.Models;
using Microsoft.AspNetCore.Mvc;
using UserAppointments = Hospital.Dal.Models.UserAppointments;

namespace Hospital.Services.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        HospitalRepo Repo;
        public HomeController()
        {
            Repo = new HospitalRepo();
        }
        #region getters
        [HttpGet]
        public JsonResult GetDoctors()
        {
            List<Doctor> Dl = new List<Doctor>();
            try
            {
                Dl = Repo.GetDoctors();
                return Json(Dl);
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpGet]
        public JsonResult GetHospitals()
        {
            List<Hospitall> hl= new List<Hospitall>();
            try
            {
                hl = Repo.GetHospitals();
            }
            catch (Exception)
            {

                throw;
            }
            return Json(hl);    
        }

        [HttpGet]
        public JsonResult GetAppointments()
        {
            List<Appontment> appointmentList = new List<Appontment>();
            try
            {
                appointmentList = Repo.GetAppointments();
            }
            catch (Exception)
            {

                throw;
            }
            return Json(appointmentList);
        }
        [HttpGet]
        public JsonResult GetUsers()
        {
            List<User> userList= new List<User>();
            try
            {
                userList=Repo.GetUsers();
            }
            catch (Exception)
            {

                throw;
            }
            return Json(userList);
        }
        
        #endregion


        #region get by Id


        [HttpGet]
        public JsonResult DoctorAppointments(int DoctorId)
        {
            List<Appontment> doctorAppointments = new List<Appontment>();
            try
            {
                doctorAppointments = Repo.DoctorAppointments(DoctorId);
            }
            catch (Exception)
            {
                throw;
            }
            return Json(doctorAppointments);
        }

        [HttpPost]
        public JsonResult CheckValidUser(User userObj)
        {
            bool result = false;
            try
            {
                result = Repo.checkValidUser(userObj);
            }
            catch (Exception)
            {
                result = false;
            }
            return Json(result);
        }

        [HttpGet]
        public JsonResult getUsersAppointmentsList(string emailId)
        {
            
            List<UserAppointments> ListDalType = new List<UserAppointments>();
            List<Models.UserAppointments> listServType = new List<Models.UserAppointments>();
            try
            {
                ListDalType = Repo.GetUserAppointments(emailId);
                foreach (UserAppointments item in ListDalType)
                {
                    Models.UserAppointments obj = new Models.UserAppointments();
                    obj.AppointmentDT = item.AppointmentDT;
                    obj.HospitalName = item.HospitalName;
                    obj.HospitalAddress = item.HospitalAddress;
                    obj.HospitalContact = item.HospitalContact;
                    obj.DoctorName = item.DoctorName;
                    obj.Appontmentid = item.Appontmentid;
                    listServType.Add(obj);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return Json(listServType);
        }

        // bookAppointments Component API methods
        //[HttpGet]
        //public JsonResult GetDoctorsById(int id)
        //{
        //    Doctor doctor = new Doctor();
        //    try
        //    {
        //        doctor = Repo.GetDoctorsById(id);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return Json(doctor);
        //}

        //[HttpGet]
        //public JsonResult GetHospitalsById(int id)
        //{
        //    Hospitall hospital = new Hospitall();
        //    try
        //    {
        //        hospital = Repo.GetHospitalById(id);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return Json(hospital);
        //}
        //[HttpGet]
        //public JsonResult getHospitalsList()
        //{
        //    List<Hospitall> hospitalsList = new List<Hospitall>();
        //    try
        //    {
        //        hospitalsList = Repo.getHospitalsList();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return Json(hospitalsList);
        //}

        [HttpGet]
        public JsonResult getDoctorsList()
        {
            List<Doctor> DoctorsList = new List<Doctor>();
            try
            {
                DoctorsList = Repo.getDoctorsList();
            }
            catch (Exception)
            {

                throw;
            }
            return Json(DoctorsList);
        }
        #endregion

        #region Delete
        [HttpDelete]
        public JsonResult removeUserAppointment(int aId)
        {
            bool status = false;
            try
            {
                status = Repo.removeUserAppointment(aId);
            }
            catch (Exception)
            {

                throw;
            }
            return Json(status);
        }
        #endregion

        #region stored procedue
        [HttpPost]
        public bool registerNewUser(User userObj)
        {
            bool status = false;
            try
            {
               return status = Repo.registerNewUser(userObj);
            }
            catch (Exception)
            {

                return status;
            }
        }

        [HttpPost]
        public JsonResult addAppointment(Appontment newAppointment)
        {
            int result = 0;
            try
            {
                result= Repo.AddAppointments(newAppointment);
            }
            catch
            {
                result = -99;
            }
            return Json(result);
        }

        #endregion
    }
}
