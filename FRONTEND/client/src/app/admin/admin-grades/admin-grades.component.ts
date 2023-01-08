import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { IUserGrade } from 'src/app/courses/models/grades/grade-user';
import { IUserGradeDetailed } from 'src/app/courses/models/grades/grade-user-detailed';
import { GradeService } from 'src/app/_services/grade.service';

@Component({
  selector: 'app-admin-grades',
  templateUrl: './admin-grades.component.html',
  styleUrls: ['./admin-grades.component.scss']
})
export class AdminGradesComponent implements OnInit {

  @ViewChild(MatPaginator) 
  paginator: MatPaginator;

  @ViewChild(MatSort) 
  sort: MatSort;

  grades: IUserGradeDetailed[] = [];

  displayedColumns: string[] = ['delete', 'user', 'value', 'title', 'description', 'courseName', 'categoryName'];

  dataSource: MatTableDataSource<IUserGradeDetailed>;

  isSpinning: boolean = true;

  constructor(private gradeService: GradeService,
    private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.gradeService.getAllGrades().subscribe((grades) => {
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

  deleteGrade(gradeId: number): void {
    this.gradeService.deleteGrade(gradeId).subscribe((isDeleted) => {
      if (isDeleted) {
        const gradeIndex = this.grades.findIndex((g) => g.id === gradeId);
        this.grades.splice(gradeIndex, 1);
        this.paginate();
        this.snackBar.open("Ocena usunięta.", '', { panelClass: ['text-white', 'bg-success'] });
      }
      else {
        this.snackBar.open("Błąd podczas usuwania oceny.", '', { panelClass: ['text-white', 'bg-danger'] });
      }
    },
    (err) => {
      this.snackBar.open("Błąd podczas usuwania oceny.", '', { panelClass: ['text-white', 'bg-danger'] });
    });
  }
}
