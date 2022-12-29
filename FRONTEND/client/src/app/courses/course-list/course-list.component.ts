import { Component, Input, OnInit, Output, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Observable } from 'rxjs';
import { ICourse } from '../models/course';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CourseType } from 'src/app/_helpers/course.enum';
import { EventEmitter } from '@angular/core';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.scss']
})
export class CourseListComponent implements OnInit {

  @Output()
  deleteEvent = new EventEmitter<number>();

  @Output()
  assignEvent = new EventEmitter<ICourse>();

  @Output()
  unassignEvent = new EventEmitter<ICourse>();

  @Input() 
  courses$: Observable<ICourse[]> | undefined;

  @Input()
  courseType: CourseType = CourseType.My;

  isSpinning: boolean = true;

  type = CourseType;

  courses: ICourse[] = [];

  @ViewChild(MatPaginator) 
  paginator!: MatPaginator;

  @ViewChild(MatSort) 
  sort!: MatSort;

  displayedColumns: string[] = [];

  dataSource!:  MatTableDataSource<ICourse>;

  constructor(private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.initializeColumns();
    this.courses$?.subscribe((courses) => {
      this.courses = courses;
      this.courses.sort((courseA, courseB) => { return courseA.id - courseB.id} );
      this.dataSource = new MatTableDataSource(this.courses);
      this.paginate();
      
      this.isSpinning = false;
    },
    (err) => {
      this.snackBar.open(this.getLoadingError(), '', { panelClass: ['text-white', 'bg-danger'] });
    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  addCourse(course: ICourse): void {
    this.courses.push(course);
    console.log(this.courses);
    this.refreshList();
  }

  raiseDeleteCourse(courseId: number): void {
    this.cutListElement(courseId);
    this.deleteEvent.emit(courseId);
  }

  raiseAssignToCourse(course: ICourse): void {
    this.cutListElement(course.id);
    this.assignEvent.emit(course);
  }

  raiseUnassignFromCourse(course: ICourse): void {
    this.cutListElement(course.id);
    this.unassignEvent.emit(course);
  }

  getCreatorName(courseId: number): string {
    const course = this.courses.find((course) => course.id === courseId);

    if ((course.creatorFirstName !== null && course.creatorFirstName) != "" || (course.creatorSurname !== null && course.creatorSurname != "")) {
      return `${course.creatorFirstName} ${course.creatorSurname}`;
    }

    return "-";
  }

  private cutListElement(courseId: number): void {
    const courseIndex = this.courses.findIndex((crs) => crs.id === courseId );

    this.courses.splice(courseIndex, 1);
    this.refreshList();
  }

  private refreshList(): void {
    this.dataSource = new MatTableDataSource(this.courses);
  }

  private paginate(): void {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  private initializeColumns(): void {
    switch (this.courseType) {
      case CourseType.My:
        this.displayedColumns = ['get', 'update', 'delete', 'name', 'description'];
        break;
      case CourseType.All:
        this.displayedColumns = ['assign', 'name', 'description', 'creator'];
        break;
      default:
        this.displayedColumns = ['get', 'unassign', 'name', 'description', 'creator'];
        break;
    }
  }

  private getLoadingError(): string {
    switch (this.courseType) {
      case CourseType.Assigned:
        return "Nie udało sie wczytać listy kursów do których jesteś przypisany!";
      case CourseType.My:
        return "Nie udało sie wczytać listy moich kursów!";
      default:
        return "Nie udało się wczytać listy z dostępnymi kursami";
    }
  }
}
