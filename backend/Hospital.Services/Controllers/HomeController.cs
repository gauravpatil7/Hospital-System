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
        public JsonResult GetDoctorsById(int id)
        {
            Doctor Doc = new Doctor();
            try
            {
                Doc = Repo.GetDoctorsById(id);
                return Json(Doc);
            }
            catch (Exception)
            {

                throw;
            }

        }
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
                    listServType.Add(obj);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return Json(listServType);
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
        #endregion
    }
}
