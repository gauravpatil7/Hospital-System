// See https://aka.ms/new-console-template for more information

using Hospital.Dal;
using Hospital.Dal.Models;

HospitalRepo Hr= new HospitalRepo();
List<Hospitall> hl = new List<Hospitall>();
hl = Hr.GetHospitals();
foreach (Hospitall item in hl)
{
    Console.WriteLine( item.Hospitalid);
    Console.WriteLine( item.Hospitalname);
    Console.WriteLine( item.Hospitaladdress);
    Console.WriteLine( item.Hospitalimage);
    Console.WriteLine(  "---------------------------------------------------------");
}