import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AccountComponent } from './account/account.component';
import { LoginComponent } from './account/login/login.component';
import { AccountsGenerateComponent } from './admin/accounts/accounts-generate/accounts-generate.component';
import { AccountsComponent } from './admin/accounts/accounts.component';
import { AdminCoursesComponent } from './admin/admin-courses/admin-courses.component';
import { AdminTestsComponent } from './admin/admin-tests/admin-tests.component';
import { AdminComponent } from './admin/admin.component';
import { CourseCreateComponent } from './courses/course-create/course-create.component';
import { CourseUpdateComponent } from './courses/course-update/course-update.component';
import { CourseComponent } from './courses/course/course.component';
import { CoursesComponent } from './courses/courses.component';
import { HomepageComponent } from './homepage/homepage.component';
import { AuthGuard } from './_guards/auth.guard';
import { SessionGuard } from './_guards/session.guard';

const routes: Routes = [
  { path: '', component: LoginComponent, canActivate: [SessionGuard]},

  /* ADMIN */
  { 
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    data: {
      role: 'Admin'
    },
    children: [
      { path: 'admin', component: AdminComponent },
      { path: 'admin/accounts', component: AccountsComponent },
      { path: 'admin/accounts/generate', component: AccountsGenerateComponent },
      { path: 'admin/courses', component: AdminCoursesComponent },
      { path: 'admin/tests', component: AdminTestsComponent }
    ]
  },

  /* ADMIN & TUTOR */
  { 
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    data: {
      role: 'Tutor'
    },
    children: [
      { path: 'courses/create', component: CourseCreateComponent },
      { path: 'courses/update/:id', component: CourseUpdateComponent }
    ]
  },

  /* ADMIN & TUTOR & USER */
  { 
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    data: {
      role: 'User'
    },
    children: [
      { path: 'homepage', component: HomepageComponent },
      { path: 'courses', component: CoursesComponent },
      { path: 'courses/:id', component: CourseComponent },
    ]
  },
  { path: '**', component: LoginComponent, pathMatch: 'full', canActivate: [SessionGuard]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
