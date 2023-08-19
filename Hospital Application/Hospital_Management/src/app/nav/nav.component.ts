import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Component, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent {
  @ViewChild(MatSidenav)
  navBar!: MatSidenav;
  constructor(private observer: BreakpointObserver) {

  }
  ngAfterViewInit() {
    this.observer.observe(['(max-width: 800px)']).subscribe(
      (res) => {
        if (res) {
          console.log("destop");
        } else {
          console.log("tablet");
        }
      }
    );
  }
  munuClicked() {
    this.navBar.toggle();
  }
}
