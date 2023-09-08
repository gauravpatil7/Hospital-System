import { Component, ViewChild } from '@angular/core';
import { FormGroup, FormControlName, FormControl, EmailValidator, Validators } from '@angular/forms';
import { DoctorsService } from '../../services/doctors.service';
import { IUser } from '../Interfaces/User';
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


  registerForm = new FormGroup({
    mailId: new FormControl('', [Validators.email, Validators.required]),
    username: new FormControl('', [Validators.minLength(3), Validators.maxLength(10), Validators.required]),
    pastproblems: new FormControl(''),
    contactNumber: new FormControl(234567890, [Validators.minLength(10), Validators.maxLength(10), Validators.required]),
    userAddress: new FormControl('', Validators.required),
    password: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(10), /*Validators.pattern('[a-z0-9A-Z]')*/]),
    firstName: new FormControl('', [Validators.minLength(3), Validators.maxLength(10),Validators.required]),
    lastName: new FormControl('', [Validators.minLength(3), Validators.maxLength(10), Validators.required]),
  });

  
  login: boolean;
  emailRef: string;
  gender: string = "";
  userId: string;
  constructor(private _service: DoctorsService, private router: Router) {
    this.login = false;
    this.emailRef = "";
    this.userId = <string>sessionStorage.getItem('username');
    console.log(this.userId);

  }
  ngOnInit() {
  }
  //btnchange
  logOrReg(btnType: string) {
    if (btnType == 'login') {
      this.login = true;
    } else {
      this.login = false;
    }
  }
  //login submit
  onSubmit() {
    this.emailRef = <string>this.loginForm.value.emailRef;
    this._service.CheckValidUser(this.emailRef, <string>this.loginForm.value.passwordRef).subscribe(
      (res) => {
        if (res == true) {
          sessionStorage.setItem('Email', this.emailRef);
          //needs to implement
          sessionStorage.setItem('username', this.emailRef);
          window.alert("Login Successfull");
          window.location.reload();
        } else {
          window.alert("Please, Check UserId or Password and try again!");
        }
      }
    );
  }
  //selector
  selectorOnChange($event: any) {
    this.gender = $event.value;
  }

  //register
  onRegisterSubmit() {
    let newUserObj: IUser;
    newUserObj = {
      Mailid: <string>this.registerForm.value.mailId,
      Password: <string>this.registerForm.value.password,
      Gender: this.gender,
      Username: <string>this.registerForm.value.username,
      Useraddress: <string>this.registerForm.value.userAddress,
      Pastproblems: <string>this.registerForm.value.pastproblems,
      Contactumber: <number>this.registerForm.value.contactNumber,
      Firstname: <string>this.registerForm.value.firstName,
      Lastname: <string>this.registerForm.value.lastName,
    };

    this._service.registerNewUser(newUserObj).subscribe(
      (res) => {
        if (res == true) {
          window.alert("register successfully");
          sessionStorage.setItem('username', newUserObj.Firstname);
          sessionStorage.setItem('Email', newUserObj.Mailid);
          this.router.navigate(['']);
          this.ngOnInit();
        } else {
          console.log("register unsuccessful");
        }
      }
    );
  }
}
