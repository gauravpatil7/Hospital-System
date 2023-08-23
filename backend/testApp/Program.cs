// See https://aka.ms/new-console-template for more information

using Hospital.Dal;
using Hospital.Dal.Models;

HospitalRepo Hr= new HospitalRepo();
//List<Hospitall> hl = new List<Hospitall>();
//hl = Hr.GetHospitals();
bool result = Hr.CheckValidUser("GAURAVPATIL2360@GMAIL.COM", "3454");
Console.WriteLine(result);

//foreach (Hospitall item in hl)
//{
//    Console.WriteLine( item.Hospitalid);
//    Console.WriteLine( item.Hospitalname);
//    Console.WriteLine( item.Hospitaladdress);
//    Console.WriteLine( item.Hospitalimage);
//    Console.WriteLine(  "---------------------------------------------------------");
//}