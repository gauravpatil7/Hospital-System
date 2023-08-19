import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { IDoctor } from '../app/Interfaces/Doctor';

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
  errorhandler(error: HttpErrorResponse) {
    console.error(error);
    return throwError(error.message || "Server Error");
  }
}
