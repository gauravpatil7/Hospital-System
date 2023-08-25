import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DoctorsListComponent } from './doctors-list/doctors-list.component';
import { LoginComponent } from './login/login.component';
import { UserAppointmentsComponent } from './user-appointments/user-appointments.component';
import { NormalNavComponent } from './normal-nav/normal-nav.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: '', component: DoctorsListComponent },
  { path: 'home', component: HomeComponent },
  { path: 'doctorslist', component: DoctorsListComponent },
  { path: 'login', component: NormalNavComponent },
  { path: 'register', component: NormalNavComponent },
  { path: 'userappointments', component: UserAppointmentsComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

  constructor() {

  }
}
