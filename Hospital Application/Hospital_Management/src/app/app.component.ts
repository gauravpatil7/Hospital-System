import { Component, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { BreakpointObserver } from '@angular/cdk/layout';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  @ViewChild(MatSidenav) mat!: MatSidenav;
  title = 'Hospital_Management';
  constructor(private observer: BreakpointObserver) {
    this.ngAfterViewInit();
  }
  ngAfterViewInit() {
    this.observer.observe('[(max-width:800px)]').subscribe(
      (res) => {
        //if (res) {
        //  this.mat.mode = 'over';
        //  this.mat.open();
        //  console.log("desktop mode");
        //} else {
        //  this.mat.mode = 'side';
        //  this.mat.open();
        //  console.log("tablet mode");
        //}
      }
    );
  }

}
