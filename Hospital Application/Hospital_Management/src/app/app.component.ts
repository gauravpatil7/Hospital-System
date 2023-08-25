import { Component, ViewChild } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Hospital_Management';
  status = false;
  constructor(private _router: Router) {

  }
  ngOnInit() {
    if (sessionStorage.getItem('username') == null) {
      this.status = true;
    }
  }
}
