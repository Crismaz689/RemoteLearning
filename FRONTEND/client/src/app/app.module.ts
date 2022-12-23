import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AccountComponent } from './account/account.component';
import { LoginComponent } from './account/login/login.component';
import { HomepageComponent } from './homepage/homepage.component';
import { AdminComponent } from './admin/admin.component';
import { NavigationComponent } from './navigation/navigation.component';
import { FooterComponent } from './footer/footer.component';
import { CoursesComponent } from './courses/courses.component';
import { CourseListComponent } from './courses/course-list/course-list.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSnackBarModule, MAT_SNACK_BAR_DEFAULT_OPTIONS } from '@angular/material/snack-bar';
import { CourseComponent } from './courses/course/course.component';
import { CourseCreateComponent } from './courses/course-create/course-create.component';
import { AuthInterceptor } from './_interceptors/auth-interceptor';
import { MatTableModule } from '@angular/material/table';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorIntl, MatPaginatorModule } from '@angular/material/paginator';
import { getPolishPaginatorIntl } from './_helpers/polish.paginator.intl';

@NgModule({
  declarations: [
    AppComponent,
    AccountComponent,
    LoginComponent,
    HomepageComponent,
    AdminComponent,
    NavigationComponent,
    FooterComponent,
    CoursesComponent,
    CourseListComponent,
    CourseComponent,
    CourseCreateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatSnackBarModule,
    MatTableModule,
    MatFormFieldModule,
    MatPaginatorModule,
    MatInputModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    { provide: MAT_SNACK_BAR_DEFAULT_OPTIONS, useValue: {
      duration: 5000,
      verticalPosition: 'bottom',
      horizontalPosition: 'right',
    }},
    { provide: MatPaginatorIntl, useValue: getPolishPaginatorIntl() }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
