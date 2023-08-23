import { HttpClient, HttpErrorResponse, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { IDoctor } from '../app/Interfaces/Doctor';
import { IUser } from '../app/Interfaces/User';

@Injectable({
  providedIn: 'root'
})
export class DoctorsService {
  constructor(private http: HttpClient) {

  }
  getDoctors(): Observable<IDoctor[]> {
    let temp = this.http.get<IDoctor[]>('https://localhost:7031/home/GetDoctors').pipe(catchError(this.errorhandler));
    return temp;
  }


  CheckValidUser(userName: string, password: string): Observable<boolean> {
    let userObj: IUser;
    //const body= { mailid: userName, password: password };
    userObj = { Mailid: userName, Password: password, Gender: "", Username: "", Useraddress: "", Pastproblems: "", Contactumber: 0, Firstname: "", Lastname:"" };
    //console.log(userObj);
    let result = this.http.post<boolean>('https://localhost:7031/home/CheckValidUser', userObj ).pipe(catchError(this.errorhandler));
    return result;
  }
  errorhandler(error: HttpErrorResponse) {
    console.log(error.message)
    return throwError(error.message || "Server Error");
  }
}
