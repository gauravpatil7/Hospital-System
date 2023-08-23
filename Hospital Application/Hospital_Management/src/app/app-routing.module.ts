import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DoctorsListComponent } from './doctors-list/doctors-list.component';
import { LoginComponent } from './login/login.component';
import { UserAppointmentsComponent } from './user-appointments/user-appointments.component';

const routes: Routes = [
  { path: '', component: DoctorsListComponent },
  { path: 'doctorslist', component: DoctorsListComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: LoginComponent },
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
