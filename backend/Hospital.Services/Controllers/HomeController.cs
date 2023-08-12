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

        [HttpGet]
        public JsonResult GetDoctors()
        {
            List<Doctor> Dl = new List<Doctor>();
            try
            {
                Dl = Repo.getDoctors();
                return Json(Dl);
            }
            catch (Exception)
            {

                throw;
            }

        }
        [HttpGet]
        public JsonResult GetUsers()
        {
            List<User> userList= new List<User>();
            return Json(userList);
        }

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
    }
}
