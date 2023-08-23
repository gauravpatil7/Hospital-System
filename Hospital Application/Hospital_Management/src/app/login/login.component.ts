import { Component, ViewChild } from '@angular/core';
import { FormGroup, FormControlName, FormControl, EmailValidator, Validators } from '@angular/forms';
import { MatSidenav } from '@angular/material/sidenav';
import { DoctorsService } from '../../services/doctors.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginForm = new FormGroup({
    emailRef: new FormControl('', [Validators.email]),
    passwordRef: new FormControl('', [Validators.minLength(4), Validators.maxLength(10), /*Validators.pattern('[a-z0-9A-Z]')*/]),
  });

  @ViewChild(MatSidenav) mat!: MatSidenav;
  result: any;
  login: boolean;
  emailRef: string;
  passwordRef: string;
  constructor(private _service: DoctorsService, private router: Router) {
    this.login = false;
    this.emailRef = "";
    this.passwordRef = "";
  }
  ngOnInit() {
  }

  logOrReg(btnType: string) {
    if (btnType == 'login') {
      this.login = true;
    } else {
      this.login = false;
    }
  }
  onSubmit() {
    this.emailRef = <string>this.loginForm.value.emailRef;
    this.passwordRef = <string>this.loginForm.value.passwordRef;
    this.result = this._service.CheckValidUser(this.emailRef, this.passwordRef).subscribe(
      (res) => {
        if (res == true) {
          sessionStorage.setItem('Email', this.emailRef);
          this.router.navigate(['/userappointments']);
        } else {
        }
      }
    );
  }
}
