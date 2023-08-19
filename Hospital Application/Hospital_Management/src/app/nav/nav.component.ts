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
    this.observer.observe(['(max-width:800px)']).subscribe(
      (res) => {
        if (res.matches) {
          this.navBar.mode = 'over';
          this.navBar.close();
        } else {
          this.navBar.mode = 'side';
          this.navBar.open();
        }
      }
    );
  }
  munuClicked() {
    this.navBar.toggle();
  }
}
