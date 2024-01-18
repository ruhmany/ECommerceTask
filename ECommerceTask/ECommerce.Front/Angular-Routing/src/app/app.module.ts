import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { CoursesComponent } from './courses/courses.component';
import { RouterModule, Routes } from '@angular/router';
import { HeaderComponent } from './header/header.component';
import { CoursedetailsComponent } from './courses/coursedetails/coursedetails.component';
import { FooterComponent } from './footer/footer.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { LoginComponent } from './login/login.component';
import { FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

const approuts: Routes = [
  { path: '', component: LoginComponent },
  // {path:'', redirectTo:'Home', pathMatch: 'full'},
  { path: 'Courses', component: CoursesComponent },
  { path: 'Courses/Course/:id', component: CoursedetailsComponent },
  { path: '**', component: NotfoundComponent }
]

@NgModule({
  declarations: [
    AppComponent,
    CoursesComponent,
    HeaderComponent,
    CoursedetailsComponent,
    FooterComponent,
    NotfoundComponent,
    LoginComponent,
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(approuts),
    FormsModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
