import { Component } from '@angular/core';
import { IUser } from '../Interfaces/User';
import { DoctorsService } from '../../services/doctors.service';
import { IUserAppointments } from '../Interfaces/UserAppointments';
import { ActivatedRoute } from '@angular/router';
import {MatSnackBar} from '@angular/material/snack-bar';
import { LoginComponent } from '../login/login.component';

@Component({
  selector: 'app-user-appointments',
  templateUrl: './user-appointments.component.html',
  styleUrls: ['./user-appointments.component.css']
})
export class UserAppointmentsComponent {

  userAppointmentsList: any;
  mail: string = "";
  constructor(private _service: DoctorsService, private _route: ActivatedRoute,
     private _snack: MatSnackBar) {
  }
  ngOnInit() {
    //modify it
    this.mail = <string>sessionStorage.getItem("username");
    this.getUsersAppointmentsList(this.mail)
  }
  getUsersAppointmentsList(mailId: string) {
    this._service.getUsersAppointmentsList(mailId).subscribe((res) => {
      this.userAppointmentsList = res
    });
  }
  cancelAppintment(aId: number) {
    this._service.removeUserAppointment(aId).subscribe(
      (res) => {
        if (res == true) {
          this._snack.open('Appointment Deleted successfully','Dismiss');
          this.ngOnInit();
        } else {
          this._snack.open("Can't delete Appointment','Try Again");
        }
      }
    );
  }
  call() {
  }

}
