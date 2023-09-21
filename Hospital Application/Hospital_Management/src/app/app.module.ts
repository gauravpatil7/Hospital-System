import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { DoctorsListComponent } from './doctors-list/doctors-list.component';
import { AboutUsComponent } from './about-us/about-us.component';
import { LoginComponent } from './login/login.component';
import { UserAppointmentsComponent } from './user-appointments/user-appointments.component';
import { NormalNavComponent } from './normal-nav/normal-nav.component';
import { DoctorsAppointmentsComponent } from './doctors-appointments/doctors-appointments.component';
import { BookAppointmentsComponent } from './book-appointments/book-appointments.component';


import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import {MatSnackBarModule} from '@angular/material/snack-bar'
//import { MatDatepickerModule } from '@angular/material/datepicker';
//import { MatNativeDateModule } from '@angular/material/core'
import { DateTimePickerModule } from '@syncfusion/ej2-angular-calendars';
import { EditUserProfileComponent } from './edit-user-profile/edit-user-profile.component'



@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    DoctorsListComponent,
    LoginComponent,
    UserAppointmentsComponent,
    NormalNavComponent,
    DoctorsAppointmentsComponent,
    BookAppointmentsComponent,
    AboutUsComponent,
    EditUserProfileComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatButtonModule,
    MatDividerModule,
    MatSidenavModule,
    MatCardModule,
    MatIconModule,
    HttpClientModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    DateTimePickerModule,
    MatSnackBarModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
