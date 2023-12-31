import { HttpClient, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, take, throwError } from 'rxjs';
import { IDoctor } from '../app/Interfaces/Doctor';
import { IUser } from '../app/Interfaces/User';
import { IUserAppointments } from '../app/Interfaces/UserAppointments';
import { IHospital } from '../app/Interfaces/Hospital';

@Injectable({
  providedIn: 'root'
})
export class DoctorsService {
  constructor(private http: HttpClient) {

  }
  getDoctors(): Observable<IDoctor[]> {
    let temp = this.http.get<IDoctor[]>('https://gauravpatil7-001-site1.gtempurl.com/home/GetDoctors').pipe(catchError(this.errorhandler));
    return temp;
  }

  CheckValidUser(userName: string, password: string): Observable<boolean> {
    let userObj: IUser;
    //const body= { mailid: userName, password: password };
    userObj = { Mailid: userName, Password: password, Gender: "", Username: "", Useraddress: "", Pastproblems: "", Contactumber: 0, Firstname: "", Lastname:"" };
    //console.log(userObj);
    let result = this.http.post<boolean>('https://gauravpatil7-001-site1.gtempurl.com/home/CheckValidUser', userObj ).pipe(catchError(this.errorhandler));
    return result;
  }

  registerNewUser(newUserObj: IUser): Observable<boolean>{
    let result = this.http.post<boolean>('https://gauravpatil7-001-site1.gtempurl.com/home/registerNewUser', newUserObj);
    //let result = this.http.post<boolean>('https://localhost:7031/home/registerNewUser', newUserObj);
    return result;
  }

  getUsersAppointmentsList(mailId: string): Observable<IUserAppointments[]> {
    //let param = { emailId: mailId }
    //let result = this.http.post<IUserAppointments[]>('https://gauravpatil7-001-site1.gtempurl.com/home/getUsersAppointmentsList', param).pipe(catchError(this.errorhandler));
    //let result = this.http.get<IUserAppointments[]>('$https://gauravpatil7-001-site1.gtempurl.com/home/getUsersAppointmentsList?emailId=abcd@gmail.COM{}').pipe(catchError(this.errorhandler));
    let param = new HttpParams().append("emailId", mailId);
    let result = this.http.get<IUserAppointments[]>('https://gauravpatil7-001-site1.gtempurl.com/home/getUsersAppointmentsList', { params:param }).pipe(catchError(this.errorhandler));
    return result;
  }

  getHospitalsList(): Observable<IHospital[]> {
    let result = this.http.get<IHospital[]>('https://gauravpatil7-001-site1.gtempurl.com/home/GetHospitals').pipe(catchError(this.errorhandler));
    return result;
  }
  addNewAppointment(dat: Date, userId: string, hId: number, dId: number): Observable<number> {
    let body = { Appontmentid: 1, Appointmenttime: dat, userId: userId, Hospitalid: hId, Doctorid: dId }
    let result = this.http.post<number>('https://gauravpatil7-001-site1.gtempurl.com/home/addappointment', body ).pipe(catchError(this.errorhandler));
    return result;
  }
  //delete
  removeUserAppointment(appointment: number): Observable<boolean> {
    let httpOptions = new HttpParams().append('aId', appointment)
    let result = this.http.delete<boolean>('https://gauravpatil7-001-site1.gtempurl.com/home/removeUserAppointment', { params: httpOptions }).pipe(catchError(this.errorhandler));
    return result;
  }
  errorhandler(error: HttpErrorResponse) {
    console.log(error.message)
    return throwError(error.message || "Server Error");
  }
}
