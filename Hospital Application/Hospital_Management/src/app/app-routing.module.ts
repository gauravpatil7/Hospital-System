import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DoctorsListComponent } from './doctors-list/doctors-list.component';
import { UserAppointmentsComponent } from './user-appointments/user-appointments.component';
import { NormalNavComponent } from './normal-nav/normal-nav.component';
import { DoctorsAppointmentsComponent } from './doctors-appointments/doctors-appointments.component';
import { authGuard } from '../auth.guard';

const routes: Routes = [
  { path: '', component: DoctorsListComponent },
  { path: 'login', component: NormalNavComponent },
  { path: 'register', component: NormalNavComponent },
  { path: 'doctorslist', component: DoctorsListComponent, canActivate: [authGuard] },
  { path: 'userAppointments', component: UserAppointmentsComponent, canActivate: [authGuard] },
  { path: 'doctorAppointments', component: DoctorsAppointmentsComponent, canActivate: [authGuard] },
  { path: 'bookAppointments', component: UserAppointmentsComponent, canActivate: [authGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {

  constructor() {

  }
}
