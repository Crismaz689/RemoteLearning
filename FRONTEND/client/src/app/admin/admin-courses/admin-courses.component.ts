import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ICourse } from 'src/app/courses/models/course';
import { CourseService } from 'src/app/_services/course.service';

@Component({
  selector: 'app-admin-courses',
  templateUrl: './admin-courses.component.html',
  styleUrls: ['./admin-courses.component.scss']
})
export class AdminCoursesComponent implements OnInit {

  @ViewChild(MatPaginator) 
  paginator: MatPaginator;

  @ViewChild(MatSort) 
  sort: MatSort;

  courses: ICourse[] = [];

  displayedColumns: string[] = ['delete', 'update', 'name', 'description', 'creator'];

  dataSource: MatTableDataSource<ICourse>;

  isSpinning: boolean = true;

  constructor(private courseService: CourseService,
    private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.courseService.getAdminAllCourses().subscribe((courses) => {
      this.courses = courses;
      this.paginate();
      this.isSpinning = false;
    });
  }

  paginate(): void {
    this.dataSource = new MatTableDataSource(this.courses);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  deleteCourse(courseId: number): void {
    this.courseService.deleteCourse(courseId).subscribe((isDeleted) => {
      if (isDeleted) {
        const courseIndex = this.courses.findIndex((cours) => cours.id === courseId);
        this.courses.splice(courseIndex, 1);
        this.paginate();
        this.snackBar.open("Kurs usunięty.", '', { panelClass: ['text-white', 'bg-success'] });
      }
      else {
        this.snackBar.open("Błąd podczas usuwania kursu.", '', { panelClass: ['text-white', 'bg-danger'] });
      }
    },
    (err) => {
      this.snackBar.open("Błąd podczas usuwania kursu.", '', { panelClass: ['text-white', 'bg-danger'] });
    });
  }

  getCreatorName(courseId: number): string {
    const course = this.courses.find((course) => course.id === courseId);

    if ((course.creatorFirstName !== null && course.creatorFirstName) != "" || (course.creatorSurname !== null && course.creatorSurname != "")) {
      return `${course.creatorFirstName} ${course.creatorSurname}`;
    }

    return "-";
  }
}
