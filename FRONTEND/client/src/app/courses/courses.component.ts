import { Component, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Observable } from 'rxjs';
import { CourseType } from '../_helpers/course.enum';
import { RoleMapper } from '../_helpers/role-mapper';
import { Role } from '../_helpers/role.enum';
import { AccountService } from '../_services/account.service';
import { CourseAssignmentService } from '../_services/course-assignment.service';
import { CourseService } from '../_services/course.service';
import { CourseListComponent } from './course-list/course-list.component';
import { ICourse } from './models/course';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.scss']
})
export class CoursesComponent implements OnInit {

  @ViewChildren('courseList')
  coursesLists: QueryList<CourseListComponent>;

  type = CourseType;

  role = Role;

  userRole: Role = Role.Undefined;

  myCourses$: Observable<ICourse[]> | undefined;
  
  assignedCourses$: Observable<ICourse[]> | undefined;

  allCourses$: Observable<ICourse[]> | undefined;

  constructor(private courseService: CourseService,
    private courseAssignmentsService: CourseAssignmentService,
    private accountService: AccountService,
    private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.myCourses$ = this.courseService.getMyCourses();
    this.assignedCourses$ = this.courseService.getAssignedCourses();
    this.allCourses$ = this.courseService.getAllCourses();
    this.userRole = RoleMapper.RoleMapping(this.accountService.getRole());
  }

  deleteCourse(courseId: number): void {
    this.courseService.deleteCourse(courseId).subscribe((isDeleted) => {
      if (isDeleted) {
        this.snackBar.open("Kurs usunięty.", '', { panelClass: ['text-white', 'bg-success'] });
      }
      else {
        this.snackBar.open("Błąd podczas usuwania kursu.", '', { panelClass: ['text-white', 'bg-danger'] });
      }
    },
    (err) => {
      this.snackBar.open("Nie możesz usunąć tego kursu.", '', { panelClass: ['text-white', 'bg-danger'] });
    });
  }

  assignToCourse(course: ICourse): void {
    this.courseAssignmentsService.assignToCourse(course.id).subscribe((id) => {
      if (id !== -1) {
        this.snackBar.open("Zostałeś przypisany do kursu.", '', { panelClass: ['text-white', 'bg-success'] });
        this.coursesLists.get(0).addCourse(course);
      }
    },
    (err) => {
      this.snackBar.open("Nie udało sie przypisać do kursu. Prawdopodobnie jestes już przypisany lub jesteś jego właścicielem.", '', { panelClass: ['text-white', 'bg-danger'] });
    });
  }

  unassignFromCourse(course: ICourse): void {
    this.courseAssignmentsService.unassignFromCourse(course.id).subscribe((isDeleted) => {
      if (isDeleted) {
        this.snackBar.open("Zostałeś wypisany z kursu..", '', { panelClass: ['text-white', 'bg-success'] });
        this.coursesLists.get(1).addCourse(course);
      }
      else {
        this.snackBar.open("Błąd podczas wypisywania z kursu.", '', { panelClass: ['text-white', 'bg-danger'] });
      }
    },
    (err) => {
      this.snackBar.open("Błąd podczas wypisywania z kursu.", '', { panelClass: ['text-white', 'bg-danger'] });
    });
  }
}
