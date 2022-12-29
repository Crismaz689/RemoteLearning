import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './account/login/login.component';
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
