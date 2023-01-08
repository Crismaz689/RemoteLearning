import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { IUserGrade } from '../courses/models/grades/grade-user';
import { GradeService } from '../_services/grade.service';

@Component({
  selector: 'app-user-grades',
  templateUrl: './user-grades.component.html',
  styleUrls: ['./user-grades.component.scss']
})
export class UserGradesComponent implements OnInit {

  @ViewChild(MatPaginator) 
  paginator: MatPaginator;

  @ViewChild(MatSort) 
  sort: MatSort;

  grades: IUserGrade[] = [];

  displayedColumns: string[] = ['value', 'title', 'description', 'courseName', 'categoryName'];

  dataSource: MatTableDataSource<IUserGrade>;

  isSpinning: boolean = true;

  constructor(private gradeService: GradeService) { }

  ngOnInit(): void {
    this.gradeService.getCurrentUserGrades().subscribe((grades) => {
      this.grades = grades;
      this.paginate();
      this.isSpinning = false;
    });
  }

  paginate(): void {
    this.dataSource = new MatTableDataSource(this.grades);
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
}
