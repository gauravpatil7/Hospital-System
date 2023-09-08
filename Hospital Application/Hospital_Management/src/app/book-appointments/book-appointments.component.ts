import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DoctorsService } from '../../services/doctors.service';
import { FormControl, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar'

@Component({
  selector: 'app-book-appointments',
  templateUrl: './book-appointments.component.html',
  styleUrls: ['./book-appointments.component.css']
})
export class BookAppointmentsComponent {
  userId: string;
  hId: number;
  dId: number;

  genApp = new FormGroup({
    dateRef: new FormControl(''),
  });

  constructor(private _router: Router, private _service: DoctorsService,
     private _route: ActivatedRoute, private _MatSnackBar:MatSnackBar) {
    this.userId = <string>sessionStorage.getItem('username');
    this.hId = this._route.snapshot.params['Worksin'];
    this.dId = this._route.snapshot.params['Did'];
  }
  ngOnInit() {
  }
  submitAppointment() {
    let str: string = <string>this.genApp.value.dateRef;
    let d: Date = new Date(str);
    this._service.addNewAppointment(d, this.userId, this.hId, this.dId).subscribe(
      (res) => {
        if (res == 7) {
          this.openSnackBar('Appointment Added Successfully','Dismiss');
          this._router.navigate(['/userAppointments']);
        } else if (res == -1) {
          this.openSnackBar('Please future appointment time','Dismiss');
        }else if (res == -2) {
          this.openSnackBar('You are invalid user, please login again','Dismiss');
          sessionStorage.removeItem('username');
          this.ngOnInit();
        }else if (res == -3) {
          this.openSnackBar('Try different hospital','Dismiss');
        }else if (res == -4) {
          this.openSnackBar('Invalid Doctor selected','Dismiss');
        }
        else if (res == -5) {
          this.openSnackBar('You already booked appointment in this slot','Try different timeSlot');
        }
        else if (res == -6) {
          this.openSnackBar('Doctor already have appointment in this slot','Try different timeSlot')
        }
        else {
          this.openSnackBar('Some error occured!','Dismiss')
        }
      }
    );
  }
  openSnackBar(message:string, action:string){
      this._MatSnackBar.open(message, action);
  }
}
