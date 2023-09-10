// See https://aka.ms/new-console-template for more information

using Hospital.Dal;
using Hospital.Dal.Models;

HospitalRepo Hr= new HospitalRepo();


//List<UserAppointments> ll= new List<UserAppointments>();
//ll = Hr.GetUserAppointments("gp@v.com");
//Console.WriteLine("count :"+ll.Count) ;
//foreach (UserAppointments item in ll)
//{
//    Console.WriteLine(item.HospitalName);
//    Console.WriteLine(item.AppointmentDT);
//    Console.WriteLine(item.HospitalAddress);
//    Console.WriteLine(item.HospitalContact);
//    Console.WriteLine(  "---------------------------------------------------");
//}

//1001, 'GP@V.COM', 101, '2028-11-13 16:32:06'
//DateTime b = new DateTime(2024, 11, 01);
//Appontment a = new Appontment();
//a.Appontmentid = 1;
//a.Appointmenttime = b;
//a.Hospitalid = 1002;
//a.Userid = "GP@V.COM";
//a.Doctorid = 101;
//Console.WriteLine(Hr.AddAppointments(a));

//List<Hospitall> hl = new List<Hospitall>();
//hl = Hr.GetHospitals();
//bool result = false;//= Hr.CheckValidUser("GAURAVPATIL2360@GMAIL.COM", "3454");
//Console.WriteLine(result);

//foreach (Hospitall item in hl)
//{
//    Console.WriteLine( item.Hospitalid);
//    Console.WriteLine( item.Hospitalname);
//    Console.WriteLine( item.Hospitaladdress);
//    Console.WriteLine( item.Hospitalimage);
//    Console.WriteLine(  "---------------------------------------------------------");
//}


//User user = new User();
//user.Mailid = "gauravvidyu";
//user.Password = "gauravvidyu";
//user.Pastproblems = "gauravvidyu";
//user.Contactumber = 3456789;
//user.Username = "gauravvidyu";
//user.Useraddress = "gauravvidyu";
//user.Firstname = "gauravvidyu";
//user.Lastname = "gauravvidyu";
//user.Gender = "MALE";


//bool r =Hr.registerNewUser(user);
//Console.WriteLine(  r);

//''gp@v.com'


List<UserAppointments> ll = new List<UserAppointments>();
ll = Hr.GetUserAppointments("abcd@gmail.COM");
foreach (UserAppointments item in ll)
{
    Console.WriteLine(item.Appontmentid);
    Console.WriteLine(item.DoctorName);
    Console.WriteLine(item.HospitalAddress);
    Console.WriteLine(item.HospitalName);
    Console.WriteLine(item.HospitalContact);
}

//bool a= Hr.removeUserAppointment(10008);
//Console.WriteLine(a);