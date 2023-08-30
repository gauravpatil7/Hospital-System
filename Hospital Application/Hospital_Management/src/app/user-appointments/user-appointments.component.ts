import { Component } from '@angular/core';
import { IUser } from '../Interfaces/User';
import { DoctorsService } from '../../services/doctors.service';
import { IUserAppointments } from '../Interfaces/UserAppointments';

@Component({
  selector: 'app-user-appointments',
  templateUrl: './user-appointments.component.html',
  styleUrls: ['./user-appointments.component.css']
})
export class UserAppointmentsComponent {

  userAppointmentsList: any;
  constructor(private _service: DoctorsService) {
  }
  ngOnInit() {
    //take snapshot of mail and pass it to method
    this.getUsersAppointmentsList("gp@v.com")
  }
  getUsersAppointmentsList(mailId: string) {
    this._service.getUsersAppointmentsList(mailId).subscribe((res) => {
      this.userAppointmentsList = res
    });
    console.log(this.userAppointmentsList);
  }
  cancelAppintment() {

  }
  call() {
  }

}
