import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
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

  role = Role;

  userRole: Role = Role.Undefined;

  myCourses: ICourse[] = [];

  assignedCourses: ICourse[] = [];

  constructor(private courseService: CourseService,
    private accountService: AccountService,
    private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.courseService.getMyCourses().subscribe((courses) => {
      if (courses) {
        this.myCourses = courses;
      }
    },
    (err) => {
      this.snackBar.open("Nie udało sie wczytać listy Twoich kursów!", '', { panelClass: ['text-white', 'bg-danger'] });
    });

    this.courseService.getAssignedCourses().subscribe((courses) => {
      if (courses) {
        this.myCourses = courses;
      }
    },
    (err) => {
      this.snackBar.open("Nie udało sie wczytać listy kursów do których jesteś przypisany!", '', { panelClass: ['text-white', 'bg-danger'] });
    });

    this.userRole = RoleMapper.RoleMapping(this.accountService.getRole());
  }
}
