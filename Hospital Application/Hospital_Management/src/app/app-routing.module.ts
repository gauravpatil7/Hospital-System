import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DoctorsListComponent } from './doctors-list/doctors-list.component';
import { UserAppointmentsComponent } from './user-appointments/user-appointments.component';
import { NormalNavComponent } from './normal-nav/normal-nav.component';
import { DoctorsAppointmentsComponent } from './doctors-appointments/doctors-appointments.component';
import { authGuard } from '../auth.guard';
import { BookAppointmentsComponent } from './book-appointments/book-appointments.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { EditUserProfileComponent } from './edit-user-profile/edit-user-profile.component';


const routes: Routes = [
  { path: '', component: DoctorsListComponent, title:"Home" },
  { path: 'login', component: NormalNavComponent, title:"Login" },
  { path: 'register', component: NormalNavComponent, title:"Register" },
  { path: 'doctorslist', component: DoctorsListComponent, canActivate: [authGuard], title:"Doctors List" },
  { path: 'userAppointments', component: UserAppointmentsComponent, canActivate: [authGuard], title:"Appointments" },
  { path: 'doctorAppointments', component: DoctorsAppointmentsComponent, canActivate: [authGuard], title:"Appointments" },
  { path: 'bookAppointments', component: BookAppointmentsComponent, canActivate: [authGuard],title:"Book Appointment" },
  { path: 'bookAppointments/:Worksin/:Did', component: BookAppointmentsComponent, canActivate: [authGuard], title:"Book Appointment" },
  { path: 'aboutUs', component: AboutUsComponent, title:"About Us"},
  { path:'editProfile', component:EditUserProfileComponent, title:"User Profile", canActivate:[authGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
  constructor() {

  }
}
