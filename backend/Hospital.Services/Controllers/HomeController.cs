using Hospital.Dal;
using Hospital.Dal.Models;
using Microsoft.AspNetCore.Mvc;

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
        public JsonResult GetUserAppintments(String id)
        {
            List <Appontment> userAppointMents = new List<Appontment>();
            try
            {
                userAppointMents = Repo.UserAppintments(id);
            }
            catch (Exception)
            {
                throw;
            }
            return Json(userAppointMents);
        }
        [HttpGet]
        public JsonResult DoctorAppintments(int DoctorId)
        {
            List<Appontment> doctorAppointments = new List<Appontment>();
            try
            {
                doctorAppointments = Repo.DoctorAppintments(DoctorId);
            }
            catch (Exception)
            {
                throw;
            }
            return Json(doctorAppointments);
        }
        #endregion
    }
}
