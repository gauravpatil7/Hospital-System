import { Component,ViewChild } from '@angular/core';
import { LoginComponent } from '../login/login.component';

@Component({
  selector: 'app-normal-nav',
  templateUrl: './normal-nav.component.html',
  styleUrls: ['./normal-nav.component.css']
})
export class NormalNavComponent {
  @ViewChild(LoginComponent)
  btnType!:LoginComponent;
  status:string = '';

  // ngOnInit(){
  //   this.status=this.btnType.btnType;
  // }

  ngAfterViewInit(){
    this.status=this.btnType.btnType;
    console.log(this.status);
  }
  constructor(){
  }
}

