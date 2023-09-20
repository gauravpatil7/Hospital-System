import { Component, ViewChild } from '@angular/core';
import { FormGroup, FormControlName, FormControl, EmailValidator, Validators } from '@angular/forms';
import { DoctorsService } from '../../services/doctors.service';
import { IUser } from '../Interfaces/User';
import { Router } from '@angular/router';
import {MatSnackBar} from '@angular/material/snack-bar';

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

  constructor(private _service: DoctorsService, private router: Router, private _snackbar: MatSnackBar) {
    this.login = false;
    this.emailRef = "";
    this.userId = <string>sessionStorage.getItem('username');
    console.log(this.userId);

  }
  login: boolean;
  emailRef: string;
  gender: string = "";
  userId: string;
  btnType:string = 'Register';

  ngOnInit() {
  }

  registerForm = new FormGroup({
    mailId: new FormControl('', [Validators.email, Validators.required]),
    username: new FormControl('', [Validators.minLength(3), Validators.maxLength(10), Validators.required]),
    pastproblems: new FormControl(''),
    contactNumber: new FormControl(0,[Validators.min(1111111111), Validators.max(9999999999), Validators.required]),
    userAddress: new FormControl('', Validators.required),
    password: new FormControl('', [Validators.required, Validators.minLength(8), Validators.maxLength(12), /*Validators.pattern('[a-z0-9A-Z]')*/]),
    firstName: new FormControl('', [Validators.minLength(3), Validators.maxLength(10),Validators.required]),
    lastName: new FormControl('', [Validators.minLength(3), Validators.maxLength(10), Validators.required]),
  });


  //btnchange
  logOrReg(btnType: string) {
    if (btnType == 'Login') {
      this.btnType='Login';
      this.login = true;
    } else {
      this.btnType='Register';
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
          this._snackbar.open('You are logged in successfully');
          window.location.reload();
        } else {
          this._snackbar.open('Please, check userId or password','Try again!');
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
          sessionStorage.setItem('username', newUserObj.Firstname);
          sessionStorage.setItem('Email', newUserObj.Mailid);
          window.location.reload();
          this._snackbar.open("Registration successfull","Dismiss");
        } else {
          this._snackbar.open("cannot register please check your connection","Dismiss");
        }
      }
    );
  }
}
