import { Component } from '@angular/core';
import { IDoctor } from '../Interfaces/Doctor';
import { DoctorsService } from '../../services/doctors.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-doctors-list',
  templateUrl: './doctors-list.component.html',
  styleUrls: ['./doctors-list.component.css']
})
export class DoctorsListComponent {
  DoctorList: any;
  constructor(private DoctorsService: DoctorsService, private _router:Router) {

  }
  ngOnInit() {
    if (sessionStorage.getItem('username') == null) {
      this._router.navigate(['/register']);
    }
    this.getDoctors();
  }

  getDoctors() {
    this.DoctorsService.getDoctors().subscribe(
      (resSuccess) => {
        this.DoctorList = resSuccess;
        console.log(this.DoctorList);
      }
    );
  }
}
