import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Observable } from 'rxjs';
import { ICourse } from '../models/course';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CourseType } from 'src/app/_helpers/course.enum';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.scss']
})
export class CourseListComponent implements OnInit {

  @Input() 
  courses$: Observable<ICourse[]> | undefined;

  @Input()
  courseType: CourseType = CourseType.My;

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

  private paginate(): void {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  private initializeColumns(): void {
    switch (this.courseType) {
      case CourseType.My:
        this.displayedColumns = ['get', 'name', 'description'];
        break;
      default:
        this.displayedColumns = ['get', 'name', 'description', 'creator'];
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
