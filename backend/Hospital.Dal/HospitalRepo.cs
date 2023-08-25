using Hospital.Dal.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Hospital.Dal
{
    public class HospitalRepo
    {
        HOSPITALContext HpContext;
        public HospitalRepo()
        {
            HpContext = new HOSPITALContext();
        }
        #region getters
        
        public List<Doctor> GetDoctors()
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

        public List<Hospitall> GetHospitals()
        {
            List<Hospitall> HospitalList = new List<Hospitall>();
            try
            {
                HospitalList = (from hl in HpContext.Hospitalls select hl).ToList();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return HospitalList;
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

        public List<User> GetUsers()
        {
            List<User> UsersList = new List<User>();
            try
            {
                UsersList = (from user in HpContext.Users select user).ToList();
            }
            catch (Exception ex)
            {

                Console.WriteLine( ex.Message);
            }
            return UsersList;
        }
        #endregion

        #region getters by Id

        
        public bool checkValidUser(User obj)
        {
            bool status = false;
            User userObj = new User();
            try
            {
                userObj=(from user in HpContext.Users where obj.Mailid.Equals(user.Mailid)  select user).FirstOrDefault();
                if(userObj != null && userObj.Password==obj.Password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return status;
            }
        }

        //public bool registerUser(User obj)
        //{
        //    bool status = false;
        //    User userObj = new User();
        //    try
        //    {
        //        userObj = (from user in HpContext.Users where obj.Mailid.Equals(user.Mailid) select user).FirstOrDefault();
        //        if (userObj != null && userObj.Password == obj.Password)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return status;
        //    }
        //}

        public Doctor GetDoctorsById(int id)
        {
            Doctor Doc = new Doctor();
            try
            {
                Doc = (from d in HpContext.Doctors where d.Did == id select d).First<Doctor>();

            }
            catch (Exception)
            {

                throw;
            }

            return Doc;
        }
        public List<Appontment> UserAppointments(String userId)
        {
            List<Appontment> userAppointmentList = new List<Appontment>();
            try
            {
                userAppointmentList = (from n in HpContext.Appontments where n.Userid==userId select n).ToList();
            }
            catch (Exception)
            {
                Console.WriteLine("error while fecting appointments");
            }
            return userAppointmentList;
        }
        public List<Appontment> DoctorAppointments(int DoctorId)
        {
            List<Appontment> Dl = new List<Appontment>();
            try
            {
                Dl = (from l in HpContext.Appontments where l.Doctorid==DoctorId select l).ToList<Appontment>();
            }
            catch (Exception)
            {
                Console.WriteLine("error while fetching appointments");
            }
            return Dl;
        }

        public Hospitall GetHospitalById(int HId)
        {
            Hospitall hospital = new Hospitall();
            try
            {
                hospital = (from h in HpContext.Hospitalls where h.Hospitalid == HId select h).First();
            }
            catch (Exception)
            {

                throw;
            }
            return hospital;
        }

        #endregion

        #region add
        #endregion

        #region update
        #endregion

        #region delete

        public bool deleteUser(int UserId)
        {
            bool status = false;
            try
            {
                User user = new User();
                //user = HpContext.Users.Find(UserId);
                if (user != null)
                {
                    status = true;
                }
            }
            catch (Exception)
            {

                status = false;
            }
            return status;
        }
        #endregion

        #region stored procedue
        /*DECLARE 
@mailid @username @gender @pastproblems @contact @useraddress @password @firstname  @lastname varchar(10)='HUGY'
EXEC USP_USERREGISTER @mailid, @username, @gender, @pastproblems, @contact, @useraddress, @password, @firstname, @lastname
         */
        public bool registerNewUser(User newUserObj)
        {
            int result;
            try
            {

                SqlParameter Email = new SqlParameter("@mailid", newUserObj.Mailid);
                SqlParameter username = new SqlParameter("@username", newUserObj.Username);
                SqlParameter gender = new SqlParameter("@gender", newUserObj.Gender);
                SqlParameter pastproblems = new SqlParameter("@pastproblems", newUserObj.Pastproblems);
                SqlParameter contact = new SqlParameter("@contact", newUserObj.Contactumber);
                SqlParameter useraddress = new SqlParameter("@useraddress", newUserObj.Useraddress);
                SqlParameter password = new SqlParameter("@password", newUserObj.Password);
                SqlParameter firstname = new SqlParameter("@firstname", newUserObj.Firstname);
                SqlParameter lastname = new SqlParameter("@lastname", newUserObj.Lastname);

                result = HpContext.Database.ExecuteSqlRaw("EXEC USP_USERREGISTER @mailid, @username, @gender, @pastproblems, @contact, @useraddress, @password, @firstname, @lastname", Email, username, gender, pastproblems, contact, useraddress, password, firstname, lastname);
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        #endregion

    }
}