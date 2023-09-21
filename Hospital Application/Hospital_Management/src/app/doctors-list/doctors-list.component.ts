import { Component } from '@angular/core';
import { IDoctor } from '../Interfaces/Doctor';
import { DoctorsService } from '../../services/doctors.service';
import { Router } from '@angular/router';
import { IUserAppointments } from '../Interfaces/UserAppointments';

@Component({
  selector: 'app-doctors-list',
  templateUrl: './doctors-list.component.html',
  styleUrls: ['./doctors-list.component.css']
})
export class DoctorsListComponent {
  DoctorList: any;
  isDataAvailable:boolean= false;
  constructor(private DoctorsService: DoctorsService, private _router: Router) {
  }
  ngOnInit() {
    this.getDoctors();
  }

  getDoctors() {
    this.DoctorsService.getDoctors().subscribe(
      (resSuccess) => {
        this.DoctorList = resSuccess;
        if(this.DoctorList.length>0){
          this.isDataAvailable=true;
        }
      }
    );
  }
  bookAppointment(doctor: any) {
    console.log(doctor.did);
    this._router.navigate(['/bookAppointments', doctor.worksin, doctor.did]);
  }
}
