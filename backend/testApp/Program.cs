// See https://aka.ms/new-console-template for more information

using Hospital.Dal;
using Hospital.Dal.Models;

HospitalRepo Hr= new HospitalRepo();
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


User user = new User();
user.Mailid = "gauravvidyu";
user.Password = "gauravvidyu";
user.Pastproblems = "gauravvidyu";
user.Contactumber = 3456789;
user.Username = "gauravvidyu";
user.Useraddress = "gauravvidyu";
user.Firstname = "gauravvidyu";
user.Lastname = "gauravvidyu";
user.Gender = "MALE";

bool r =Hr.registerNewUser(user);
Console.WriteLine(  r);