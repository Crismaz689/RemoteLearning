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
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { getPolishPaginatorIntl } from './_helpers/polish.paginator.intl';
import { CourseUpdateComponent } from './courses/course-update/course-update.component';
import { SpinnerComponent } from './spinner/spinner.component';
import { SectionsComponent } from './courses/sections/sections.component';
import { FilesComponent } from './courses/sections/files/files.component';
import { SectionCreateComponent } from './courses/sections/section-create/section-create.component';
import { MatDialogModule } from '@angular/material/dialog';
import { SectionUpdateComponent } from './courses/sections/section-update/section-update.component';
import { AccountsComponent } from './admin/accounts/accounts.component';
import { AccountsGenerateComponent } from './admin/accounts/accounts-generate/accounts-generate.component';
import { AccountsListComponent } from './admin/accounts/accounts-list/accounts-list.component';
import { AdminCoursesComponent } from './admin/admin-courses/admin-courses.component';
import { FileCreateComponent } from './courses/sections/files/file-create/file-create.component';
import { TestsComponent } from './courses/tests/tests.component';
import { TextQuestionsComponent } from './courses/tests/text-questions/text-questions.component';
import { TestCreateComponent } from './courses/tests/test-create/test-create.component';
import { TestUpdateComponent } from './courses/tests/test-update/test-update.component';
import { TextQuestionCreateComponent } from './courses/tests/text-questions/text-question-create/text-question-create.component';
import { TextQuestionUpdateComponent } from './courses/tests/text-questions/text-question-update/text-question-update.component';
import { TestComponent } from './courses/tests/test/test.component';

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
    CourseCreateComponent,
    CourseUpdateComponent,
    SpinnerComponent,
    SectionsComponent,
    FilesComponent,
    SectionCreateComponent,
    SectionUpdateComponent,
    AccountsComponent,
    AccountsGenerateComponent,
    AccountsListComponent,
    AdminCoursesComponent,
    FileCreateComponent,
    TestsComponent,
    TextQuestionsComponent,
    TestCreateComponent,
    TestUpdateComponent,
    TextQuestionCreateComponent,
    TextQuestionUpdateComponent,
    TestComponent
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
    MatProgressSpinnerModule,
    MatDialogModule
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
