import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { CourseType } from '../_helpers/course.enum';
import { RoleMapper } from '../_helpers/role-mapper';
import { Role } from '../_helpers/role.enum';
import { AccountService } from '../_services/account.service';
import { CourseService } from '../_services/course.service';
import { ICourse } from './models/course';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.scss']
})
export class CoursesComponent implements OnInit {

  type = CourseType;

  role = Role;

  userRole: Role = Role.Undefined;

  myCourses$: Observable<ICourse[]> | undefined;
  
  assignedCourses$: Observable<ICourse[]> | undefined;

  allCourses$: Observable<ICourse[]> | undefined;

  constructor(private courseService: CourseService,
    private accountService: AccountService) { }

  ngOnInit(): void {
    this.myCourses$ = this.courseService.getMyCourses();
    this.assignedCourses$ = this.courseService.getAssignedCourses();
    this.allCourses$ = this.courseService.getAllCourses();
    this.userRole = RoleMapper.RoleMapping(this.accountService.getRole());
  }
}
