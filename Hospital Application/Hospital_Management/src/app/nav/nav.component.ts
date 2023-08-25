import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Component, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent {
  username:any;

  @ViewChild(MatSidenav)
  navBar!: MatSidenav;
  constructor(private observer: BreakpointObserver) {

  }
  ngOnInit() {
    if (sessionStorage.getItem('username')!=null) {
      this.username = sessionStorage.getItem('username');
    }
    
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
