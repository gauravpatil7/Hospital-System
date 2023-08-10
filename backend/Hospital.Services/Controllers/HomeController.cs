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
            Repo= new HospitalRepo();
        }

        [HttpGet]
        public JsonResult GetDoctors()
        {
            List<Doctor> Dl= new List<Doctor>();
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
    }
}
